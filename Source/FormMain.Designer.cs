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
            this.menuFileExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExportCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExportJson = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExportXml = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsProviders = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuToolsOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuToolsReloadInputs = new System.Windows.Forms.ToolStripMenuItem();
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
            this.olvcHasExtended = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcUrl1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvUrl2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.context = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextExtended = new System.Windows.Forms.ToolStripMenuItem();
            this.contextResponse = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.contextGoToUrl1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextGoToUrl2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextCopyInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuToolsUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listResults)).BeginInit();
            this.context.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuTools,
            this.menuHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(701, 33);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileExport,
            this.toolStripMenuItem1,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(50, 29);
            this.menuFile.Text = "File";
            // 
            // menuFileExport
            // 
            this.menuFileExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileExportCsv,
            this.menuFileExportJson,
            this.menuFileExportXml});
            this.menuFileExport.Name = "menuFileExport";
            this.menuFileExport.Size = new System.Drawing.Size(148, 30);
            this.menuFileExport.Text = "Export";
            // 
            // menuFileExportCsv
            // 
            this.menuFileExportCsv.Name = "menuFileExportCsv";
            this.menuFileExportCsv.Size = new System.Drawing.Size(140, 30);
            this.menuFileExportCsv.Text = "CSV";
            this.menuFileExportCsv.Click += new System.EventHandler(this.menuFileExportCsv_Click);
            // 
            // menuFileExportJson
            // 
            this.menuFileExportJson.Name = "menuFileExportJson";
            this.menuFileExportJson.Size = new System.Drawing.Size(140, 30);
            this.menuFileExportJson.Text = "JSON";
            this.menuFileExportJson.Click += new System.EventHandler(this.menuFileExportJson_Click);
            // 
            // menuFileExportXml
            // 
            this.menuFileExportXml.Name = "menuFileExportXml";
            this.menuFileExportXml.Size = new System.Drawing.Size(140, 30);
            this.menuFileExportXml.Text = "XML";
            this.menuFileExportXml.Click += new System.EventHandler(this.menuFileExportXml_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(145, 6);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(148, 30);
            this.menuFileExit.Text = "Exit";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolsProviders,
            this.toolStripMenuItem2,
            this.menuToolsOptions,
            this.toolStripMenuItem3,
            this.menuToolsReloadInputs,
            this.toolStripMenuItem5,
            this.menuToolsUpdate});
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(65, 29);
            this.menuTools.Text = "Tools";
            // 
            // menuToolsProviders
            // 
            this.menuToolsProviders.Name = "menuToolsProviders";
            this.menuToolsProviders.Size = new System.Drawing.Size(281, 30);
            this.menuToolsProviders.Text = "Providers";
            this.menuToolsProviders.Click += new System.EventHandler(this.menuToolsProviders_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(278, 6);
            // 
            // menuToolsOptions
            // 
            this.menuToolsOptions.Name = "menuToolsOptions";
            this.menuToolsOptions.Size = new System.Drawing.Size(281, 30);
            this.menuToolsOptions.Text = "Options";
            this.menuToolsOptions.Click += new System.EventHandler(this.menuToolsOptions_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(278, 6);
            // 
            // menuToolsReloadInputs
            // 
            this.menuToolsReloadInputs.Name = "menuToolsReloadInputs";
            this.menuToolsReloadInputs.Size = new System.Drawing.Size(281, 30);
            this.menuToolsReloadInputs.Text = "Reload Inputs/API Keys";
            this.menuToolsReloadInputs.Click += new System.EventHandler(this.menuToolsReloadInputs_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(61, 29);
            this.menuHelp.Text = "Help";
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Name = "menuHelpAbout";
            this.menuHelpAbout.Size = new System.Drawing.Size(147, 30);
            this.menuHelpAbout.Text = "About";
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtTarget,
            this.toolStripSeparator1,
            this.cboTargetType,
            this.btnSearch});
            this.toolStrip.Location = new System.Drawing.Point(0, 33);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(701, 33);
            this.toolStrip.TabIndex = 0;
            // 
            // txtTarget
            // 
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(300, 33);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // cboTargetType
            // 
            this.cboTargetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTargetType.Items.AddRange(new object[] {
            "IP",
            "Domain",
            "Domain/URL",
            "URL",
            "MD5"});
            this.cboTargetType.Name = "cboTargetType";
            this.cboTargetType.Size = new System.Drawing.Size(121, 33);
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(28, 30);
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 355);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(701, 22);
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
            this.listResults.AllColumns.Add(this.olvcHasExtended);
            this.listResults.AllColumns.Add(this.olvcUrl1);
            this.listResults.AllColumns.Add(this.olvUrl2);
            this.listResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcSource,
            this.olvcResult,
            this.olvcHasExtended,
            this.olvcUrl1,
            this.olvUrl2});
            this.listResults.ContextMenuStrip = this.context;
            this.listResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listResults.FullRowSelect = true;
            this.listResults.HideSelection = false;
            this.listResults.Location = new System.Drawing.Point(0, 66);
            this.listResults.MultiSelect = false;
            this.listResults.Name = "listResults";
            this.listResults.ShowGroups = false;
            this.listResults.Size = new System.Drawing.Size(701, 289);
            this.listResults.TabIndex = 2;
            this.listResults.UseCompatibleStateImageBehavior = false;
            this.listResults.View = System.Windows.Forms.View.Details;
            this.listResults.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listResults_MouseDoubleClick);
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
            // olvcHasExtended
            // 
            this.olvcHasExtended.AspectName = "HasExtended";
            this.olvcHasExtended.CellPadding = null;
            this.olvcHasExtended.Text = "Has Extended";
            this.olvcHasExtended.Width = 132;
            // 
            // olvcUrl1
            // 
            this.olvcUrl1.AspectName = "Url";
            this.olvcUrl1.CellPadding = null;
            this.olvcUrl1.Text = "URL 1";
            this.olvcUrl1.Width = 101;
            // 
            // olvUrl2
            // 
            this.olvUrl2.AspectName = "FullUrl";
            this.olvUrl2.CellPadding = null;
            this.olvUrl2.Text = "URL 2";
            // 
            // context
            // 
            this.context.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.context.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextExtended,
            this.contextResponse,
            this.toolStripMenuItem4,
            this.contextGoToUrl1,
            this.contextGoToUrl2,
            this.contextSep1,
            this.contextCopyInfo});
            this.context.Name = "context";
            this.context.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.context.Size = new System.Drawing.Size(270, 166);
            this.context.Opening += new System.ComponentModel.CancelEventHandler(this.context_Opening);
            // 
            // contextExtended
            // 
            this.contextExtended.Name = "contextExtended";
            this.contextExtended.Size = new System.Drawing.Size(269, 30);
            this.contextExtended.Text = "Extended Information";
            this.contextExtended.Click += new System.EventHandler(this.contextExtended_Click);
            // 
            // contextResponse
            // 
            this.contextResponse.Name = "contextResponse";
            this.contextResponse.Size = new System.Drawing.Size(269, 30);
            this.contextResponse.Text = "Response";
            this.contextResponse.Click += new System.EventHandler(this.contextResponse_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(266, 6);
            // 
            // contextGoToUrl1
            // 
            this.contextGoToUrl1.Name = "contextGoToUrl1";
            this.contextGoToUrl1.Size = new System.Drawing.Size(269, 30);
            this.contextGoToUrl1.Text = "Go To URL 1";
            this.contextGoToUrl1.Click += new System.EventHandler(this.contextGoToUrl1_Click);
            // 
            // contextGoToUrl2
            // 
            this.contextGoToUrl2.Name = "contextGoToUrl2";
            this.contextGoToUrl2.Size = new System.Drawing.Size(269, 30);
            this.contextGoToUrl2.Text = "Go To URL 2";
            this.contextGoToUrl2.Click += new System.EventHandler(this.contextGoToUrl2_Click);
            // 
            // contextSep1
            // 
            this.contextSep1.Name = "contextSep1";
            this.contextSep1.Size = new System.Drawing.Size(266, 6);
            // 
            // contextCopyInfo
            // 
            this.contextCopyInfo.Name = "contextCopyInfo";
            this.contextCopyInfo.Size = new System.Drawing.Size(269, 30);
            this.contextCopyInfo.Text = "Copy Info";
            this.contextCopyInfo.Click += new System.EventHandler(this.contextCopyInfo_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(278, 6);
            // 
            // menuToolsUpdate
            // 
            this.menuToolsUpdate.Name = "menuToolsUpdate";
            this.menuToolsUpdate.Size = new System.Drawing.Size(281, 30);
            this.menuToolsUpdate.Text = "Update Inputs";
            this.menuToolsUpdate.Click += new System.EventHandler(this.menuToolsUpdate_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 377);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
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
        private System.Windows.Forms.ToolStripMenuItem contextGoToUrl1;
        private System.Windows.Forms.ToolStripMenuItem contextGoToUrl2;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
        private System.Windows.Forms.ToolStripMenuItem menuToolsProviders;
        private System.Windows.Forms.ToolStripMenuItem menuFileExport;
        private System.Windows.Forms.ToolStripMenuItem menuFileExportCsv;
        private System.Windows.Forms.ToolStripMenuItem menuFileExportJson;
        private System.Windows.Forms.ToolStripMenuItem menuFileExportXml;
        private BrightIdeasSoftware.OLVColumn olvcUrl1;
        private BrightIdeasSoftware.OLVColumn olvUrl2;
        private System.Windows.Forms.ToolStripSeparator contextSep1;
        private System.Windows.Forms.ToolStripMenuItem contextCopyInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuToolsOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem menuToolsReloadInputs;
        private BrightIdeasSoftware.OLVColumn olvcHasExtended;
        private System.Windows.Forms.ToolStripMenuItem contextExtended;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem contextResponse;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem menuToolsUpdate;
    }
}

