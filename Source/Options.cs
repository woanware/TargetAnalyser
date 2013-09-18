using System;
using CommandLine;
using CommandLine.Text;

namespace TargetAnalyser
{
    /// <summary>
    /// Internal class used for the command line parsing
    /// </summary>
    internal class Options : CommandLineOptionsBase
    {
        [Option("t", "target", Required = false, DefaultValue = "", HelpText = "Target (either an IP, domain or MD5 hash")]
        public string Target { get; set; }

        [Option("m", "mode", Required = true, DefaultValue = "", HelpText = "Valid values are i, d or h")]
        public string Mode { get; set; }

        [Option("f", "format", Required = false, DefaultValue = "", HelpText = "Output format e.g. c (csv), j (json) or x (xml)")]
        public string Format { get; set; }

        [Option("o", "output", Required = false, DefaultValue = "", HelpText = "Output file")]
        public string Output { get; set; }

        [Option("i", "input", Required = false, DefaultValue = "", HelpText = "Input file")]
        public string Input { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var help = new HelpText
            {
                Copyright = new CopyrightInfo("woanware", 2013),
                AdditionalNewLineAfterOption = false,
                AddDashesToOption = true
            };

            this.HandleParsingErrorsInHelp(help);

            help.AddPreOptionsLine("Usage: TargetAnalyser -t 192.168.0.1 -m i -o \"C:\\output.xml\" -f x");
            help.AddPreOptionsLine("       TargetAnalyser -t www.woanware.co.uk -m u");
            help.AddOptions(this);

            return help;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="help"></param>
        private void HandleParsingErrorsInHelp(HelpText help)
        {
            if (this.LastPostParsingState.Errors.Count > 0)
            {
                var errors = help.RenderParsingErrorsText(this, 2); // indent with two spaces
                if (!string.IsNullOrEmpty(errors))
                {
                    help.AddPreOptionsLine(string.Concat(Environment.NewLine, "ERROR(S):"));
                    help.AddPreOptionsLine(errors);
                }
            }
        }
    }
}
