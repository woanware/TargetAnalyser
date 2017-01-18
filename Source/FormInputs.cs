using System;
using System.Windows.Forms;

namespace TargetAnalyser
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FormInputs : Form
    {
        public Inputs Inputs { get; private set; }

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public FormInputs(Inputs i)
        {
            InitializeComponent();

            this.Inputs = i;

            this.listProviders.BooleanCheckStateGetter = delegate(Object rowObject)
            {
                return ((Input)rowObject).Enabled;
            };

            this.olvcDataTypes.AspectGetter = delegate (Object rowObject)
            {
                return string.Join(", ", ((Input)rowObject).DataTypes);
            };

            this.listProviders.BooleanCheckStatePutter = delegate(Object rowObject, bool newValue)
            {
                ((Input)rowObject).Enabled = newValue;
                return newValue; // return the value that you want the control to use
            };

            LoadProviders();
        }
        #endregion

        #region Misc Methods
        /// <summary>
        /// 
        /// </summary>
        private void LoadProviders()
        {
            listProviders.AddObjects(this.Inputs.Data);
            olvcInput.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            olvcDataTypes.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        #endregion

        #region Button Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        #endregion
    }
}
