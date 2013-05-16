using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using woanware;

namespace TargetAnalyser
{
    public partial class FormProviders : Form
    {
        //create the typical object
        //RegexOptions options = RegexOptions.None;

        ////Assign a value
        //options = options.Include(RegexOptions.IgnoreCase); 
        ////options = IgnoreCase

        ////Or assign multiple values
        //options = options.Include(RegexOptions.Multiline | RegexOptions.Singleline); 
        ////options = IgnoreCase, Multiline, Singleline

        ////Remove values from the list
        //options = options.Remove(RegexOptions.IgnoreCase); 
        ////options = Multiline, Singleline

        ////Check if a value even exists
        //bool multiline = options.Has(RegexOptions.Multiline); //true
        //bool ignoreCase = options.Missing(RegexOptions.IgnoreCase); //true

        public Global.Source Sources { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public FormProviders(Global.Source source)
        {
            InitializeComponent();

            this.listProviders.BooleanCheckStateGetter = delegate(Object rowObject)
            {
                return ((Provider)rowObject).Active;
            };

            this.listProviders.BooleanCheckStatePutter = delegate(Object rowObject, bool newValue)
            {
                ((Provider)rowObject).Active = newValue;
                return newValue; // return the value that you want the control to use
            };

            LoadProviders(source);
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadProviders(Global.Source source)
        {
            foreach (Global.Source temp in Misc.EnumToList<Global.Source>())
            {
                if (temp == Global.Source.None)
                {
                    continue;
                }

                Provider provider = new Provider();
                provider.Source = temp;
                provider.Description = temp.GetEnumDescription();
                if (source.Has(temp) == true)
                {
                    provider.Active = true;
                }

                listProviders.AddObject(provider);
            }

            olvcProvider.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        #region Button Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            foreach (Provider provider in listProviders.Objects)
            {
                if (provider.Active == true)
                {
                    Sources = Sources.Include(provider.Source);
                }
                else
                {
                    Sources = Sources.Remove(provider.Source);
                }
            }

            if (Sources == Global.Source.None)
            {
                UserInterface.DisplayMessageBox(this, "At least one provider must be selected", MessageBoxIcon.Exclamation);
                return;
            }
            
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        #endregion
    }
}
