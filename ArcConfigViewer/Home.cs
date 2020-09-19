using System;
using System.IO;
using System.Windows.Forms;

namespace ArcConfigViewer
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void ItmFileOpenConfig_Click(object sender, EventArgs e)
        {
            LoadFileAndDecrypt(GetFileName());
        }

        private static void LoadFileAndDecrypt(string filePath)
        {
            try
            {
                if (!File.Exists(filePath)) return;

                const string password = @"2&15u69A";
                var cipherBytes = File.ReadAllBytes(filePath);
                var decryptedBytes = OpenSslAes.Decrypt(cipherBytes, password);
                if (decryptedBytes != null)
                    File.WriteAllBytes(@"LH1000_backup.dec.cfg", decryptedBytes);
            }
            catch (Exception ex)
            {
                UiMessages.Error($"Decryption error:\n\n{ex}");
            }

            //default
        }

        private string GetFileName()
        {
            return ofdRouterConfiguration.ShowDialog() == DialogResult.OK ? ofdRouterConfiguration.FileName : @"";
        }
    }
}