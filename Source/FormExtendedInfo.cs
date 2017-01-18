using System.Windows.Forms;

namespace TargetAnalyser
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FormExtendedInfo : Form
    {
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public FormExtendedInfo(string info)
        {
            InitializeComponent();

            textExtendedInfo.Text = info;
        }
        #endregion

        #region Button Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butClose_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        #endregion
    }
}
