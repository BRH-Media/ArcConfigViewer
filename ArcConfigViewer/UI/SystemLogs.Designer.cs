namespace ArcConfigViewer.UI
{
    partial class SystemLogs
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
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.itmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExport = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExportTXT = new System.Windows.Forms.ToolStripMenuItem();
            this.itmLogType = new System.Windows.Forms.ToolStripMenuItem();
            this.itmLogTypeAll = new System.Windows.Forms.ToolStripMenuItem();
            this.itmLogTypeTR069 = new System.Windows.Forms.ToolStripMenuItem();
            this.itmLogTypeSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.itmLogTypeHardware = new System.Windows.Forms.ToolStripMenuItem();
            this.itmLogTypeVOIP = new System.Windows.Forms.ToolStripMenuItem();
            this.itmLogTypeWAN = new System.Windows.Forms.ToolStripMenuItem();
            this.itmLogTypeWLAN = new System.Windows.Forms.ToolStripMenuItem();
            this.itmLogTypeWiFiBooster = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.lblCurrentLogFile = new System.Windows.Forms.ToolStripLabel();
            this.lblCurrentLogFileValue = new System.Windows.Forms.ToolStripLabel();
            this.sepCurrentLogFile = new System.Windows.Forms.ToolStripSeparator();
            this.lblViewing = new System.Windows.Forms.ToolStripLabel();
            this.lblViewingValue = new System.Windows.Forms.ToolStripLabel();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.menuMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmFile,
            this.itmLogType,
            this.itmSearch});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1264, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // itmFile
            // 
            this.itmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmExport});
            this.itmFile.Name = "itmFile";
            this.itmFile.Size = new System.Drawing.Size(37, 20);
            this.itmFile.Text = "File";
            // 
            // itmExport
            // 
            this.itmExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmExportTXT});
            this.itmExport.Name = "itmExport";
            this.itmExport.Size = new System.Drawing.Size(108, 22);
            this.itmExport.Text = "Export";
            // 
            // itmExportTXT
            // 
            this.itmExportTXT.Name = "itmExportTXT";
            this.itmExportTXT.Size = new System.Drawing.Size(93, 22);
            this.itmExportTXT.Text = "TXT";
            this.itmExportTXT.Click += new System.EventHandler(this.ItmExportTXT_Click);
            // 
            // itmLogType
            // 
            this.itmLogType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmLogTypeAll,
            this.itmLogTypeTR069,
            this.itmLogTypeSystem,
            this.itmLogTypeHardware,
            this.itmLogTypeVOIP,
            this.itmLogTypeWAN,
            this.itmLogTypeWLAN,
            this.itmLogTypeWiFiBooster});
            this.itmLogType.Name = "itmLogType";
            this.itmLogType.Size = new System.Drawing.Size(66, 20);
            this.itmLogType.Text = "Log Type";
            // 
            // itmLogTypeAll
            // 
            this.itmLogTypeAll.Name = "itmLogTypeAll";
            this.itmLogTypeAll.Size = new System.Drawing.Size(145, 22);
            this.itmLogTypeAll.Text = "All";
            this.itmLogTypeAll.Click += new System.EventHandler(this.ItmLogTypeAll_Click);
            // 
            // itmLogTypeTR069
            // 
            this.itmLogTypeTR069.Name = "itmLogTypeTR069";
            this.itmLogTypeTR069.Size = new System.Drawing.Size(145, 22);
            this.itmLogTypeTR069.Text = "TR-069";
            this.itmLogTypeTR069.Click += new System.EventHandler(this.ItmLogTypeTR069_Click);
            // 
            // itmLogTypeSystem
            // 
            this.itmLogTypeSystem.Name = "itmLogTypeSystem";
            this.itmLogTypeSystem.Size = new System.Drawing.Size(145, 22);
            this.itmLogTypeSystem.Text = "System";
            this.itmLogTypeSystem.Click += new System.EventHandler(this.ItmLogTypeSystem_Click);
            // 
            // itmLogTypeHardware
            // 
            this.itmLogTypeHardware.Name = "itmLogTypeHardware";
            this.itmLogTypeHardware.Size = new System.Drawing.Size(145, 22);
            this.itmLogTypeHardware.Text = "Hardware";
            this.itmLogTypeHardware.Click += new System.EventHandler(this.ItmLogTypeHardware_Click);
            // 
            // itmLogTypeVOIP
            // 
            this.itmLogTypeVOIP.Name = "itmLogTypeVOIP";
            this.itmLogTypeVOIP.Size = new System.Drawing.Size(145, 22);
            this.itmLogTypeVOIP.Text = "VOIP";
            this.itmLogTypeVOIP.Click += new System.EventHandler(this.ItmLogTypeVOIP_Click);
            // 
            // itmLogTypeWAN
            // 
            this.itmLogTypeWAN.Name = "itmLogTypeWAN";
            this.itmLogTypeWAN.Size = new System.Drawing.Size(145, 22);
            this.itmLogTypeWAN.Text = "WAN";
            this.itmLogTypeWAN.Click += new System.EventHandler(this.ItmLogTypeWAN_Click);
            // 
            // itmLogTypeWLAN
            // 
            this.itmLogTypeWLAN.Name = "itmLogTypeWLAN";
            this.itmLogTypeWLAN.Size = new System.Drawing.Size(145, 22);
            this.itmLogTypeWLAN.Text = "WLAN";
            this.itmLogTypeWLAN.Click += new System.EventHandler(this.ItmLogTypeWLAN_Click);
            // 
            // itmLogTypeWiFiBooster
            // 
            this.itmLogTypeWiFiBooster.Name = "itmLogTypeWiFiBooster";
            this.itmLogTypeWiFiBooster.Size = new System.Drawing.Size(145, 22);
            this.itmLogTypeWiFiBooster.Text = "Wi-Fi Booster";
            this.itmLogTypeWiFiBooster.Click += new System.EventHandler(this.ItmLogTypeWiFiBooster_Click);
            // 
            // itmSearch
            // 
            this.itmSearch.Name = "itmSearch";
            this.itmSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.itmSearch.Size = new System.Drawing.Size(54, 20);
            this.itmSearch.Text = "Search";
            this.itmSearch.Click += new System.EventHandler(this.ItmSearch_Click);
            // 
            // tsMain
            // 
            this.tsMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCurrentLogFile,
            this.lblCurrentLogFileValue,
            this.sepCurrentLogFile,
            this.lblViewing,
            this.lblViewingValue});
            this.tsMain.Location = new System.Drawing.Point(0, 656);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1264, 25);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // lblCurrentLogFile
            // 
            this.lblCurrentLogFile.Name = "lblCurrentLogFile";
            this.lblCurrentLogFile.Size = new System.Drawing.Size(94, 22);
            this.lblCurrentLogFile.Text = "Current Log File:";
            // 
            // lblCurrentLogFileValue
            // 
            this.lblCurrentLogFileValue.Name = "lblCurrentLogFileValue";
            this.lblCurrentLogFileValue.Size = new System.Drawing.Size(88, 22);
            this.lblCurrentLogFileValue.Text = "No Log Loaded";
            // 
            // sepCurrentLogFile
            // 
            this.sepCurrentLogFile.Name = "sepCurrentLogFile";
            this.sepCurrentLogFile.Size = new System.Drawing.Size(6, 25);
            // 
            // lblViewing
            // 
            this.lblViewing.Name = "lblViewing";
            this.lblViewing.Size = new System.Drawing.Size(52, 22);
            this.lblViewing.Text = "Viewing:";
            // 
            // lblViewingValue
            // 
            this.lblViewingValue.Name = "lblViewingValue";
            this.lblViewingValue.Size = new System.Drawing.Size(24, 22);
            this.lblViewingValue.Text = "0/0";
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToResizeRows = false;
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMain.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMain.Location = new System.Drawing.Point(0, 24);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.ShowCellErrors = false;
            this.dgvMain.ShowCellToolTips = false;
            this.dgvMain.ShowEditingIcon = false;
            this.dgvMain.ShowRowErrors = false;
            this.dgvMain.Size = new System.Drawing.Size(1264, 632);
            this.dgvMain.TabIndex = 6;
            // 
            // SystemLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.MinimizeBox = false;
            this.Name = "SystemLogs";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Logs";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SystemLogs_Load);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem itmFile;
        private System.Windows.Forms.ToolStripMenuItem itmExport;
        private System.Windows.Forms.ToolStripMenuItem itmExportTXT;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripMenuItem itmSearch;
        private System.Windows.Forms.ToolStripLabel lblViewing;
        private System.Windows.Forms.ToolStripLabel lblViewingValue;
        private System.Windows.Forms.ToolStripMenuItem itmLogType;
        private System.Windows.Forms.ToolStripMenuItem itmLogTypeAll;
        private System.Windows.Forms.ToolStripMenuItem itmLogTypeTR069;
        private System.Windows.Forms.ToolStripMenuItem itmLogTypeSystem;
        private System.Windows.Forms.ToolStripMenuItem itmLogTypeHardware;
        private System.Windows.Forms.ToolStripMenuItem itmLogTypeVOIP;
        private System.Windows.Forms.ToolStripMenuItem itmLogTypeWAN;
        private System.Windows.Forms.ToolStripMenuItem itmLogTypeWLAN;
        private System.Windows.Forms.ToolStripMenuItem itmLogTypeWiFiBooster;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.ToolStripSeparator sepCurrentLogFile;
        private System.Windows.Forms.ToolStripLabel lblCurrentLogFile;
        private System.Windows.Forms.ToolStripLabel lblCurrentLogFileValue;
    }
}