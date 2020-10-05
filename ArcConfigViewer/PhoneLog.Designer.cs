namespace ArcConfigViewer
{
    partial class PhoneLog
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
            this.statusMain = new System.Windows.Forms.StatusStrip();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.itmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExport = new System.Windows.Forms.ToolStripMenuItem();
            this.itmImport = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.itmHandset = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExportJson = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExportCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExportXml = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
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
            this.dgvMain.Location = new System.Drawing.Point(0, 24);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.ShowCellErrors = false;
            this.dgvMain.ShowCellToolTips = false;
            this.dgvMain.ShowEditingIcon = false;
            this.dgvMain.ShowRowErrors = false;
            this.dgvMain.Size = new System.Drawing.Size(800, 404);
            this.dgvMain.TabIndex = 5;
            // 
            // statusMain
            // 
            this.statusMain.Location = new System.Drawing.Point(0, 428);
            this.statusMain.Name = "statusMain";
            this.statusMain.Size = new System.Drawing.Size(800, 22);
            this.statusMain.TabIndex = 6;
            this.statusMain.Text = "statusStrip1";
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmFile,
            this.itmSearch,
            this.itmHandset});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(800, 24);
            this.menuMain.TabIndex = 7;
            this.menuMain.Text = "menuStrip1";
            // 
            // itmFile
            // 
            this.itmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmExport,
            this.itmImport});
            this.itmFile.Name = "itmFile";
            this.itmFile.Size = new System.Drawing.Size(37, 20);
            this.itmFile.Text = "File";
            // 
            // itmExport
            // 
            this.itmExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmExportJson,
            this.itmExportCsv,
            this.itmExportXml});
            this.itmExport.Name = "itmExport";
            this.itmExport.Size = new System.Drawing.Size(180, 22);
            this.itmExport.Text = "Export";
            // 
            // itmImport
            // 
            this.itmImport.Name = "itmImport";
            this.itmImport.Size = new System.Drawing.Size(180, 22);
            this.itmImport.Text = "Import";
            // 
            // itmSearch
            // 
            this.itmSearch.Name = "itmSearch";
            this.itmSearch.Size = new System.Drawing.Size(54, 20);
            this.itmSearch.Text = "Search";
            // 
            // itmHandset
            // 
            this.itmHandset.Name = "itmHandset";
            this.itmHandset.Size = new System.Drawing.Size(63, 20);
            this.itmHandset.Text = "Handset";
            // 
            // itmExportJson
            // 
            this.itmExportJson.Name = "itmExportJson";
            this.itmExportJson.Size = new System.Drawing.Size(180, 22);
            this.itmExportJson.Text = "JSON";
            // 
            // itmExportCsv
            // 
            this.itmExportCsv.Name = "itmExportCsv";
            this.itmExportCsv.Size = new System.Drawing.Size(180, 22);
            this.itmExportCsv.Text = "CSV";
            // 
            // itmExportXml
            // 
            this.itmExportXml.Name = "itmExportXml";
            this.itmExportXml.Size = new System.Drawing.Size(180, 22);
            this.itmExportXml.Text = "XML";
            // 
            // PhoneLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.statusMain);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.MinimizeBox = false;
            this.Name = "PhoneLog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Call Log";
            this.Load += new System.EventHandler(this.PhoneLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.StatusStrip statusMain;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem itmFile;
        private System.Windows.Forms.ToolStripMenuItem itmExport;
        private System.Windows.Forms.ToolStripMenuItem itmImport;
        private System.Windows.Forms.ToolStripMenuItem itmSearch;
        private System.Windows.Forms.ToolStripMenuItem itmHandset;
        private System.Windows.Forms.ToolStripMenuItem itmExportJson;
        private System.Windows.Forms.ToolStripMenuItem itmExportCsv;
        private System.Windows.Forms.ToolStripMenuItem itmExportXml;
    }
}