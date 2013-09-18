namespace TargetAnalyser
{
    /// <summary>
    /// 
    /// </summary>
    public class Result
    {
        #region Member Variables
        public Global.Source Source { get; set; }
        public string Info { get; set; }
        public string ParentUrl { get; set; }
        public string Url { get; set; }
        public bool Identified { get; set; }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public Result()
        {
            //Source = string.Empty;
            Info = string.Empty;
            ParentUrl = string.Empty;
            Url = string.Empty;
        }
    }
}
