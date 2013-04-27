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
        public enum View
        {
            Full = 0,
            Condensed = 1
        }

        /// <summary>
        /// 
        /// </summary>
        public enum TargetType
        {
            Ip = 0,
            Url = 1,
            Md5 = 2
        }

        /// <summary>
        /// 
        /// </summary>
        public enum Source
        {
            [Description("IP Void")]
            IpVoid = 0,
            [Description("URL Void")]
            UrlVoid = 1,
            [Description("Robtex")]
            Robtex = 2,
            [Description("Fortiguard")]
            Fortiguard = 3,
            [Description("AlienVault")]
            AlienVault = 4,
            [Description("MalwareDomainList")]
            MalwareDomainlist = 5,
            [Description("VxVault")]
            VxVault = 6,
            [Description("MinotaurAnalysis")]
            MinotaurAnalysis = 7,
            [Description("ThreatExpert")]
            ThreatExpert = 8,
            [Description("VirusTotal (Hash)")]
            VirusTotalHash = 9,
            [Description("BFK Passive DNS")]
            Bfk = 10,
            [Description("VirusTotal (DNS)")]
            VirusTotalDns = 11,
            [Description("HpHosts")]
            HpHosts = 12,
            [Description("Hurricane Electric")]
            HurricaneElectric = 13
        }
    }
}
