using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace TargetAnalyser
{
    /// <summary>
    /// 
    /// </summary>
    public class Analyser
    {
        public delegate void ResultEvent(List<Result> results);

        public event woanware.Events.MessageEvent Message;
        public event ResultEvent ResultsIdentified;
        public event woanware.Events.DefaultEvent Complete;

        private CountdownEvent cde;
        public Inputs Inputs { get; set; }
        public ApiKeys ApiKeys { get; set; }
        private int _retries;
        public string OutputFile { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="retries"></param>
        public Analyser(int retries)
        {
            _retries = retries;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sources"></param>
        /// <param name="targetType"></param>
        /// <param name="data"></param>
        /// <param name="settings"></param>
        public void Analyse(string[] dataTypes,
                            string data)
        {
            (new Thread(() =>
            {
                cde = new CountdownEvent(this.Inputs.Data.Count);
                Parallel.ForEach<Input>(this.Inputs.Data, item => Analyse(dataTypes, item, data));
                cde.Wait();

                OnComplete();

            })).Start();
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTypes"></param>
        /// <param name="input"></param>
        /// <param name="data"></param>
        private void Analyse(string[] dataTypes, Input input, string data)
        {
            try
            {
                if (input.Enabled == false)
                {
                    return;
                }

                foreach (var d in input.DataTypes)
                foreach (var dt in dataTypes)
                {
                    if (d.ToLower() != dt.ToLower())
                    {
                        continue;
                    }

                    // DNS is a special case since it needs to use the .Net 
                    // DNS system objects rather than the WebClient
                    if (input.Name.ToLower() == "dns")
                    {
                        PerformDns(input, data);
                        continue;
                    }

                    PerformAnalysis(input, data);
                }
            }
            finally
            {
                this.cde.Signal();
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="data"></param>
        private void PerformAnalysis(Input i, string data)
        {
            var tempUrl = i.FullUrl;
            string response = string.Empty;
            try
            {
                OnMessage("Analysing via " + i.Name);                
                
                if (tempUrl.Contains("#DATA#"))
                {
                    tempUrl = tempUrl.Replace("#DATA#", data);
                }

                foreach (var ak in this.ApiKeys.Data)
                {
                    if (tempUrl.Contains(ak.Marker))
                    {
                        tempUrl = tempUrl.Replace(ak.Marker, ak.Value);
                    }
                }

                string httpBody = i.HttpBody;
                if (httpBody.Contains("#DATA#"))
                {
                    httpBody = httpBody.Replace("#DATA#", data);
                }

                foreach (var ak in this.ApiKeys.Data)
                {
                    if (httpBody.Contains(ak.Marker))
                    {
                        httpBody = httpBody.Replace(ak.Marker, ak.Value);
                    }
                }

                GZipWebClient wc = new GZipWebClient();
                WebClientResult wcr = null;
                if (i.HttpMethod == "POST")
                {                    
                    wcr = wc.Post(tempUrl, _retries, i.HttpHeaders, httpBody);
                }
                else
                {                   
                    wcr = wc.Download(tempUrl, _retries, i.HttpHeaders);                    
                }

                if (wcr.IsError == true)
                {
                    SendDefaultResult(i.Name,
                                      i.Url,
                                      tempUrl,
                                      wcr.Response,
                                      "Error: " + wcr.Response);
                    return;
                }

                response = wcr.Response;
                if (i.StripNewLines == true)
                {
                    response = wcr.Response.Replace("\n", "");
                    response = response.Replace("\r", "");
                }

                Result result = ProcessResults(i, response, i.Url, tempUrl);
                if (result == null)
                {
                    SendDefaultResult(i.Name, i.Url, tempUrl, response, "Not Found");
                    return;
                }

                List<Result> results = new List<Result>() { result };
                OnResultIdentified(results);
                return;
            }
            catch (Exception ex)
            {
                SendDefaultResult(i.Name, i.Url, tempUrl, response, "Error: " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="response"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        private Result ProcessResults(Input i, string response, string url, string fullUrl)
        {
            bool hasMatches = false;
            List<string> temp = new List<string>();
            Regex reg;

            Result result = new Result();
            result.Source = i.Name;
            result.Identified = true;
            result.Url = url;
            result.FullUrl = fullUrl;
            result.Response = response;

            if (i.MultipleMatchRegex.Length > 0)
            {                
                reg = new Regex(i.MultipleMatchRegex);               
                MatchCollection mc = reg.Matches(response);
                if (mc.Count == 0)
                {
                    return null;
                }

                hasMatches = true;

                bool first = true;
                List<string> tempExtended = new List<string>();
                string[] groupNames = reg.GetGroupNames();
                foreach (Match m in mc)
                {
                    temp = new List<string>();
                    foreach (string gn in groupNames)
                    {           
                        if (gn == "0")
                        {
                            continue;
                        }

                        temp.Add(gn + ": " + ScrubHtml(m.Groups[gn].Value.Trim()));                            
                    }

                    tempExtended.Add(string.Join(", ", temp));

                    if (first == true)
                    {
                        result.Info = string.Join(", ", temp);
                        first = false;
                    }
                }
                
                result.ExtendedInfo = string.Join(Environment.NewLine, tempExtended);
                result.HasExtended = true;
            }
            else
            {
                for (int index = 0; index < i.Regexes.Count; index++)
                {
                    reg = new Regex(i.Regexes[index]);

                    Match m = reg.Match(response);
                    if (m.Success == true)
                    {
                        if (i.Results[index].Length == 0)
                        {
                            temp.Add("Found");
                        }
                        else
                        {
                            temp.Add(i.Results[index] + ": " + m.Groups[1].Value);
                        }

                        hasMatches = true;
                    }
                }

                result.Info = string.Join(", ", temp);
                result.ExtendedInfo = string.Join(", ", temp);
            }
            
            if (hasMatches == false)
            {
                return null;
            }          

            if (i.LinkRegex.Length > 0)
            {
                reg = new Regex(i.LinkRegex);
                Match m = reg.Match(response);
                if (m.Success == true)
                {
                    result.Url = m.Groups[1].Value;
                }
                else
                {
                    result.Url = url;
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="data"></param>
        private void PerformDns(Input i, string data)
        {
            try
            {
                OnMessage("Analysing via " + i.Name);

                var hostName = Dns.GetHostEntry(data).HostName;
                if (hostName.Length == 0)
                {
                    SendDefaultResult(i.Name, "N/A", "N/A", "", "Not Found");
                    return;
                }

                Result result = new Result();
                result.Source = i.Name;
                result.Identified = true;
                result.Info = hostName;
                result.FullUrl = "N/A";
                result.Url = "N/A";
          
                List<Result> results = new List<Result>() { result };
                OnResultIdentified(results);
                return;
            }
            catch (Exception ex)
            {
                SendDefaultResult(i.Name, "N/A", "N/A", "", "Error: " + ex.Message);
            }
        }

        #region Misc Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string ScrubHtml(string value)
        {
            var step1 = Regex.Replace(value, @"<[^>]+>|&nbsp;", "").Trim();
            var step2 = Regex.Replace(step1, @"\s{2,}", " ");
            return step2;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="url"></param>
        /// <param name="message"></param>
        /// <param name="identified"></param>
        private void SendDefaultResult(string source, 
                                       string url,
                                       string fullUrl,
                                       string response,
                                       string message)
        {
            Result result = new Result();
            result.Source = source;
            result.Info = message;
            result.FullUrl = fullUrl;
            result.Url = url;
            result.Response = response;

            OnResultIdentified(new List<Result> { result });
        }
        #endregion

        #region Event Handler Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        private void OnResultIdentified(List<Result> result)
        {
            ResultsIdentified?.Invoke(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        private void OnMessage(string message)
        {
            Message?.Invoke(message);
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnComplete()
        {
            Complete?.Invoke();
        }
        #endregion
    }
}
