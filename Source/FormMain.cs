using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using woanware;

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
        private Settings _settings;
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

            _analyser = new Analyser(VT_API_KEY, _retries);
            _analyser.ResultsIdentified += OnAnalyser_Result;
            _analyser.Complete += OnAnalyser_Complete;
            _analyser.Message += OnAnalyser_Message;

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

                    listResults.SelectedIndex = 0;
                }
                else
                {
                    olvcResult.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                    olvcSource.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
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
                    _analyser.Analyse(_settings.Sources, Global.TargetType.Ip, txtTarget.Text);
                    break;
                case 1:
                    _analyser.Analyse(_settings.Sources, Global.TargetType.Url, txtTarget.Text);
                    break;
                case 2:
                    _analyser.Analyse(_settings.Sources, Global.TargetType.Md5, txtTarget.Text);
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
            _settings = new Settings();
            if (_settings.FileExists == true)
            {
                string ret = _settings.Load();
                if (ret.Length > 0)
                {
                    UserInterface.DisplayErrorMessageBox(this, ret);
                }
                else
                {
                    this.WindowState = _settings.FormState;

                    if (_settings.FormState != FormWindowState.Maximized)
                    {
                        this.Location = _settings.FormLocation;
                        this.Size = _settings.FormSize;
                    }
                }
            }
            else
            {
                // Add all providers initially
                foreach (Global.Source source in Misc.EnumToList<Global.Source>())
                {
                    _settings.Sources = _settings.Sources.Include(source);
                }
            }

            cboTargetType.SelectedIndex = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _settings.FormLocation = base.Location;
            _settings.FormSize = base.Size;
            _settings.FormState = base.WindowState;
            string ret = _settings.Save();
            if (ret.Length > 0)
            {
                UserInterface.DisplayErrorMessageBox(this, ret);
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
        private void contextShow_Click(object sender, EventArgs e)
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
        private void contextShowParent_Click(object sender, EventArgs e)
        {
            if (listResults.SelectedObjects.Count != 1)
            {
                return;
            }

            Result result = (Result)listResults.SelectedObject;
            Misc.ShellExecuteFile(result.ParentUrl);
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
        #endregion

        #region Menu Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuToolsProviders_Click(object sender, EventArgs e)
        {
            using (FormProviders form = new FormProviders(_settings.Sources))
            {
                if (form.ShowDialog(this) == DialogResult.Cancel)
                {
                    return;
                }

                _settings.Sources = form.Sources;
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
                string ret = Output.Process(results, Global.OutputMode.Json, saveFileDialog.FileName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileExportCsv_Click(object sender, EventArgs e)
        {

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
                string ret = Output.Process(results, Global.OutputMode.Xml, saveFileDialog.FileName);
            }
        }
        #endregion
    }
}
