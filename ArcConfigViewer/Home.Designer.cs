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
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.itmAuthorise = new System.Windows.Forms.ToolStripMenuItem();
            this.itmRefreshConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExport = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExportJson = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExportXml = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExportRaw = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExportCsv = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMain
            // 
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.Location = new System.Drawing.Point(0, 24);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.Size = new System.Drawing.Size(800, 426);
            this.dgvMain.TabIndex = 0;
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmAuthorise,
            this.itmRefreshConfig,
            this.itmExport});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(800, 24);
            this.menuMain.TabIndex = 1;
            this.menuMain.Text = "menuStrip1";
            // 
            // itmAuthorise
            // 
            this.itmAuthorise.Name = "itmAuthorise";
            this.itmAuthorise.Size = new System.Drawing.Size(70, 20);
            this.itmAuthorise.Text = "Authorise";
            // 
            // itmRefreshConfig
            // 
            this.itmRefreshConfig.Enabled = false;
            this.itmRefreshConfig.Name = "itmRefreshConfig";
            this.itmRefreshConfig.Size = new System.Drawing.Size(97, 20);
            this.itmRefreshConfig.Text = "Refresh Config";
            // 
            // itmExport
            // 
            this.itmExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmExportJson,
            this.itmExportXml,
            this.itmExportCsv,
            this.itmExportRaw});
            this.itmExport.Enabled = false;
            this.itmExport.Name = "itmExport";
            this.itmExport.Size = new System.Drawing.Size(53, 20);
            this.itmExport.Text = "Export";
            // 
            // itmExportJson
            // 
            this.itmExportJson.Name = "itmExportJson";
            this.itmExportJson.Size = new System.Drawing.Size(180, 22);
            this.itmExportJson.Text = "JSON";
            // 
            // itmExportXml
            // 
            this.itmExportXml.Name = "itmExportXml";
            this.itmExportXml.Size = new System.Drawing.Size(180, 22);
            this.itmExportXml.Text = "XML";
            // 
            // itmExportRaw
            // 
            this.itmExportRaw.Name = "itmExportRaw";
            this.itmExportRaw.Size = new System.Drawing.Size(180, 22);
            this.itmExportRaw.Text = "Raw";
            // 
            // itmExportCsv
            // 
            this.itmExportCsv.Name = "itmExportCsv";
            this.itmExportCsv.Size = new System.Drawing.Size(180, 22);
            this.itmExportCsv.Text = "CSV";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "Form1";
            this.Text = "LH1000 Configuration Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem itmAuthorise;
        private System.Windows.Forms.ToolStripMenuItem itmRefreshConfig;
        private System.Windows.Forms.ToolStripMenuItem itmExport;
        private System.Windows.Forms.ToolStripMenuItem itmExportJson;
        private System.Windows.Forms.ToolStripMenuItem itmExportXml;
        private System.Windows.Forms.ToolStripMenuItem itmExportCsv;
        private System.Windows.Forms.ToolStripMenuItem itmExportRaw;
    }
}

