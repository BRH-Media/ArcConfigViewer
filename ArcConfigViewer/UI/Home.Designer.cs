using System.Windows.Forms;

namespace ArcConfigViewer.UI
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
            this.itmElfDecryptionKey = new System.Windows.Forms.ToolStripMenuItem();
            this.itmModem = new System.Windows.Forms.ToolStripMenuItem();
            this.itmAuthentication = new System.Windows.Forms.ToolStripMenuItem();
            this.itmAuthenticateGrant = new System.Windows.Forms.ToolStripMenuItem();
            this.itmTryDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.itmAuthenticateRevoke = new System.Windows.Forms.ToolStripMenuItem();
            this.itmOperation = new System.Windows.Forms.ToolStripMenuItem();
            this.itmFetchConnectedDevicesList = new System.Windows.Forms.ToolStripMenuItem();
            this.itmFetchFromModem = new System.Windows.Forms.ToolStripMenuItem();
            this.itmFetchCallLog = new System.Windows.Forms.ToolStripMenuItem();
            this.itmFetchSystemLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.itmFirmwareVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExploits = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExploitTelnet = new System.Windows.Forms.ToolStripMenuItem();
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
            this.itmModem,
            this.itmSearch,
            this.itmRefreshConfig,
            this.itmExport});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(800, 24);
            this.menuMain.TabIndex = 1;
            this.menuMain.Text = "menuStrip1";
            this.menuMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuMain_ItemClicked);
            // 
            // itmFile
            // 
            this.itmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmFileOpenConfig,
            this.itmElfDecryptionKey});
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
            // itmElfDecryptionKey
            // 
            this.itmElfDecryptionKey.Enabled = false;
            this.itmElfDecryptionKey.Name = "itmElfDecryptionKey";
            this.itmElfDecryptionKey.Size = new System.Drawing.Size(185, 22);
            this.itmElfDecryptionKey.Text = "ELF Decryption Key";
            this.itmElfDecryptionKey.Click += new System.EventHandler(this.ItmElfDecryptionKey_Click);
            // 
            // itmModem
            // 
            this.itmModem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmAuthentication,
            this.itmOperation,
            this.itmFirmwareVersion,
            this.itmExploits});
            this.itmModem.Name = "itmModem";
            this.itmModem.Size = new System.Drawing.Size(61, 20);
            this.itmModem.Text = "Modem";
            // 
            // itmAuthentication
            // 
            this.itmAuthentication.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmAuthenticateGrant,
            this.itmTryDefault,
            this.itmAuthenticateRevoke});
            this.itmAuthentication.Name = "itmAuthentication";
            this.itmAuthentication.Size = new System.Drawing.Size(164, 22);
            this.itmAuthentication.Text = "Authentication";
            // 
            // itmAuthenticateGrant
            // 
            this.itmAuthenticateGrant.Name = "itmAuthenticateGrant";
            this.itmAuthenticateGrant.Size = new System.Drawing.Size(130, 22);
            this.itmAuthenticateGrant.Text = "Login";
            this.itmAuthenticateGrant.Click += new System.EventHandler(this.ItmAuthenticateGrant_Click);
            // 
            // itmTryDefault
            // 
            this.itmTryDefault.Name = "itmTryDefault";
            this.itmTryDefault.Size = new System.Drawing.Size(130, 22);
            this.itmTryDefault.Text = "Try Default";
            this.itmTryDefault.Click += new System.EventHandler(this.ItmTryDefault_Click);
            // 
            // itmAuthenticateRevoke
            // 
            this.itmAuthenticateRevoke.Enabled = false;
            this.itmAuthenticateRevoke.Name = "itmAuthenticateRevoke";
            this.itmAuthenticateRevoke.Size = new System.Drawing.Size(130, 22);
            this.itmAuthenticateRevoke.Text = "Logout";
            this.itmAuthenticateRevoke.Click += new System.EventHandler(this.ItmAuthenticateRevoke_Click);
            // 
            // itmOperation
            // 
            this.itmOperation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmFetchConnectedDevicesList,
            this.itmFetchFromModem,
            this.itmFetchCallLog,
            this.itmFetchSystemLogs});
            this.itmOperation.Name = "itmOperation";
            this.itmOperation.Size = new System.Drawing.Size(164, 22);
            this.itmOperation.Text = "Operation";
            // 
            // itmFetchConnectedDevicesList
            // 
            this.itmFetchConnectedDevicesList.Name = "itmFetchConnectedDevicesList";
            this.itmFetchConnectedDevicesList.Size = new System.Drawing.Size(228, 22);
            this.itmFetchConnectedDevicesList.Text = "Fetch Connected Devices List";
            this.itmFetchConnectedDevicesList.Click += new System.EventHandler(this.ItmConnectedDevicesList_Click);
            // 
            // itmFetchFromModem
            // 
            this.itmFetchFromModem.Name = "itmFetchFromModem";
            this.itmFetchFromModem.Size = new System.Drawing.Size(228, 22);
            this.itmFetchFromModem.Text = "Fetch Config From Modem";
            this.itmFetchFromModem.Click += new System.EventHandler(this.ItmFetchFromModem_Click);
            // 
            // itmFetchCallLog
            // 
            this.itmFetchCallLog.Name = "itmFetchCallLog";
            this.itmFetchCallLog.Size = new System.Drawing.Size(228, 22);
            this.itmFetchCallLog.Text = "Fetch Call Log";
            this.itmFetchCallLog.Click += new System.EventHandler(this.ItmCallLog_Click);
            // 
            // itmFetchSystemLogs
            // 
            this.itmFetchSystemLogs.Name = "itmFetchSystemLogs";
            this.itmFetchSystemLogs.Size = new System.Drawing.Size(228, 22);
            this.itmFetchSystemLogs.Text = "Fetch System Logs";
            this.itmFetchSystemLogs.Click += new System.EventHandler(this.ItmFetchSystemLogs_Click);
            // 
            // itmFirmwareVersion
            // 
            this.itmFirmwareVersion.Name = "itmFirmwareVersion";
            this.itmFirmwareVersion.Size = new System.Drawing.Size(164, 22);
            this.itmFirmwareVersion.Text = "Firmware Version";
            this.itmFirmwareVersion.Click += new System.EventHandler(this.ItmFirmwareVersion_Click);
            // 
            // itmExploits
            // 
            this.itmExploits.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmExploitTelnet});
            this.itmExploits.Name = "itmExploits";
            this.itmExploits.Size = new System.Drawing.Size(164, 22);
            this.itmExploits.Text = "Exploits";
            this.itmExploits.Click += new System.EventHandler(this.ItmExploits_Click);
            // 
            // itmExploitTelnet
            // 
            this.itmExploitTelnet.Name = "itmExploitTelnet";
            this.itmExploitTelnet.Size = new System.Drawing.Size(105, 22);
            this.itmExploitTelnet.Text = "Telnet";
            this.itmExploitTelnet.Click += new System.EventHandler(this.ItmExploitTelnet_Click);
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
            this.dgvMain.RowHeadersVisible = false;
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
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private ToolStripMenuItem itmModem;
        private ToolStripMenuItem itmFetchConnectedDevicesList;
        private ToolStripMenuItem itmFetchFromModem;
        private ToolStripMenuItem itmFetchCallLog;
        private ToolStripMenuItem itmAuthentication;
        private ToolStripMenuItem itmAuthenticateGrant;
        private ToolStripMenuItem itmAuthenticateRevoke;
        private ToolStripMenuItem itmTryDefault;
        private ToolStripMenuItem itmElfDecryptionKey;
        private ToolStripMenuItem itmExploits;
        private ToolStripMenuItem itmFetchSystemLogs;
        private ToolStripMenuItem itmOperation;
        private ToolStripMenuItem itmExploitTelnet;
        private ToolStripMenuItem itmFirmwareVersion;
    }
}

