using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using woanware;
using System.Net;

namespace TargetAnalyser
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FormMain : Form
    {
        #region Constants
        private const string VT_API_KEY = "";
        #endregion

        #region Member Variables
        private Settings settings;
        private Inputs inputs;
        private ApiKeys apiKeys;
        private Analyser _analyser;
        private HourGlass _hourGlass;
        private int _retries = 3;
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public FormMain()
        {
            InitializeComponent();           

            txtTarget.Select();
        }
        #endregion

        #region Analyser Event Handlers
        /// <summary>
        /// 
        /// </summary>
        private void OnAnalyser_Complete()
        {
            MethodInvoker methodInvoker = delegate
            {
                _hourGlass.Dispose();

                if (listResults.Items.Count > 0)
                {
                    olvcResult.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    olvcSource.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    olvUrl2.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    olvcUrl1.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

                    listResults.SelectedIndex = 0;
                }
                else
                {
                    olvcResult.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                    olvcSource.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                    olvUrl2.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                    olvcUrl1.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                }

                UpdateStatusBar("Complete");
            };

            if (this.InvokeRequired == true)
            {
                this.BeginInvoke(methodInvoker);
            }
            else
            {
                methodInvoker.Invoke();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        private void OnAnalyser_Message(string message)
        {
            UpdateStatusBar(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="results"></param>
        private void OnAnalyser_Result(List<Result> results)
        {
            listResults.AddObjects(results);
        }
        #endregion

        #region User Interface Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        private void UpdateStatusBar(string message)
        {
            MethodInvoker methodInvoker = delegate
            {
                statusLabel.Text = message;
            };

            if (this.InvokeRequired == true)
            {
                this.BeginInvoke(methodInvoker);
            }
            else
            {
                methodInvoker.Invoke();
            }
        }
        #endregion

        #region Button Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtTarget.Text.Trim().Length == 0)
            {
                UserInterface.DisplayMessageBox(this, "An a valid search term", MessageBoxIcon.Exclamation);
                txtTarget.Select();
                return;
            }

            _hourGlass = new HourGlass(this);
            listResults.ClearObjects();

            switch (cboTargetType.SelectedIndex)
            {
                case 0:
                    _analyser.Analyse(new string[] {"ip"}, txtTarget.Text);
                    break;
                case 1:
                    _analyser.Analyse(new string[] {"domain"}, txtTarget.Text);
                    break;
                case 2:
                    _analyser.Analyse(new string[] {"domain", "url"}, txtTarget.Text); 
                    break;
                case 3:
                    _analyser.Analyse(new string[] {"url"}, txtTarget.Text);
                    break;
                case 4:
                    _analyser.Analyse(new string[] {"md5"}, txtTarget.Text);
                    break;
            }
        }
        #endregion

        #region Form Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.settings = new Settings();
            if (this.settings.FileExists == true)
            {
                string ret = this.settings.Load();
                if (ret.Length > 0)
                {
                    UserInterface.DisplayErrorMessageBox(this, ret);
                }
                else
                {
                    this.WindowState = this.settings.FormState;

                    if (this.settings.FormState != FormWindowState.Maximized)
                    {
                        this.Location = this.settings.FormLocation;
                        this.Size = this.settings.FormSize;
                    }
                }
            }            

            _analyser = new Analyser(_retries);
            _analyser.ResultsIdentified += OnAnalyser_Result;
            _analyser.Complete += OnAnalyser_Complete;
            _analyser.Message += OnAnalyser_Message;

            LoadInputs();
            LoadApiKeys();

            cboTargetType.SelectedIndex = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.settings.FormLocation = base.Location;
            this.settings.FormSize = base.Size;
            this.settings.FormState = base.WindowState;
            string ret = this.settings.Save();
            if (ret.Length > 0)
            {
                UserInterface.DisplayErrorMessageBox(this, "Error saving settings: " + ret);
            }

            ret = this.inputs.Save();
            if (ret.Length > 0)
            {
                UserInterface.DisplayErrorMessageBox(this, "Error saving inputs files: " + ret);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Shown(object sender, EventArgs e)
        {
            txtTarget.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }
        #endregion

        #region Context Menu Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextGoToUrl1_Click(object sender, EventArgs e)
        {
            if (listResults.SelectedObjects.Count != 1)
            {
                return;
            }

            Result result = (Result)listResults.SelectedObject;
            Misc.ShellExecuteFile(result.Url);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextGoToUrl2_Click(object sender, EventArgs e)
        {
            if (listResults.SelectedObjects.Count != 1)
            {
                return;
            }

            Result result = (Result)listResults.SelectedObject;
            Misc.ShellExecuteFile(result.FullUrl);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextCopyInfo_Click(object sender, EventArgs e)
        {
            if (listResults.SelectedObjects.Count != 1)
            {
                return;
            }

            Result result = (Result)listResults.SelectedObject;
            Clipboard.SetText(result.Info);
            UpdateStatusBar("Info copied to clipboard: " + result.Info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextExtended_Click(object sender, EventArgs e)
        {
            if (listResults.SelectedObject == null)
            {
                return;
            }

            Result r = (Result)listResults.SelectedObject;
            using (FormExtendedInfo f = new FormExtendedInfo(r.ExtendedInfo))
            {
                f.ShowDialog();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextResponse_Click(object sender, EventArgs e)
        {
            if (listResults.SelectedObject == null)
            {
                return;
            }

            Result r = (Result)listResults.SelectedObject;
            using (FormResponse f = new FormResponse(r.Response))
            {
                f.ShowDialog();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void context_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (listResults.SelectedObjects.Count != 1)
            {
                contextExtended.Enabled = false;
                return;
            }

            contextExtended.Enabled = true;
        }
        #endregion

        #region Menu Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuToolsProviders_Click(object sender, EventArgs e)
        {
            using (FormInputs f = new FormInputs(this.inputs))
            {
                if (f.ShowDialog(this) == DialogResult.Cancel)
                {
                    return;
                }

                this.inputs = f.Inputs;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            using (FormAbout form = new FormAbout())
            {
                form.ShowDialog(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileExportJson_Click(object sender, EventArgs e)
        {
            using (new HourGlass(this))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Select the export JSON file";
                saveFileDialog.Filter = "JSON Files|*.json";
                if (saveFileDialog.ShowDialog(this) == DialogResult.Cancel)
                {
                    return;

                }

                List<Result> results = listResults.Objects.Cast<Result>().ToList();
                string ret = Output.Process(results, Global.OutputMode.Json, saveFileDialog.FileName, true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileExportCsv_Click(object sender, EventArgs e)
        {
            using (new HourGlass(this))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Select the export CSV file";
                saveFileDialog.Filter = "CSV Files|*.csv";
                if (saveFileDialog.ShowDialog(this) == DialogResult.Cancel)
                {
                    return;

                }

                List<Result> results = listResults.Objects.Cast<Result>().ToList();
                string ret = Output.Process(results, Global.OutputMode.Csv, saveFileDialog.FileName, true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileExportXml_Click(object sender, EventArgs e)
        {
            using (new HourGlass(this))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Select the export XML file";
                saveFileDialog.Filter = "XML Files|*.xml";
                if (saveFileDialog.ShowDialog(this) == DialogResult.Cancel)
                {
                    return;

                }

                List<Result> results = listResults.Objects.Cast<Result>().ToList();
                string ret = Output.Process(results, Global.OutputMode.Xml, saveFileDialog.FileName, true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuToolsOptions_Click(object sender, EventArgs e)
        {
            using (FormOptions form = new FormOptions(this.settings))
            {
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                this.settings = form.Settings;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuToolsReloadInputs_Click(object sender, EventArgs e)
        {
            LoadInputs();
            LoadApiKeys();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuToolsUpdate_Click(object sender, EventArgs e)
        {                         
            string tempFile = System.IO.Path.GetTempFileName();

            try
            {
                WebClient wb = new WebClient();
                wb.DownloadFile("https://raw.githubusercontent.com/woanware/TargetAnalyser/master/Inputs/Inputs.xml", tempFile);

                if (System.IO.File.Exists(tempFile) == false)
                {
                    UserInterface.DisplayErrorMessageBox(this, "Error checking for updates");
                    return;
                }

                Inputs i = new Inputs();
                string ret = i.LoadFromFile(tempFile);
                if (ret.Length > 0)
                {
                    UserInterface.DisplayErrorMessageBox(this, "Error loading the update: " + ret);
                    return;
                }

                if (i.Version == this.inputs.Version)
                {
                    UserInterface.DisplayMessageBox(this, "No updates available", MessageBoxIcon.Information);
                    return;
                }

                DialogResult dr = UserInterface.DisplayQuestionMessageBox(this, "Update available. Do you want to update? (Note that it will overwrite any local changes)");
                if (dr == DialogResult.Yes)
                {
                    this.inputs.LoadFromFile(tempFile);
                    if (this._analyser != null)
                    {
                        this._analyser.Inputs = this.inputs;
                    }
                }
            }
            catch (WebException webEx)
            {
                if (webEx.InnerException == null)
                {
                    UserInterface.DisplayErrorMessageBox(this, "Error checking for updates: " + webEx.Message);
                }
                else
                {
                    UserInterface.DisplayErrorMessageBox(this, "Error checking for updates: " + webEx.InnerException.Message);
                }
            }
            catch (Exception ex)
            {
                UserInterface.DisplayErrorMessageBox(this, "Error checking for updates: " + ex.Message);
            }
            finally
            {
                IO.DeleteFile(tempFile);
            }
            
        }
        #endregion

        #region Misc Methods
        /// <summary>
        /// 
        /// </summary>
        private void LoadInputs()
        {
            this.inputs = new Inputs();
            if (this.inputs.FileExists == true)
            {
                string ret = this.inputs.Load();
                if (ret.Length > 0)
                {
                    UserInterface.DisplayErrorMessageBox(this, "Error loading inputs file: " +  ret);
                }
            }

            if (this._analyser != null)
            {
                this._analyser.Inputs = this.inputs;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadApiKeys()
        {
            this.apiKeys = new ApiKeys();
            if (apiKeys.FileExists == true)
            {
                string ret = this.apiKeys.Load();
                if (ret.Length > 0)
                {
                    UserInterface.DisplayErrorMessageBox(this, "Error loading API key file: " + ret);
                }
            }

            if (this._analyser != null)
            {
                this._analyser.ApiKeys = this.apiKeys;
            }
        }
        #endregion

        #region List Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listResults.SelectedObject == null)
            {
                return;
            }

            Result r = (Result)listResults.SelectedObject;
            using (FormExtendedInfo f = new FormExtendedInfo(r.ExtendedInfo))
            {
                f.ShowDialog();
            }
        }
        #endregion
    }
}
