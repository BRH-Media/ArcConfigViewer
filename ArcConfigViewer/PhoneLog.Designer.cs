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
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.itmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExport = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExportJson = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExportCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExportXml = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.itmHandset = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.lblVoip = new System.Windows.Forms.ToolStripLabel();
            this.lblVoipValue = new System.Windows.Forms.ToolStripLabel();
            this.sepSection1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTotalMissed = new System.Windows.Forms.ToolStripLabel();
            this.lblTotalMissedValue = new System.Windows.Forms.ToolStripLabel();
            this.sepSection2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTotalOut = new System.Windows.Forms.ToolStripLabel();
            this.lblTotalOutValue = new System.Windows.Forms.ToolStripLabel();
            this.lblTotalIn = new System.Windows.Forms.ToolStripLabel();
            this.sepSection3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTotalInValue = new System.Windows.Forms.ToolStripLabel();
            this.lblTotalBilledTime = new System.Windows.Forms.ToolStripLabel();
            this.lblTotalBilledTimeValue = new System.Windows.Forms.ToolStripLabel();
            this.sepTotalBilledTime = new System.Windows.Forms.ToolStripSeparator();
            this.sepEnd = new System.Windows.Forms.ToolStripSeparator();
            this.lblTotalCallTimeValue = new System.Windows.Forms.ToolStripLabel();
            this.lblTotalCallTime = new System.Windows.Forms.ToolStripLabel();
            this.sepTotalCallTime = new System.Windows.Forms.ToolStripSeparator();
            this.lblCallRatio = new System.Windows.Forms.ToolStripLabel();
            this.lblCallRatioValue = new System.Windows.Forms.ToolStripLabel();
            this.sepCallRatio = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.menuMain.SuspendLayout();
            this.tsMain.SuspendLayout();
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
            this.dgvMain.Size = new System.Drawing.Size(1264, 632);
            this.dgvMain.TabIndex = 5;
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmFile,
            this.itmSearch,
            this.itmHandset});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1264, 24);
            this.menuMain.TabIndex = 7;
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
            this.itmExportJson,
            this.itmExportCsv,
            this.itmExportXml});
            this.itmExport.Enabled = false;
            this.itmExport.Name = "itmExport";
            this.itmExport.Size = new System.Drawing.Size(180, 22);
            this.itmExport.Text = "Export";
            // 
            // itmExportJson
            // 
            this.itmExportJson.Name = "itmExportJson";
            this.itmExportJson.Size = new System.Drawing.Size(180, 22);
            this.itmExportJson.Text = "JSON";
            this.itmExportJson.Click += new System.EventHandler(this.ItmExportJson_Click);
            // 
            // itmExportCsv
            // 
            this.itmExportCsv.Name = "itmExportCsv";
            this.itmExportCsv.Size = new System.Drawing.Size(180, 22);
            this.itmExportCsv.Text = "CSV";
            this.itmExportCsv.Click += new System.EventHandler(this.ItmExportCsv_Click);
            // 
            // itmExportXml
            // 
            this.itmExportXml.Name = "itmExportXml";
            this.itmExportXml.Size = new System.Drawing.Size(180, 22);
            this.itmExportXml.Text = "XML";
            this.itmExportXml.Click += new System.EventHandler(this.ItmExportXml_Click);
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
            // itmHandset
            // 
            this.itmHandset.Enabled = false;
            this.itmHandset.Name = "itmHandset";
            this.itmHandset.Size = new System.Drawing.Size(63, 20);
            this.itmHandset.Text = "Handset";
            // 
            // tsMain
            // 
            this.tsMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblVoip,
            this.lblVoipValue,
            this.sepSection1,
            this.lblTotalMissed,
            this.lblTotalMissedValue,
            this.sepSection2,
            this.lblTotalOut,
            this.lblTotalOutValue,
            this.sepSection3,
            this.lblTotalIn,
            this.lblTotalInValue,
            this.lblTotalBilledTimeValue,
            this.lblTotalBilledTime,
            this.sepTotalBilledTime,
            this.sepEnd,
            this.lblTotalCallTimeValue,
            this.lblTotalCallTime,
            this.sepTotalCallTime,
            this.lblCallRatioValue,
            this.lblCallRatio,
            this.sepCallRatio});
            this.tsMain.Location = new System.Drawing.Point(0, 656);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1264, 25);
            this.tsMain.TabIndex = 8;
            this.tsMain.Text = "toolStrip1";
            // 
            // lblVoip
            // 
            this.lblVoip.Name = "lblVoip";
            this.lblVoip.Size = new System.Drawing.Size(101, 22);
            this.lblVoip.Text = "PHONE NUMBER:";
            // 
            // lblVoipValue
            // 
            this.lblVoipValue.Name = "lblVoipValue";
            this.lblVoipValue.Size = new System.Drawing.Size(58, 22);
            this.lblVoipValue.Text = "Unknown";
            // 
            // sepSection1
            // 
            this.sepSection1.Name = "sepSection1";
            this.sepSection1.Size = new System.Drawing.Size(6, 25);
            // 
            // lblTotalMissed
            // 
            this.lblTotalMissed.Name = "lblTotalMissed";
            this.lblTotalMissed.Size = new System.Drawing.Size(60, 22);
            this.lblTotalMissed.Text = "# MISSED:";
            // 
            // lblTotalMissedValue
            // 
            this.lblTotalMissedValue.Name = "lblTotalMissedValue";
            this.lblTotalMissedValue.Size = new System.Drawing.Size(58, 22);
            this.lblTotalMissedValue.Text = "Unknown";
            // 
            // sepSection2
            // 
            this.sepSection2.Name = "sepSection2";
            this.sepSection2.Size = new System.Drawing.Size(6, 25);
            // 
            // lblTotalOut
            // 
            this.lblTotalOut.Name = "lblTotalOut";
            this.lblTotalOut.Size = new System.Drawing.Size(43, 22);
            this.lblTotalOut.Text = "# OUT:";
            // 
            // lblTotalOutValue
            // 
            this.lblTotalOutValue.Name = "lblTotalOutValue";
            this.lblTotalOutValue.Size = new System.Drawing.Size(58, 22);
            this.lblTotalOutValue.Text = "Unknown";
            // 
            // lblTotalIn
            // 
            this.lblTotalIn.Name = "lblTotalIn";
            this.lblTotalIn.Size = new System.Drawing.Size(32, 22);
            this.lblTotalIn.Text = "# IN:";
            // 
            // sepSection3
            // 
            this.sepSection3.Name = "sepSection3";
            this.sepSection3.Size = new System.Drawing.Size(6, 25);
            // 
            // lblTotalInValue
            // 
            this.lblTotalInValue.Name = "lblTotalInValue";
            this.lblTotalInValue.Size = new System.Drawing.Size(58, 22);
            this.lblTotalInValue.Text = "Unknown";
            // 
            // lblTotalBilledTime
            // 
            this.lblTotalBilledTime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblTotalBilledTime.Name = "lblTotalBilledTime";
            this.lblTotalBilledTime.Size = new System.Drawing.Size(110, 22);
            this.lblTotalBilledTime.Text = "TOTAL BILLED TIME:";
            this.lblTotalBilledTime.Click += new System.EventHandler(this.LblTotalBilledTime_Click);
            // 
            // lblTotalBilledTimeValue
            // 
            this.lblTotalBilledTimeValue.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblTotalBilledTimeValue.Name = "lblTotalBilledTimeValue";
            this.lblTotalBilledTimeValue.Size = new System.Drawing.Size(58, 22);
            this.lblTotalBilledTimeValue.Text = "Unknown";
            this.lblTotalBilledTimeValue.Click += new System.EventHandler(this.LblTotalBilledTimeValue_Click);
            // 
            // sepTotalBilledTime
            // 
            this.sepTotalBilledTime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sepTotalBilledTime.Name = "sepTotalBilledTime";
            this.sepTotalBilledTime.Size = new System.Drawing.Size(6, 25);
            // 
            // sepEnd
            // 
            this.sepEnd.Name = "sepEnd";
            this.sepEnd.Size = new System.Drawing.Size(6, 25);
            // 
            // lblTotalCallTimeValue
            // 
            this.lblTotalCallTimeValue.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblTotalCallTimeValue.Name = "lblTotalCallTimeValue";
            this.lblTotalCallTimeValue.Size = new System.Drawing.Size(58, 22);
            this.lblTotalCallTimeValue.Text = "Unknown";
            // 
            // lblTotalCallTime
            // 
            this.lblTotalCallTime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblTotalCallTime.Name = "lblTotalCallTime";
            this.lblTotalCallTime.Size = new System.Drawing.Size(102, 22);
            this.lblTotalCallTime.Text = "TOTAL CALL TIME:";
            // 
            // sepTotalCallTime
            // 
            this.sepTotalCallTime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sepTotalCallTime.Name = "sepTotalCallTime";
            this.sepTotalCallTime.Size = new System.Drawing.Size(6, 25);
            // 
            // lblCallRatio
            // 
            this.lblCallRatio.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblCallRatio.Name = "lblCallRatio";
            this.lblCallRatio.Size = new System.Drawing.Size(70, 22);
            this.lblCallRatio.Text = "CALL RATIO";
            // 
            // lblCallRatioValue
            // 
            this.lblCallRatioValue.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblCallRatioValue.Name = "lblCallRatioValue";
            this.lblCallRatioValue.Size = new System.Drawing.Size(58, 22);
            this.lblCallRatioValue.Text = "Unknown";
            // 
            // sepCallRatio
            // 
            this.sepCallRatio.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sepCallRatio.Name = "sepCallRatio";
            this.sepCallRatio.Size = new System.Drawing.Size(6, 25);
            // 
            // PhoneLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.menuMain);
            this.Controls.Add(this.tsMain);
            this.MainMenuStrip = this.menuMain;
            this.MinimizeBox = false;
            this.Name = "PhoneLog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VOIP Call Log";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PhoneLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem itmFile;
        private System.Windows.Forms.ToolStripMenuItem itmExport;
        private System.Windows.Forms.ToolStripMenuItem itmSearch;
        private System.Windows.Forms.ToolStripMenuItem itmHandset;
        private System.Windows.Forms.ToolStripMenuItem itmExportJson;
        private System.Windows.Forms.ToolStripMenuItem itmExportCsv;
        private System.Windows.Forms.ToolStripMenuItem itmExportXml;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripLabel lblVoip;
        private System.Windows.Forms.ToolStripLabel lblVoipValue;
        private System.Windows.Forms.ToolStripSeparator sepSection1;
        private System.Windows.Forms.ToolStripLabel lblTotalMissed;
        private System.Windows.Forms.ToolStripLabel lblTotalMissedValue;
        private System.Windows.Forms.ToolStripSeparator sepSection2;
        private System.Windows.Forms.ToolStripLabel lblTotalOut;
        private System.Windows.Forms.ToolStripLabel lblTotalOutValue;
        private System.Windows.Forms.ToolStripSeparator sepSection3;
        private System.Windows.Forms.ToolStripLabel lblTotalIn;
        private System.Windows.Forms.ToolStripLabel lblTotalInValue;
        private System.Windows.Forms.ToolStripLabel lblTotalBilledTime;
        private System.Windows.Forms.ToolStripLabel lblTotalBilledTimeValue;
        private System.Windows.Forms.ToolStripSeparator sepTotalBilledTime;
        private System.Windows.Forms.ToolStripSeparator sepEnd;
        private System.Windows.Forms.ToolStripLabel lblTotalCallTimeValue;
        private System.Windows.Forms.ToolStripLabel lblTotalCallTime;
        private System.Windows.Forms.ToolStripSeparator sepTotalCallTime;
        private System.Windows.Forms.ToolStripLabel lblCallRatioValue;
        private System.Windows.Forms.ToolStripLabel lblCallRatio;
        private System.Windows.Forms.ToolStripSeparator sepCallRatio;
    }
}