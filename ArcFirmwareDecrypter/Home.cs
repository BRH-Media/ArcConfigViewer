using System.ComponentModel;
using System.Windows.Forms;

namespace ArcFirmwareDecrypter
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void OfdFirmwareOpen_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void BtnHMAC_Click(object sender, System.EventArgs e)
        {
            if (ofdFirmwareOpen.ShowDialog() == DialogResult.OK)
            {
                var fw = new FirmwareImage(ofdFirmwareOpen.FileName);
                fw.DecryptImage();
            }
        }
    }
}