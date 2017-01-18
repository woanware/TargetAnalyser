using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using woanware;

namespace TargetAnalyser
{
    /// <summary>
    /// 
    /// </summary>
    public class Inputs
    {
        #region Constants
        private const string FILENAME = "Inputs.xml";
        #endregion

        #region Properties/Variables
        public int Version { get; set; } = 1;
        public List<Input> Data { get; set; }  = new List<Input>();
        #endregion

        #region Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Load()
        {
            return LoadFromFile(GetPath());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string LoadFromFile(string path)
        {
            try
            {
                if (File.Exists(path) == false)
                {
                    return string.Empty;
                }

                XmlSerializer serializer = new XmlSerializer(typeof(Inputs));

                FileInfo info = new FileInfo(path);
                using (FileStream stream = info.OpenRead())
                {
                    Inputs i = (Inputs)serializer.Deserialize(stream);
                    this.Version = i.Version;
                    this.Data = i.Data;
                    return string.Empty;
                }
            }
            catch (FileNotFoundException fileNotFoundEx)
            {
                return fileNotFoundEx.Message;
            }
            catch (UnauthorizedAccessException unauthAccessEx)
            {
                return unauthAccessEx.Message;
            }
            catch (IOException ioEx)
            {
                return ioEx.Message;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    return ex.InnerException.Message;
                }

                return ex.Message;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Inputs));
                using (StreamWriter writer = new StreamWriter(GetPath(), false))
                {
                    serializer.Serialize((TextWriter)writer, this);
                    return string.Empty;
                }
            }
            catch (FileNotFoundException fileNotFoundEx)
            {
                return fileNotFoundEx.Message;
            }
            catch (UnauthorizedAccessException unauthAccessEx)
            {
                return unauthAccessEx.Message;
            }
            catch (IOException ioEx)
            {
                return ioEx.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region Misc Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetPath()
        {
            return System.IO.Path.Combine(Misc.GetApplicationDirectory(), FILENAME);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool FileExists
        {
            get
            {
                //string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"woanware\" + Application.ProductName + @"\");
                return File.Exists(GetPath());
            }
        }
        #endregion
    }
}
