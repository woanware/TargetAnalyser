using System.Windows.Forms;

namespace TargetAnalyser
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FormImport : Form
    {
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public FormImport()
        {
            InitializeComponent();
            cboImportType.SelectedIndex = 0;
        }
        #endregion

        #region Button Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportFile_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files|*.txt|All Files|*.*";
            ofd.Title = "Select the import file";
            ofd.Multiselect = false;

            if (ofd.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            txtImportFile.Text = ofd.FileName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOutputFile_Click(object sender, System.EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "TSV Files|*.tsv|CSV Files|*.csv|All Files|*.*";
            sfd.Title = "Select the output file";

            if (sfd.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            txtOutputFile.Text = sfd.FileName;
        }
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public string OutputFile
        {
            get
            {
                return txtOutputFile.Text;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ImportFile
        {
            get
            {
                return txtImportFile.Text;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Global.TargetType TargetType
        {
            get
            {
                switch (cboImportType.SelectedIndex)
                {
                    case 0:
                        return Global.TargetType.Ip;
                    case 1:
                        return Global.TargetType.Domain;
                    case 2:
                        return Global.TargetType.Hash;
                    default:
                        return Global.TargetType.Ip;
                }
            }
        }
        #endregion
    }
}
