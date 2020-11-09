namespace ArcAuthentication.UI
{
    partial class ScriptExecute
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.gbScriptResult = new System.Windows.Forms.GroupBox();
            this.gbValues = new System.Windows.Forms.GroupBox();
            this.lblServiceMessage = new System.Windows.Forms.Label();
            this.lblReferrer = new System.Windows.Forms.Label();
            this.lblServiceEndpoint = new System.Windows.Forms.Label();
            this.lblTokenEndpoint = new System.Windows.Forms.Label();
            this.lblServiceName = new System.Windows.Forms.Label();
            this.txtServiceMessage = new System.Windows.Forms.TextBox();
            this.txtReferrer = new System.Windows.Forms.TextBox();
            this.txtServiceEndpoint = new System.Windows.Forms.TextBox();
            this.txtTokeniserEndpoint = new System.Windows.Forms.TextBox();
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.gbScriptLoading = new System.Windows.Forms.GroupBox();
            this.btnFetchScript = new System.Windows.Forms.Button();
            this.btnLoadJSON = new System.Windows.Forms.Button();
            this.ofdLoadJSON = new System.Windows.Forms.OpenFileDialog();
            this.browserMain = new System.Windows.Forms.WebBrowser();
            this.tlpMain.SuspendLayout();
            this.gbScriptResult.SuspendLayout();
            this.gbValues.SuspendLayout();
            this.gbScriptLoading.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.gbScriptResult, 1, 0);
            this.tlpMain.Controls.Add(this.gbValues, 0, 1);
            this.tlpMain.Controls.Add(this.gbScriptLoading, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(800, 450);
            this.tlpMain.TabIndex = 0;
            // 
            // gbScriptResult
            // 
            this.gbScriptResult.Controls.Add(this.browserMain);
            this.gbScriptResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbScriptResult.Location = new System.Drawing.Point(230, 3);
            this.gbScriptResult.Name = "gbScriptResult";
            this.tlpMain.SetRowSpan(this.gbScriptResult, 2);
            this.gbScriptResult.Size = new System.Drawing.Size(567, 444);
            this.gbScriptResult.TabIndex = 1;
            this.gbScriptResult.TabStop = false;
            this.gbScriptResult.Text = "Script Result";
            // 
            // gbValues
            // 
            this.gbValues.Controls.Add(this.lblServiceMessage);
            this.gbValues.Controls.Add(this.lblReferrer);
            this.gbValues.Controls.Add(this.lblServiceEndpoint);
            this.gbValues.Controls.Add(this.lblTokenEndpoint);
            this.gbValues.Controls.Add(this.lblServiceName);
            this.gbValues.Controls.Add(this.txtServiceMessage);
            this.gbValues.Controls.Add(this.txtReferrer);
            this.gbValues.Controls.Add(this.txtServiceEndpoint);
            this.gbValues.Controls.Add(this.txtTokeniserEndpoint);
            this.gbValues.Controls.Add(this.txtServiceName);
            this.gbValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbValues.Location = new System.Drawing.Point(3, 86);
            this.gbValues.Name = "gbValues";
            this.gbValues.Size = new System.Drawing.Size(221, 361);
            this.gbValues.TabIndex = 0;
            this.gbValues.TabStop = false;
            this.gbValues.Text = "Values";
            // 
            // lblServiceMessage
            // 
            this.lblServiceMessage.AutoSize = true;
            this.lblServiceMessage.Location = new System.Drawing.Point(9, 184);
            this.lblServiceMessage.Name = "lblServiceMessage";
            this.lblServiceMessage.Size = new System.Drawing.Size(117, 13);
            this.lblServiceMessage.TabIndex = 9;
            this.lblServiceMessage.Text = "Wait Window Message";
            // 
            // lblReferrer
            // 
            this.lblReferrer.AutoSize = true;
            this.lblReferrer.Location = new System.Drawing.Point(9, 142);
            this.lblReferrer.Name = "lblReferrer";
            this.lblReferrer.Size = new System.Drawing.Size(114, 13);
            this.lblReferrer.TabIndex = 8;
            this.lblReferrer.Text = "Script Service Referrer";
            // 
            // lblServiceEndpoint
            // 
            this.lblServiceEndpoint.AutoSize = true;
            this.lblServiceEndpoint.Location = new System.Drawing.Point(9, 100);
            this.lblServiceEndpoint.Name = "lblServiceEndpoint";
            this.lblServiceEndpoint.Size = new System.Drawing.Size(118, 13);
            this.lblServiceEndpoint.TabIndex = 7;
            this.lblServiceEndpoint.Text = "Script Service Endpoint";
            // 
            // lblTokenEndpoint
            // 
            this.lblTokenEndpoint.AutoSize = true;
            this.lblTokenEndpoint.Location = new System.Drawing.Point(9, 58);
            this.lblTokenEndpoint.Name = "lblTokenEndpoint";
            this.lblTokenEndpoint.Size = new System.Drawing.Size(113, 13);
            this.lblTokenEndpoint.TabIndex = 6;
            this.lblTokenEndpoint.Text = "Script Token Endpoint";
            // 
            // lblServiceName
            // 
            this.lblServiceName.AutoSize = true;
            this.lblServiceName.Location = new System.Drawing.Point(9, 16);
            this.lblServiceName.Name = "lblServiceName";
            this.lblServiceName.Size = new System.Drawing.Size(104, 13);
            this.lblServiceName.TabIndex = 5;
            this.lblServiceName.Text = "Script Service Name";
            // 
            // txtServiceMessage
            // 
            this.txtServiceMessage.Location = new System.Drawing.Point(9, 200);
            this.txtServiceMessage.Name = "txtServiceMessage";
            this.txtServiceMessage.Size = new System.Drawing.Size(206, 20);
            this.txtServiceMessage.TabIndex = 4;
            this.txtServiceMessage.Text = "<Message>";
            // 
            // txtReferrer
            // 
            this.txtReferrer.Location = new System.Drawing.Point(9, 158);
            this.txtReferrer.Name = "txtReferrer";
            this.txtReferrer.Size = new System.Drawing.Size(206, 20);
            this.txtReferrer.TabIndex = 3;
            this.txtReferrer.Text = "<Referrer>";
            // 
            // txtServiceEndpoint
            // 
            this.txtServiceEndpoint.Location = new System.Drawing.Point(9, 116);
            this.txtServiceEndpoint.Name = "txtServiceEndpoint";
            this.txtServiceEndpoint.Size = new System.Drawing.Size(206, 20);
            this.txtServiceEndpoint.TabIndex = 2;
            this.txtServiceEndpoint.Text = "<ServiceEndpoint>";
            // 
            // txtTokeniserEndpoint
            // 
            this.txtTokeniserEndpoint.Location = new System.Drawing.Point(9, 74);
            this.txtTokeniserEndpoint.Name = "txtTokeniserEndpoint";
            this.txtTokeniserEndpoint.Size = new System.Drawing.Size(206, 20);
            this.txtTokeniserEndpoint.TabIndex = 1;
            this.txtTokeniserEndpoint.Text = "<TokenEndpoint>";
            // 
            // txtServiceName
            // 
            this.txtServiceName.Location = new System.Drawing.Point(9, 32);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(206, 20);
            this.txtServiceName.TabIndex = 0;
            this.txtServiceName.Text = "<ServiceName>";
            // 
            // gbScriptLoading
            // 
            this.gbScriptLoading.Controls.Add(this.btnFetchScript);
            this.gbScriptLoading.Controls.Add(this.btnLoadJSON);
            this.gbScriptLoading.Location = new System.Drawing.Point(3, 3);
            this.gbScriptLoading.Name = "gbScriptLoading";
            this.gbScriptLoading.Size = new System.Drawing.Size(221, 77);
            this.gbScriptLoading.TabIndex = 2;
            this.gbScriptLoading.TabStop = false;
            this.gbScriptLoading.Text = "Script";
            // 
            // btnFetchScript
            // 
            this.btnFetchScript.Enabled = false;
            this.btnFetchScript.Location = new System.Drawing.Point(9, 45);
            this.btnFetchScript.Name = "btnFetchScript";
            this.btnFetchScript.Size = new System.Drawing.Size(206, 23);
            this.btnFetchScript.TabIndex = 1;
            this.btnFetchScript.Text = "Fetch Script";
            this.btnFetchScript.UseVisualStyleBackColor = true;
            this.btnFetchScript.Click += new System.EventHandler(this.BtnFetchScript_Click);
            // 
            // btnLoadJSON
            // 
            this.btnLoadJSON.Location = new System.Drawing.Point(9, 16);
            this.btnLoadJSON.Name = "btnLoadJSON";
            this.btnLoadJSON.Size = new System.Drawing.Size(206, 23);
            this.btnLoadJSON.TabIndex = 0;
            this.btnLoadJSON.Text = "Load JSON";
            this.btnLoadJSON.UseVisualStyleBackColor = true;
            this.btnLoadJSON.Click += new System.EventHandler(this.BtnLoadJSON_Click);
            // 
            // ofdLoadJSON
            // 
            this.ofdLoadJSON.DefaultExt = "json";
            this.ofdLoadJSON.Filter = "JSON Files|*.json";
            this.ofdLoadJSON.Title = "Load JSON";
            // 
            // browserMain
            // 
            this.browserMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserMain.Location = new System.Drawing.Point(3, 16);
            this.browserMain.MinimumSize = new System.Drawing.Size(20, 20);
            this.browserMain.Name = "browserMain";
            this.browserMain.Size = new System.Drawing.Size(561, 425);
            this.browserMain.TabIndex = 0;
            // 
            // ScriptExecute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlpMain);
            this.Name = "ScriptExecute";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Script Execute";
            this.Load += new System.EventHandler(this.ScriptExecute_Load);
            this.tlpMain.ResumeLayout(false);
            this.gbScriptResult.ResumeLayout(false);
            this.gbValues.ResumeLayout(false);
            this.gbValues.PerformLayout();
            this.gbScriptLoading.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox gbValues;
        private System.Windows.Forms.GroupBox gbScriptResult;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.TextBox txtTokeniserEndpoint;
        private System.Windows.Forms.TextBox txtServiceEndpoint;
        private System.Windows.Forms.TextBox txtReferrer;
        private System.Windows.Forms.TextBox txtServiceMessage;
        private System.Windows.Forms.Label lblServiceName;
        private System.Windows.Forms.Label lblTokenEndpoint;
        private System.Windows.Forms.Label lblServiceEndpoint;
        private System.Windows.Forms.Label lblReferrer;
        private System.Windows.Forms.Label lblServiceMessage;
        private System.Windows.Forms.GroupBox gbScriptLoading;
        private System.Windows.Forms.Button btnLoadJSON;
        private System.Windows.Forms.Button btnFetchScript;
        private System.Windows.Forms.OpenFileDialog ofdLoadJSON;
        private System.Windows.Forms.WebBrowser browserMain;
    }
}