using System;
using System.Windows.Forms;

namespace ArcConfigViewer
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.itmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.itmFileOpenConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.itmNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.itmConnectedDevicesList = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.itmRefreshConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExport = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExportJson = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExportXml = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExportCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExportCfg = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdRouterConfiguration = new System.Windows.Forms.OpenFileDialog();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.trvMain = new System.Windows.Forms.TreeView();
            this.imgMain = new System.Windows.Forms.ImageList(this.components);
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lnkCopy = new System.Windows.Forms.LinkLabel();
            this.txtMain = new System.Windows.Forms.RichTextBox();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.sfdExport = new System.Windows.Forms.SaveFileDialog();
            this.itmFetchFromModem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmFile,
            this.itmNetwork,
            this.itmSearch,
            this.itmRefreshConfig,
            this.itmExport});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(800, 24);
            this.menuMain.TabIndex = 1;
            this.menuMain.Text = "menuStrip1";
            // 
            // itmFile
            // 
            this.itmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmFileOpenConfig});
            this.itmFile.Name = "itmFile";
            this.itmFile.Size = new System.Drawing.Size(37, 20);
            this.itmFile.Text = "File";
            // 
            // itmFileOpenConfig
            // 
            this.itmFileOpenConfig.Name = "itmFileOpenConfig";
            this.itmFileOpenConfig.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.itmFileOpenConfig.Size = new System.Drawing.Size(185, 22);
            this.itmFileOpenConfig.Text = "Open Config";
            this.itmFileOpenConfig.Click += new System.EventHandler(this.ItmFileOpenConfig_Click);
            // 
            // itmNetwork
            // 
            this.itmNetwork.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmConnectedDevicesList,
            this.itmFetchFromModem});
            this.itmNetwork.Name = "itmNetwork";
            this.itmNetwork.Size = new System.Drawing.Size(64, 20);
            this.itmNetwork.Text = "Network";
            // 
            // itmConnectedDevicesList
            // 
            this.itmConnectedDevicesList.Name = "itmConnectedDevicesList";
            this.itmConnectedDevicesList.Size = new System.Drawing.Size(224, 22);
            this.itmConnectedDevicesList.Text = "Grab Connected Devices List";
            this.itmConnectedDevicesList.Click += new System.EventHandler(this.ItmConnectedDevicesList_Click);
            // 
            // itmSearch
            // 
            this.itmSearch.Enabled = false;
            this.itmSearch.Name = "itmSearch";
            this.itmSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.itmSearch.Size = new System.Drawing.Size(54, 20);
            this.itmSearch.Text = "Search";
            this.itmSearch.Click += new System.EventHandler(this.ItmSearch_Click);
            // 
            // itmRefreshConfig
            // 
            this.itmRefreshConfig.Enabled = false;
            this.itmRefreshConfig.Name = "itmRefreshConfig";
            this.itmRefreshConfig.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.itmRefreshConfig.Size = new System.Drawing.Size(94, 20);
            this.itmRefreshConfig.Text = "Reload Config";
            this.itmRefreshConfig.Click += new System.EventHandler(this.ItmRefreshConfig_Click);
            // 
            // itmExport
            // 
            this.itmExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmExportJson,
            this.itmExportXml,
            this.itmExportCsv,
            this.itmExportCfg});
            this.itmExport.Enabled = false;
            this.itmExport.Name = "itmExport";
            this.itmExport.Size = new System.Drawing.Size(53, 20);
            this.itmExport.Text = "Export";
            // 
            // itmExportJson
            // 
            this.itmExportJson.Name = "itmExportJson";
            this.itmExportJson.Size = new System.Drawing.Size(102, 22);
            this.itmExportJson.Text = "JSON";
            this.itmExportJson.Click += new System.EventHandler(this.ItmExportJson_Click);
            // 
            // itmExportXml
            // 
            this.itmExportXml.Name = "itmExportXml";
            this.itmExportXml.Size = new System.Drawing.Size(102, 22);
            this.itmExportXml.Text = "XML";
            this.itmExportXml.Click += new System.EventHandler(this.ItmExportXml_Click);
            // 
            // itmExportCsv
            // 
            this.itmExportCsv.Name = "itmExportCsv";
            this.itmExportCsv.Size = new System.Drawing.Size(102, 22);
            this.itmExportCsv.Text = "CSV";
            this.itmExportCsv.Click += new System.EventHandler(this.ItmExportCsv_Click);
            // 
            // itmExportCfg
            // 
            this.itmExportCfg.Name = "itmExportCfg";
            this.itmExportCfg.Size = new System.Drawing.Size(102, 22);
            this.itmExportCfg.Text = "CFG";
            this.itmExportCfg.Click += new System.EventHandler(this.ItmExportCfg_Click);
            // 
            // ofdRouterConfiguration
            // 
            this.ofdRouterConfiguration.Filter = "LH1000 Config File|*.cfg";
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.trvMain, 0, 0);
            this.tlpMain.Controls.Add(this.pnlMain, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 24);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Size = new System.Drawing.Size(800, 426);
            this.tlpMain.TabIndex = 2;
            // 
            // trvMain
            // 
            this.trvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvMain.ImageIndex = 0;
            this.trvMain.ImageList = this.imgMain;
            this.trvMain.Location = new System.Drawing.Point(3, 3);
            this.trvMain.Name = "trvMain";
            this.tlpMain.SetRowSpan(this.trvMain, 2);
            this.trvMain.SelectedImageIndex = 0;
            this.trvMain.Size = new System.Drawing.Size(203, 420);
            this.trvMain.TabIndex = 0;
            this.trvMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TrvMain_AfterSelect);
            // 
            // imgMain
            // 
            this.imgMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgMain.ImageStream")));
            this.imgMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imgMain.Images.SetKeyName(0, "File");
            this.imgMain.Images.SetKeyName(1, "Folder");
            this.imgMain.Images.SetKeyName(2, "Config");
            this.imgMain.Images.SetKeyName(3, "Database");
            this.imgMain.Images.SetKeyName(4, "Metadata");
            this.imgMain.Images.SetKeyName(5, "Keyfile");
            this.imgMain.Images.SetKeyName(6, "Certificate");
            this.imgMain.Images.SetKeyName(7, "Executable");
            this.imgMain.Images.SetKeyName(8, "Script");
            // 
            // pnlMain
            // 
            this.tlpMain.SetColumnSpan(this.pnlMain, 2);
            this.pnlMain.Controls.Add(this.lnkCopy);
            this.pnlMain.Controls.Add(this.txtMain);
            this.pnlMain.Controls.Add(this.dgvMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(212, 3);
            this.pnlMain.Name = "pnlMain";
            this.tlpMain.SetRowSpan(this.pnlMain, 2);
            this.pnlMain.Size = new System.Drawing.Size(585, 420);
            this.pnlMain.TabIndex = 1;
            // 
            // lnkCopy
            // 
            this.lnkCopy.AutoSize = true;
            this.lnkCopy.LinkColor = System.Drawing.Color.Blue;
            this.lnkCopy.Location = new System.Drawing.Point(545, 401);
            this.lnkCopy.Name = "lnkCopy";
            this.lnkCopy.Size = new System.Drawing.Size(31, 13);
            this.lnkCopy.TabIndex = 5;
            this.lnkCopy.TabStop = true;
            this.lnkCopy.Text = "Copy";
            this.lnkCopy.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lnkCopy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkCopy_LinkClicked);
            // 
            // txtMain
            // 
            this.txtMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMain.Location = new System.Drawing.Point(0, 0);
            this.txtMain.Name = "txtMain";
            this.txtMain.ReadOnly = true;
            this.txtMain.Size = new System.Drawing.Size(585, 420);
            this.txtMain.TabIndex = 3;
            this.txtMain.Text = "";
            this.txtMain.Resize += new System.EventHandler(this.TxtMain_Resize);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToResizeRows = false;
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMain.Location = new System.Drawing.Point(0, 0);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.ShowCellErrors = false;
            this.dgvMain.ShowCellToolTips = false;
            this.dgvMain.ShowEditingIcon = false;
            this.dgvMain.ShowRowErrors = false;
            this.dgvMain.Size = new System.Drawing.Size(585, 420);
            this.dgvMain.TabIndex = 4;
            this.dgvMain.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DoubleClickProcessor);
            // 
            // sfdExport
            // 
            this.sfdExport.Title = "Export Configuration";
            // 
            // itmFetchFromModem
            // 
            this.itmFetchFromModem.Name = "itmFetchFromModem";
            this.itmFetchFromModem.Size = new System.Drawing.Size(224, 22);
            this.itmFetchFromModem.Text = "Fetch Config From Modem";
            this.itmFetchFromModem.Click += new System.EventHandler(this.ItmFetchFromModem_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LH1000 Configuration Viewer";
            this.Load += new System.EventHandler(this.Home_Load);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem itmFile;
        private System.Windows.Forms.ToolStripMenuItem itmRefreshConfig;
        private System.Windows.Forms.ToolStripMenuItem itmExport;
        private System.Windows.Forms.ToolStripMenuItem itmExportJson;
        private System.Windows.Forms.ToolStripMenuItem itmExportXml;
        private System.Windows.Forms.ToolStripMenuItem itmExportCsv;
        private System.Windows.Forms.ToolStripMenuItem itmExportCfg;
        private System.Windows.Forms.ToolStripMenuItem itmFileOpenConfig;
        private System.Windows.Forms.OpenFileDialog ofdRouterConfiguration;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TreeView trvMain;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.RichTextBox txtMain;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.SaveFileDialog sfdExport;
        private System.Windows.Forms.LinkLabel lnkCopy;
        private System.Windows.Forms.ImageList imgMain;
        private System.Windows.Forms.ToolStripMenuItem itmSearch;
        private ToolStripMenuItem itmNetwork;
        private ToolStripMenuItem itmConnectedDevicesList;
        private ToolStripMenuItem itmFetchFromModem;
    }
}

