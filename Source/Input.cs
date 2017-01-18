using System.Collections.Generic;
using woanware;

namespace TargetAnalyser
{
    /// <summary>
    /// 
    /// </summary>
    public class Input
    {
        #region Properties/Member Variables
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public string Url { get; set; }
        public string FullUrl { get; set; }
        public List<string> DataTypes { get; set; } = new List<string>();
        public List<string> Regexes { get; set; } = new List<string>();
        public List<string> Results { get; set; } = new List<string>();
        public string MultipleMatchRegex { get; set; }
        public string LinkRegex { get; set; }
        public string HttpMethod { get; set; }
        public string HttpBody { get; set; }
        public List<woanware.NameValue> HttpHeaders { get; set; } = new List<NameValue>();
        public bool StripNewLines { get; set; }
        #endregion
    }
}