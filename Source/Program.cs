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

                    if (_options.Input.Length > 0)
                    {
                        if (_options.Output.Length == 0)
                        {
                            Console.WriteLine("The output file must be supplied when using an input list");
                            return;
                        }

                        if (_options.Format.Length > 0)
                        {
                            Console.WriteLine("The output format is ignored when using an input list: " + _options.Format);
                        }   
                    }
                    else
                    {
                        if (_options.Output.Length == 0)
                        {
                            Console.WriteLine("The target must be supplied when not using an input list");
                            return;
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
                    }

                    _results = new List<Result>();

                    _analyser = new Analyser("", _settings.Retries);
                    _analyser.ResultsIdentified += OnAnalyser_Result;
                    _analyser.Complete += OnAnalyser_Complete;
                    _analyser.Message += OnAnalyser_Message;

                    if (_options.Input.Length > 0)
                    {
                        // Output a blank header line for the output CSV
                        List<Result> results = new List<Result>();
                        string ret = Output.Process(results, Global.OutputMode.Csv, _options.Output, true);

                        switch (_options.Mode.ToLower())
                        {
                            case "i":
                                _analyser.Analyse(_settings.Sources, Global.TargetType.Ip, _options.Input, _options.Output, _settings);
                                break;
                            case "d":
                                _analyser.Analyse(_settings.Sources, Global.TargetType.Domain, _options.Input, _options.Output, _settings);
                                break;
                            case "h":
                                _analyser.Analyse(_settings.Sources, Global.TargetType.Hash, _options.Input, _options.Output, _settings);
                                break;
                            default:
                                Console.WriteLine("Invalid mode parameter (either i, d or h)");
                                return;
                        }
                    }
                    else
                    {
                        switch (_options.Mode.ToLower())
                        {
                            case "i":
                                _analyser.Analyse(_settings.Sources, Global.TargetType.Ip, _options.Target, _settings);
                                break;
                            case "d":
                                _analyser.Analyse(_settings.Sources, Global.TargetType.Domain, _options.Target, _settings);
                                break;
                            case "h":
                                _analyser.Analyse(_settings.Sources, Global.TargetType.Hash, _options.Target, _settings);
                                break;
                            default:
                                Console.WriteLine("Invalid mode parameter (either i, d or h)");
                                return;
                        }
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
            if (_analyser.InputMode == Global.InputMode.Single)
            {
                if (_options.Output.Length > 0)
                {
                    string ret = string.Empty;
                    switch (_options.Format.ToLower())
                    {
                        case "c":
                            ret = Output.Process(_results, Global.OutputMode.Csv, _options.Output, true);
                            break;
                        case "j":
                            ret = Output.Process(_results, Global.OutputMode.Json, _options.Output, true);
                            break;
                        case "x":
                            ret = Output.Process(_results, Global.OutputMode.Xml, _options.Output, true);
                            break;
                        default:
                            Console.WriteLine("Invalid format parameter (either c, j or x)");
                            break;
                    }
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
            if (_analyser.InputMode == Global.InputMode.Single)
            {
                _results.AddRange(results);
            }
            else
            {
                if (results.First().Identified == true)
                {
                    string ret = Output.Process(results, Global.OutputMode.Csv, _analyser.OutputFile, false);
                }
            }
        }
        #endregion
    }
}
