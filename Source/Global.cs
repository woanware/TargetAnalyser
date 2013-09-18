using System;
using System.ComponentModel;

namespace TargetAnalyser
{
    /// <summary>
    /// 
    /// </summary>
    public class Global
    {
        /// <summary>
        /// 
        /// </summary>
        public enum InputMode
        {
            Single = 0,
            List = 1
        }

        /// <summary>
        /// 
        /// </summary>
        public enum View
        {
            Full = 0,
            Condensed = 1
        }

        /// <summary>
        /// 
        /// </summary>
        public enum OutputMode
        {
            Csv = 0,
            Xml = 1,
            Json = 2
        }

        /// <summary>
        /// 
        /// </summary>
        public enum TargetType
        {
            Ip = 0,
            Domain = 1,
            Hash = 2
        }

        /// <summary>
        /// 
        /// </summary>
        [Flags]
        public enum Source
        {
            [Description("None")]
            None = 0,
            [Description("IP Void")]
            IpVoid = 1,
            [Description("URL Void")]
            UrlVoid = 2,
            [Description("Robtex")]
            Robtex = 4,
            [Description("Fortiguard")]
            Fortiguard = 8,
            [Description("AlienVault")]
            AlienVault = 16,
            [Description("MalwareDomainList")]
            MalwareDomainlist = 32,
            [Description("VxVault")]
            VxVault = 64,
            [Description("MinotaurAnalysis")]
            MinotaurAnalysis = 128,
            [Description("ThreatExpert")]
            ThreatExpert = 256,
            [Description("VirusTotal (Hash)")]
            VirusTotalHash = 512,
            [Description("BFK Passive DNS")]
            Bfk = 1024,
            [Description("VirusTotal (DNS)")]
            VirusTotalDns = 2048,
            [Description("HpHosts")]
            HpHosts = 4096,
            [Description("Hurricane Electric")]
            HurricaneElectric = 8192,
            [Description("Google Diagnostics")]
            GoogleDiagnostics = 16384
        }
    }
}
