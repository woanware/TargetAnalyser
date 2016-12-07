using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
