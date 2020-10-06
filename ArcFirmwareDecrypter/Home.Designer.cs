namespace ArcFirmwareDecrypter
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
            this.ofdFirmwareOpen = new System.Windows.Forms.OpenFileDialog();
            this.btnHMAC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ofdFirmwareOpen
            // 
            this.ofdFirmwareOpen.Filter = "LH1000 Firmware|*.w.ArcSigned";
            this.ofdFirmwareOpen.FileOk += new System.ComponentModel.CancelEventHandler(this.OfdFirmwareOpen_FileOk);
            // 
            // btnHMAC
            // 
            this.btnHMAC.Location = new System.Drawing.Point(210, 120);
            this.btnHMAC.Name = "btnHMAC";
            this.btnHMAC.Size = new System.Drawing.Size(75, 23);
            this.btnHMAC.TabIndex = 0;
            this.btnHMAC.Text = "Decrypt";
            this.btnHMAC.UseVisualStyleBackColor = true;
            this.btnHMAC.Click += new System.EventHandler(this.BtnHMAC_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnHMAC);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Home";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LH1000 Firmware Decrypter";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdFirmwareOpen;
        private System.Windows.Forms.Button btnHMAC;
    }
}

