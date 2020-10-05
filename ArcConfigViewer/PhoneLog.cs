using System;
using System.Data;
using System.Windows.Forms;

namespace ArcConfigViewer
{
    public partial class PhoneLog : Form
    {
        public DataTable Data { get; set; } = null;

        public PhoneLog()
        {
            InitializeComponent();
        }

        private void PhoneLog_Load(object sender, EventArgs e)
        {
            dgvMain.DataSource = Data;
        }

        public static void LoadLog(DataTable log)
        {
            var logForm = new PhoneLog
            {
                Data = log
            };
            logForm.ShowDialog();
        }
    }
}