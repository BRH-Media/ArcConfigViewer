using System;
using System.Data;
using System.Windows.Forms;

namespace ArcConfigViewer
{
    public partial class ConnectedDevices : Form
    {
        public DataTable Data { get; set; }

        public ConnectedDevices()
        {
            InitializeComponent();
        }

        private void ConnectedDevices_Load(object sender, EventArgs e)
        {
            SetDataSource(Data);
        }

        private void SetDataSource(DataTable data)
        {
            dgvMain.DataSource = data;
        }

        public static void ShowConnectedDevices(DataTable devices)
        {
            var frm = new ConnectedDevices
            {
                Data = devices
            };
            frm.ShowDialog();
        }
    }
}