namespace ArcConfigViewer
{
    partial class Search
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
            this.cbxColumn = new System.Windows.Forms.ComboBox();
            this.lblSearchColumn = new System.Windows.Forms.Label();
            this.lblSearchTerm = new System.Windows.Forms.Label();
            this.pnlGridSearch = new System.Windows.Forms.Panel();
            this.btnCancelGrid = new System.Windows.Forms.Button();
            this.btnSearchGrid = new System.Windows.Forms.Button();
            this.txtSearchTerm = new System.Windows.Forms.TextBox();
            this.pnlTextSearch = new System.Windows.Forms.Panel();
            this.btnCancelText = new System.Windows.Forms.Button();
            this.btnSearchText = new System.Windows.Forms.Button();
            this.txtTextSearchTerm = new System.Windows.Forms.TextBox();
            this.lblTextSearchTerm = new System.Windows.Forms.Label();
            this.pnlGridSearch.SuspendLayout();
            this.pnlTextSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxColumn
            // 
            this.cbxColumn.FormattingEnabled = true;
            this.cbxColumn.Location = new System.Drawing.Point(12, 28);
            this.cbxColumn.Name = "cbxColumn";
            this.cbxColumn.Size = new System.Drawing.Size(339, 21);
            this.cbxColumn.TabIndex = 0;
            // 
            // lblSearchColumn
            // 
            this.lblSearchColumn.AutoSize = true;
            this.lblSearchColumn.Location = new System.Drawing.Point(9, 12);
            this.lblSearchColumn.Name = "lblSearchColumn";
            this.lblSearchColumn.Size = new System.Drawing.Size(79, 13);
            this.lblSearchColumn.TabIndex = 1;
            this.lblSearchColumn.Text = "Search Column";
            // 
            // lblSearchTerm
            // 
            this.lblSearchTerm.AutoSize = true;
            this.lblSearchTerm.Location = new System.Drawing.Point(9, 63);
            this.lblSearchTerm.Name = "lblSearchTerm";
            this.lblSearchTerm.Size = new System.Drawing.Size(68, 13);
            this.lblSearchTerm.TabIndex = 2;
            this.lblSearchTerm.Text = "Search Term";
            // 
            // pnlGridSearch
            // 
            this.pnlGridSearch.Controls.Add(this.btnCancelGrid);
            this.pnlGridSearch.Controls.Add(this.btnSearchGrid);
            this.pnlGridSearch.Controls.Add(this.txtSearchTerm);
            this.pnlGridSearch.Controls.Add(this.lblSearchColumn);
            this.pnlGridSearch.Controls.Add(this.lblSearchTerm);
            this.pnlGridSearch.Controls.Add(this.cbxColumn);
            this.pnlGridSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlGridSearch.Name = "pnlGridSearch";
            this.pnlGridSearch.Size = new System.Drawing.Size(363, 139);
            this.pnlGridSearch.TabIndex = 3;
            // 
            // btnCancelGrid
            // 
            this.btnCancelGrid.Location = new System.Drawing.Point(195, 105);
            this.btnCancelGrid.Name = "btnCancelGrid";
            this.btnCancelGrid.Size = new System.Drawing.Size(75, 23);
            this.btnCancelGrid.TabIndex = 5;
            this.btnCancelGrid.Text = "Cancel";
            this.btnCancelGrid.UseVisualStyleBackColor = true;
            this.btnCancelGrid.Click += new System.EventHandler(this.BtnCancelGrid_Click);
            // 
            // btnSearchGrid
            // 
            this.btnSearchGrid.Location = new System.Drawing.Point(276, 105);
            this.btnSearchGrid.Name = "btnSearchGrid";
            this.btnSearchGrid.Size = new System.Drawing.Size(75, 23);
            this.btnSearchGrid.TabIndex = 4;
            this.btnSearchGrid.Text = "Search";
            this.btnSearchGrid.UseVisualStyleBackColor = true;
            this.btnSearchGrid.Click += new System.EventHandler(this.BtnSearchGrid_Click);
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.Location = new System.Drawing.Point(12, 79);
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(339, 20);
            this.txtSearchTerm.TabIndex = 3;
            // 
            // pnlTextSearch
            // 
            this.pnlTextSearch.Controls.Add(this.btnCancelText);
            this.pnlTextSearch.Controls.Add(this.btnSearchText);
            this.pnlTextSearch.Controls.Add(this.txtTextSearchTerm);
            this.pnlTextSearch.Controls.Add(this.lblTextSearchTerm);
            this.pnlTextSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTextSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlTextSearch.Name = "pnlTextSearch";
            this.pnlTextSearch.Size = new System.Drawing.Size(363, 139);
            this.pnlTextSearch.TabIndex = 6;
            // 
            // btnCancelText
            // 
            this.btnCancelText.Location = new System.Drawing.Point(195, 55);
            this.btnCancelText.Name = "btnCancelText";
            this.btnCancelText.Size = new System.Drawing.Size(75, 23);
            this.btnCancelText.TabIndex = 5;
            this.btnCancelText.Text = "Cancel";
            this.btnCancelText.UseVisualStyleBackColor = true;
            this.btnCancelText.Click += new System.EventHandler(this.BtnTextCancel_Click);
            // 
            // btnSearchText
            // 
            this.btnSearchText.Location = new System.Drawing.Point(276, 55);
            this.btnSearchText.Name = "btnSearchText";
            this.btnSearchText.Size = new System.Drawing.Size(75, 23);
            this.btnSearchText.TabIndex = 4;
            this.btnSearchText.Text = "Search";
            this.btnSearchText.UseVisualStyleBackColor = true;
            this.btnSearchText.Click += new System.EventHandler(this.BtnTextSearch_Click);
            // 
            // txtTextSearchTerm
            // 
            this.txtTextSearchTerm.Location = new System.Drawing.Point(12, 29);
            this.txtTextSearchTerm.Name = "txtTextSearchTerm";
            this.txtTextSearchTerm.Size = new System.Drawing.Size(339, 20);
            this.txtTextSearchTerm.TabIndex = 3;
            // 
            // lblTextSearchTerm
            // 
            this.lblTextSearchTerm.AutoSize = true;
            this.lblTextSearchTerm.Location = new System.Drawing.Point(9, 9);
            this.lblTextSearchTerm.Name = "lblTextSearchTerm";
            this.lblTextSearchTerm.Size = new System.Drawing.Size(68, 13);
            this.lblTextSearchTerm.TabIndex = 2;
            this.lblTextSearchTerm.Text = "Search Term";
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 139);
            this.ControlBox = false;
            this.Controls.Add(this.pnlTextSearch);
            this.Controls.Add(this.pnlGridSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Search";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Search_Load);
            this.pnlGridSearch.ResumeLayout(false);
            this.pnlGridSearch.PerformLayout();
            this.pnlTextSearch.ResumeLayout(false);
            this.pnlTextSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxColumn;
        private System.Windows.Forms.Label lblSearchColumn;
        private System.Windows.Forms.Label lblSearchTerm;
        private System.Windows.Forms.Panel pnlGridSearch;
        private System.Windows.Forms.TextBox txtSearchTerm;
        private System.Windows.Forms.Button btnSearchGrid;
        private System.Windows.Forms.Button btnCancelGrid;
        private System.Windows.Forms.Panel pnlTextSearch;
        private System.Windows.Forms.Button btnCancelText;
        private System.Windows.Forms.Button btnSearchText;
        private System.Windows.Forms.TextBox txtTextSearchTerm;
        private System.Windows.Forms.Label lblTextSearchTerm;
    }
}