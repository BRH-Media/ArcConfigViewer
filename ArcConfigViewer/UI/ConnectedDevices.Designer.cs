namespace ArcConfigViewer.UI
{
    partial class ConnectedDevices
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
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.lblAvgLinkRate = new System.Windows.Forms.ToolStripLabel();
            this.lblAvgLinkRateValue = new System.Windows.Forms.ToolStripLabel();
            this.sepAvgLinkRate = new System.Windows.Forms.ToolStripSeparator();
            this.lblViewing = new System.Windows.Forms.ToolStripLabel();
            this.lblViewingValue = new System.Windows.Forms.ToolStripLabel();
            this.sepViewing = new System.Windows.Forms.ToolStripSeparator();
            this.lblOfflineCount = new System.Windows.Forms.ToolStripLabel();
            this.lblOffline = new System.Windows.Forms.ToolStripLabel();
            this.sepOfflineOnline = new System.Windows.Forms.ToolStripSeparator();
            this.lblOnlineCount = new System.Windows.Forms.ToolStripLabel();
            this.lblOnline = new System.Windows.Forms.ToolStripLabel();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.itmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExport = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExportJSON = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExportXML = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.cxtIncludeOffline = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmAvgOnlineOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.lblOnlinePerc = new System.Windows.Forms.ToolStripLabel();
            this.sepOnlineOfflinePerc = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.tsMain.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.cxtIncludeOffline.SuspendLayout();
            this.SuspendLayout();
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
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.ShowCellErrors = false;
            this.dgvMain.ShowCellToolTips = false;
            this.dgvMain.ShowEditingIcon = false;
            this.dgvMain.ShowRowErrors = false;
            this.dgvMain.Size = new System.Drawing.Size(1264, 632);
            this.dgvMain.TabIndex = 6;
            // 
            // tsMain
            // 
            this.tsMain.ContextMenuStrip = this.cxtIncludeOffline;
            this.tsMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblAvgLinkRate,
            this.lblAvgLinkRateValue,
            this.sepAvgLinkRate,
            this.lblViewing,
            this.lblViewingValue,
            this.sepViewing,
            this.lblOnlinePerc,
            this.sepOnlineOfflinePerc,
            this.lblOfflineCount,
            this.lblOffline,
            this.sepOfflineOnline,
            this.lblOnlineCount,
            this.lblOnline});
            this.tsMain.Location = new System.Drawing.Point(0, 656);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1264, 25);
            this.tsMain.TabIndex = 7;
            this.tsMain.Text = "toolStrip1";
            // 
            // lblAvgLinkRate
            // 
            this.lblAvgLinkRate.Name = "lblAvgLinkRate";
            this.lblAvgLinkRate.Size = new System.Drawing.Size(104, 22);
            this.lblAvgLinkRate.Text = "Average Link Rate:";
            // 
            // lblAvgLinkRateValue
            // 
            this.lblAvgLinkRateValue.Name = "lblAvgLinkRateValue";
            this.lblAvgLinkRateValue.Size = new System.Drawing.Size(58, 22);
            this.lblAvgLinkRateValue.Text = "Unknown";
            // 
            // sepAvgLinkRate
            // 
            this.sepAvgLinkRate.Name = "sepAvgLinkRate";
            this.sepAvgLinkRate.Size = new System.Drawing.Size(6, 25);
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
            // sepViewing
            // 
            this.sepViewing.Name = "sepViewing";
            this.sepViewing.Size = new System.Drawing.Size(6, 25);
            // 
            // lblOfflineCount
            // 
            this.lblOfflineCount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblOfflineCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOfflineCount.Name = "lblOfflineCount";
            this.lblOfflineCount.Size = new System.Drawing.Size(13, 22);
            this.lblOfflineCount.Text = "0";
            // 
            // lblOffline
            // 
            this.lblOffline.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblOffline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.lblOffline.ForeColor = System.Drawing.Color.DarkRed;
            this.lblOffline.Name = "lblOffline";
            this.lblOffline.Size = new System.Drawing.Size(43, 22);
            this.lblOffline.Text = "Offline";
            // 
            // sepOfflineOnline
            // 
            this.sepOfflineOnline.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sepOfflineOnline.Name = "sepOfflineOnline";
            this.sepOfflineOnline.Size = new System.Drawing.Size(6, 25);
            // 
            // lblOnlineCount
            // 
            this.lblOnlineCount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblOnlineCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOnlineCount.Name = "lblOnlineCount";
            this.lblOnlineCount.Size = new System.Drawing.Size(13, 22);
            this.lblOnlineCount.Text = "0";
            // 
            // lblOnline
            // 
            this.lblOnline.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblOnline.ForeColor = System.Drawing.Color.Green;
            this.lblOnline.Name = "lblOnline";
            this.lblOnline.Size = new System.Drawing.Size(42, 22);
            this.lblOnline.Text = "Online";
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmFile,
            this.itmSearch});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1264, 24);
            this.menuMain.TabIndex = 8;
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
            this.itmExportCSV,
            this.itmExportJSON,
            this.itmExportXML});
            this.itmExport.Name = "itmExport";
            this.itmExport.Size = new System.Drawing.Size(108, 22);
            this.itmExport.Text = "Export";
            // 
            // itmExportCSV
            // 
            this.itmExportCSV.Name = "itmExportCSV";
            this.itmExportCSV.Size = new System.Drawing.Size(102, 22);
            this.itmExportCSV.Text = "CSV";
            this.itmExportCSV.Click += new System.EventHandler(this.ItmExportCSV_Click);
            // 
            // itmExportJSON
            // 
            this.itmExportJSON.Name = "itmExportJSON";
            this.itmExportJSON.Size = new System.Drawing.Size(102, 22);
            this.itmExportJSON.Text = "JSON";
            this.itmExportJSON.Click += new System.EventHandler(this.ItmExportJSON_Click);
            // 
            // itmExportXML
            // 
            this.itmExportXML.Name = "itmExportXML";
            this.itmExportXML.Size = new System.Drawing.Size(102, 22);
            this.itmExportXML.Text = "XML";
            this.itmExportXML.Click += new System.EventHandler(this.ItmExportXML_Click);
            // 
            // itmSearch
            // 
            this.itmSearch.Name = "itmSearch";
            this.itmSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.itmSearch.Size = new System.Drawing.Size(54, 20);
            this.itmSearch.Text = "Search";
            this.itmSearch.Click += new System.EventHandler(this.ItmSearch_Click);
            // 
            // cxtIncludeOffline
            // 
            this.cxtIncludeOffline.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmAvgOnlineOnly});
            this.cxtIncludeOffline.Name = "cxtIncludeOffline";
            this.cxtIncludeOffline.Size = new System.Drawing.Size(165, 26);
            // 
            // itmAvgOnlineOnly
            // 
            this.itmAvgOnlineOnly.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.itmAvgOnlineOnly.Checked = true;
            this.itmAvgOnlineOnly.CheckOnClick = true;
            this.itmAvgOnlineOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.itmAvgOnlineOnly.Name = "itmAvgOnlineOnly";
            this.itmAvgOnlineOnly.Size = new System.Drawing.Size(164, 22);
            this.itmAvgOnlineOnly.Text = "Avg. Online Only";
            this.itmAvgOnlineOnly.Click += new System.EventHandler(this.ItmAvgOnlineOnly_Click);
            // 
            // lblOnlinePerc
            // 
            this.lblOnlinePerc.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblOnlinePerc.Name = "lblOnlinePerc";
            this.lblOnlinePerc.Size = new System.Drawing.Size(38, 22);
            this.lblOnlinePerc.Text = "0.00%";
            // 
            // sepOnlineOfflinePerc
            // 
            this.sepOnlineOfflinePerc.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sepOnlineOfflinePerc.Name = "sepOnlineOfflinePerc";
            this.sepOnlineOfflinePerc.Size = new System.Drawing.Size(6, 25);
            // 
            // ConnectedDevices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.MinimizeBox = false;
            this.Name = "ConnectedDevices";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connected Devices";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ConnectedDevices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.cxtIncludeOffline.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem itmFile;
        private System.Windows.Forms.ToolStripMenuItem itmSearch;
        private System.Windows.Forms.ToolStripMenuItem itmExport;
        private System.Windows.Forms.ToolStripMenuItem itmExportCSV;
        private System.Windows.Forms.ToolStripMenuItem itmExportJSON;
        private System.Windows.Forms.ToolStripMenuItem itmExportXML;
        private System.Windows.Forms.ToolStripLabel lblAvgLinkRate;
        private System.Windows.Forms.ToolStripLabel lblAvgLinkRateValue;
        private System.Windows.Forms.ToolStripSeparator sepAvgLinkRate;
        private System.Windows.Forms.ToolStripLabel lblViewing;
        private System.Windows.Forms.ToolStripLabel lblViewingValue;
        private System.Windows.Forms.ToolStripSeparator sepViewing;
        private System.Windows.Forms.ToolStripLabel lblOffline;
        private System.Windows.Forms.ToolStripLabel lblOfflineCount;
        private System.Windows.Forms.ToolStripSeparator sepOfflineOnline;
        private System.Windows.Forms.ToolStripLabel lblOnline;
        private System.Windows.Forms.ToolStripLabel lblOnlineCount;
        private System.Windows.Forms.ContextMenuStrip cxtIncludeOffline;
        private System.Windows.Forms.ToolStripMenuItem itmAvgOnlineOnly;
        private System.Windows.Forms.ToolStripLabel lblOnlinePerc;
        private System.Windows.Forms.ToolStripSeparator sepOnlineOfflinePerc;
    }
}