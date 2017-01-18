namespace TargetAnalyser
{
    /// <summary>
    /// 
    /// </summary>
    public class Result
    {
        #region Member Variables
        public string Source { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
        public string ExtendedInfo { get; set; } = string.Empty;
        public string FullUrl { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Response { get; set; } = string.Empty;
        public bool Identified { get; set; }
        public bool HasExtended { get; set; }
        #endregion
    }
}
