namespace TargetAnalyser
{
    partial class FormExtendedInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExtendedInfo));
            this.textExtendedInfo = new System.Windows.Forms.RichTextBox();
            this.butClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textExtendedInfo
            // 
            this.textExtendedInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textExtendedInfo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textExtendedInfo.Location = new System.Drawing.Point(14, 12);
            this.textExtendedInfo.Name = "textExtendedInfo";
            this.textExtendedInfo.ReadOnly = true;
            this.textExtendedInfo.Size = new System.Drawing.Size(621, 408);
            this.textExtendedInfo.TabIndex = 0;
            this.textExtendedInfo.Text = "";
            // 
            // butClose
            // 
            this.butClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butClose.Location = new System.Drawing.Point(535, 434);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(100, 35);
            this.butClose.TabIndex = 1;
            this.butClose.Text = "Close";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // FormExtendedInfo
            // 
            this.AcceptButton = this.butClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butClose;
            this.ClientSize = new System.Drawing.Size(650, 481);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.textExtendedInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "FormExtendedInfo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Extended Information";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox textExtendedInfo;
        private System.Windows.Forms.Button butClose;
    }
}