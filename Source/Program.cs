using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using woanware;

namespace TargetAnalyser
{
    static class Program
    {
        private static Settings _settings;
        private static Options _options;
        private static Analyser _analyser;
        private static ManualResetEvent _reset;
        private static List<Result> _results;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            #if CONSOLE
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    AssemblyName assemblyName = assembly.GetName();

                    Console.WriteLine(Environment.NewLine + "TargetAnalyser v" + assemblyName.Version.ToString(3) + Environment.NewLine);

                    _options = new Options();
                    if (CommandLineParser.Default.ParseArguments(args, _options) == false)
                    {
                        return;
                    }

                    _settings = new Settings();
                    if (_settings.FileExists == true)
                    {
                        string ret = _settings.Load();
                        if (ret.Length > 0)
                        {
                            Console.WriteLine("An error occurred whilst loading the settings: " + ret);
                            return;
                        }
                    }
                    else
                    {
                        // Add all providers initially
                        foreach (Global.Source source in Misc.EnumToList<Global.Source>())
                        {
                            _settings.Sources = _settings.Sources.Include(source);
                        }
                    }

                    if (_options.Output.Length > 0)
                    {
                        // Validate the format parameter
                        switch (_options.Format.ToLower())
                        {
                            case "c":
                            case "j":
                            case "x":
                                break;
                            default:
                                Console.WriteLine("Invalid format parameter (either c, j or x)");
                                return;
                        }
                    }
                    
                    _results = new List<Result>();

                    _analyser = new Analyser("", _settings.Retries);
                    _analyser.ResultsIdentified += OnAnalyser_Result;
                    _analyser.Complete += OnAnalyser_Complete;
                    _analyser.Message += OnAnalyser_Message;

                    switch (_options.Mode.ToLower())
                    {
                        case "i":
                            _analyser.Analyse(_settings.Sources, Global.TargetType.Ip, _options.Target);
                            break;
                        case "d":
                            _analyser.Analyse(_settings.Sources, Global.TargetType.Url, _options.Target);
                            break;
                        case "h":
                            _analyser.Analyse(_settings.Sources, Global.TargetType.Md5, _options.Target);
                            break;
                        default:
                            Console.WriteLine("Invalid mode parameter (either i, d or h)");
                            return;
                    }

                    _reset = new ManualResetEvent(false);
                    _reset.WaitOne();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
                return;
            #else
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
            #endif
        }

        #region Analyser Event Handlers
        /// <summary>
        /// 
        /// </summary>
        private static void OnAnalyser_Complete()
        {
            if (_options.Output.Length > 0)
            {
                string ret = string.Empty;
                switch (_options.Format.ToLower())
                {
                    case "c":
                        ret = Output.Process(_results, Global.OutputMode.Csv, _options.Output);
                        break;
                    case "j":
                        ret = Output.Process(_results, Global.OutputMode.Json, _options.Output);
                        break;
                    case "x":
                        ret = Output.Process(_results, Global.OutputMode.Xml, _options.Output);
                        break;
                    default:
                        Console.WriteLine("Invalid format parameter (either c, j or x)");
                        break;
                }
            }

            Console.WriteLine("Complete");

            _reset.Set();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        private static void OnAnalyser_Message(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="results"></param>
        private static void OnAnalyser_Result(List<Result> results)
        {
            _results.AddRange(results);
        }
        #endregion
    }
}
