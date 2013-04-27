namespace TargetAnalyser
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.txtTarget = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cboTargetType = new System.Windows.Forms.ToolStripComboBox();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.listResults = new BrightIdeasSoftware.ObjectListView();
            this.olvcSource = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcResult = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.context = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextShow = new System.Windows.Forms.ToolStripMenuItem();
            this.contextShowParent = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listResults)).BeginInit();
            this.context.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(507, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "File";
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(92, 22);
            this.menuFileExit.Text = "Exit";
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(44, 20);
            this.menuHelp.Text = "Help";
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Name = "menuHelpAbout";
            this.menuHelpAbout.Size = new System.Drawing.Size(107, 22);
            this.menuHelpAbout.Text = "About";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtTarget,
            this.toolStripSeparator1,
            this.cboTargetType,
            this.btnSearch});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(507, 25);
            this.toolStrip.TabIndex = 0;
            // 
            // txtTarget
            // 
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(300, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // cboTargetType
            // 
            this.cboTargetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTargetType.Items.AddRange(new object[] {
            "IP",
            "URL",
            "MD5"});
            this.cboTargetType.Name = "cboTargetType";
            this.cboTargetType.Size = new System.Drawing.Size(121, 25);
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 22);
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 275);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(507, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // listResults
            // 
            this.listResults.AllColumns.Add(this.olvcSource);
            this.listResults.AllColumns.Add(this.olvcResult);
            this.listResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcSource,
            this.olvcResult});
            this.listResults.ContextMenuStrip = this.context;
            this.listResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listResults.FullRowSelect = true;
            this.listResults.HideSelection = false;
            this.listResults.Location = new System.Drawing.Point(0, 49);
            this.listResults.MultiSelect = false;
            this.listResults.Name = "listResults";
            this.listResults.ShowGroups = false;
            this.listResults.Size = new System.Drawing.Size(507, 226);
            this.listResults.TabIndex = 2;
            this.listResults.UseCompatibleStateImageBehavior = false;
            this.listResults.View = System.Windows.Forms.View.Details;
            // 
            // olvcSource
            // 
            this.olvcSource.AspectName = "Source";
            this.olvcSource.CellPadding = null;
            this.olvcSource.Text = "Source";
            // 
            // olvcResult
            // 
            this.olvcResult.AspectName = "Info";
            this.olvcResult.CellPadding = null;
            this.olvcResult.Text = "Info";
            // 
            // context
            // 
            this.context.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextShow,
            this.contextShowParent});
            this.context.Name = "context";
            this.context.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.context.Size = new System.Drawing.Size(153, 70);
            // 
            // contextShow
            // 
            this.contextShow.Name = "contextShow";
            this.contextShow.Size = new System.Drawing.Size(152, 22);
            this.contextShow.Text = "Show";
            this.contextShow.Click += new System.EventHandler(this.contextShow_Click);
            // 
            // contextShowParent
            // 
            this.contextShowParent.Name = "contextShowParent";
            this.contextShowParent.Size = new System.Drawing.Size(152, 22);
            this.contextShowParent.Text = "Show Parent";
            this.contextShowParent.Click += new System.EventHandler(this.contextShowParent_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 297);
            this.Controls.Add(this.listResults);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TargetAnalyser";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listResults)).EndInit();
            this.context.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripTextBox txtTarget;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.StatusStrip statusStrip;
        private BrightIdeasSoftware.ObjectListView listResults;
        private BrightIdeasSoftware.OLVColumn olvcSource;
        private BrightIdeasSoftware.OLVColumn olvcResult;
        private System.Windows.Forms.ToolStripComboBox cboTargetType;
        private System.Windows.Forms.ContextMenuStrip context;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem contextShow;
        private System.Windows.Forms.ToolStripMenuItem contextShowParent;
    }
}

