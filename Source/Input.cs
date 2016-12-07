using System.Collections.Generic;

namespace TargetAnalyser
{
    public class Input
    {
        public string Name;
        public string FullUrl;
        public List<string> DataTypes;
        public List<string> Regex;
        public List<string> Result;
        public string HttpMethod;
        public List<woanware.NameValue> HttpParameters;
    }
}
