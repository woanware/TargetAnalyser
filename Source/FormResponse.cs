using System;
using System.Windows.Forms;

namespace TargetAnalyser
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FormResponse : Form
    {
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public FormResponse(string response)
        {
            InitializeComponent();

            textResponse.Text = response;
        }
        #endregion

        #region Button Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        #endregion
    }
}
