namespace TargetAnalyser
{
    partial class FormInputs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInputs));
            this.listProviders = new BrightIdeasSoftware.ObjectListView();
            this.olvcInput = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcDataTypes = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listProviders)).BeginInit();
            this.SuspendLayout();
            // 
            // listProviders
            // 
            this.listProviders.AllColumns.Add(this.olvcInput);
            this.listProviders.AllColumns.Add(this.olvcDataTypes);
            this.listProviders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listProviders.CheckBoxes = true;
            this.listProviders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcInput,
            this.olvcDataTypes});
            this.listProviders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.listProviders.FullRowSelect = true;
            this.listProviders.HideSelection = false;
            this.listProviders.Location = new System.Drawing.Point(13, 12);
            this.listProviders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listProviders.MultiSelect = false;
            this.listProviders.Name = "listProviders";
            this.listProviders.ShowGroups = false;
            this.listProviders.Size = new System.Drawing.Size(393, 397);
            this.listProviders.TabIndex = 3;
            this.listProviders.UseCompatibleStateImageBehavior = false;
            this.listProviders.View = System.Windows.Forms.View.Details;
            // 
            // olvcInput
            // 
            this.olvcInput.AspectName = "Name";
            this.olvcInput.CellPadding = null;
            this.olvcInput.Text = "Input";
            this.olvcInput.Width = 133;
            // 
            // olvcDataTypes
            // 
            this.olvcDataTypes.CellPadding = null;
            this.olvcDataTypes.Text = "Data Types";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnClose.Location = new System.Drawing.Point(307, 421);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormInputs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(421, 470);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.listProviders);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "FormInputs";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inputs";
            ((System.ComponentModel.ISupportInitialize)(this.listProviders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView listProviders;
        private System.Windows.Forms.Button btnClose;
        private BrightIdeasSoftware.OLVColumn olvcInput;
        private BrightIdeasSoftware.OLVColumn olvcDataTypes;
    }
}