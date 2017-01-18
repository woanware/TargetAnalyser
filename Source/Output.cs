using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using CsvHelper.Configuration;
using woanware;

namespace TargetAnalyser
{
    /// <summary>
    /// Object used for clean XML serialisation
    /// </summary>
    [XmlRoot("Data")]
    public class Results
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Result")]
        public List<Result> Items { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Results()
        {
            Items = new List<Result>();
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    public static class Output
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string Process(List<Result> results, 
                                     Global.OutputMode outputMode, 
                                     string file, 
                                     bool outputHeaders)
        {
            //Func<List<Result>, Global.OutputMode, string, string> outputResults = delegate(List<Result> a, Global.OutputMode b, string c)
            //{
            //    try
            //    {
            //        switch (outputMode)
            //        {
            //            case Global.OutputMode.Csv:
            //                return string.Empty;
            //            case Global.OutputMode.Json:
            //                StringBuilder json = new StringBuilder();
            //                JavaScriptSerializer serializer = new JavaScriptSerializer();
            //                serializer.Serialize(results, json);

            //                string ret = IO.WriteTextToFile(json.ToString(), file, false);
            //                if (ret.Length > 0)
            //                {
            //                    return ret;
            //                }

            //                return string.Empty;
            //            case Global.OutputMode.Xml:

            //                Results tempResults = new Results();
            //                tempResults.Items.AddRange(results);

            //                XmlSerializer serializerXml = new XmlSerializer(typeof(Results));
            //                using (FileStream fs = new FileStream(file, FileMode.Create))
            //                {
            //                    serializerXml.Serialize(fs, tempResults);
            //                }

            //                return string.Empty;
            //        }

            //        return string.Empty;
            //    }
            //    catch (Exception ex)
            //    {
            //        return ex.Message;
            //    }
                
            //};

            Task<string> task = Task<string>.Factory.StartNew(() =>
            {
                try
                {
                    switch (outputMode)
                    {
                        case Global.OutputMode.Csv:
                            CsvConfiguration csvConfiguration = new CsvConfiguration();
                            csvConfiguration.Delimiter = "\t";

                            using (FileStream fileStream = new FileStream(file, FileMode.Append, FileAccess.Write))
                            using (StreamWriter streamWriter = new StreamWriter(fileStream))
                            using (CsvHelper.CsvWriter csvWriter = new CsvHelper.CsvWriter(streamWriter, csvConfiguration))
                            {
                                if (outputHeaders == true)
                                {
                                    csvWriter.WriteField("Source");
                                    csvWriter.WriteField("Info");
                                    csvWriter.WriteField("ParentUrl");
                                    csvWriter.WriteField("Url");
                                    csvWriter.NextRecord();
                                }

                                foreach (var result in results)
                                {
                                    csvWriter.WriteField(result.Source);
                                    csvWriter.WriteField(result.Info);
                                    csvWriter.WriteField(result.FullUrl);
                                    csvWriter.WriteField(result.Url);
                                    csvWriter.NextRecord();
                                }
                            }

                            return string.Empty;
                        case Global.OutputMode.Json:
                            StringBuilder json = new StringBuilder();
                            JavaScriptSerializer serializer = new JavaScriptSerializer();
                            serializer.Serialize(results, json);

                            string ret = IO.WriteTextToFile(json.ToString(), file, false);
                            if (ret.Length > 0)
                            {
                                return ret;
                            }

                            return string.Empty;
                        case Global.OutputMode.Xml:

                            Results tempResults = new Results();
                            tempResults.Items.AddRange(results);

                            XmlSerializer serializerXml = new XmlSerializer(typeof(Results));
                            using (FileStream fs = new FileStream(file, FileMode.Create))
                            {
                                serializerXml.Serialize(fs, tempResults);
                            }

                            return string.Empty;
                    }

                    return string.Empty;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                
            });

            return task.Result; 
        }
    }
}
