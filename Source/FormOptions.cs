using System;
using System.Windows.Forms;

namespace TargetAnalyser
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FormOptions : Form
    {
        #region Member Variables
        private Settings _settings;
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public FormOptions(Settings settings)
        {
            InitializeComponent();
            _settings = settings;

            chkUrlVoidPassive.Checked = _settings.UrlVoidPassive;
        }
        #endregion 

        #region Button Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        #endregion

        #region Properties
        public Settings Settings
        {
            get { return _settings; }
        }
        #endregion
    }
}
