using ArcAuthentication.CGI.DataService;
using ArcProcessor;
using System;
using System.Data;
using System.Windows.Forms;

// ReSharper disable InvertIf

namespace ArcConfigViewer.UI
{
    public partial class FirmwareVersion : Form
    {
        public CgiFirmwareVersion FwVersion { get; set; }

        public FirmwareVersion()
        {
            InitializeComponent();
        }

        public static void ShowVersionInfo()
        {
            var frm = new FirmwareVersion();
            frm.ShowDialog();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FirmwareVersion_Load(object sender, EventArgs e)
        {
            LoadValues();
        }

        private static DataTable FromVersionInfo(CgiFirmwareVersion info)
        {
            try
            {
                //validation
                if (info != null)
                {
                    //construct table
                    var dt = new DataTable(@"FwVersionInfo");

                    //two columns
                    dt.Columns.Add(@"Entry", typeof(string));
                    dt.Columns.Add(@"Value", typeof(string));

                    //three rows
                    dt.Rows.Add(@"Build", info.BuildString);
                    dt.Rows.Add(@"Version", info.VersionString);
                    dt.Rows.Add(@"Model", info.ModelString);

                    //return final table
                    return dt;
                }
            }
            catch (Exception)
            {
                //ignore
            }

            //default
            return null;
        }

        private void LoadValues()
        {
            try
            {
                //Check if downloaded firmware version information doesn't exist.
                //If the information needs to be reloaded, we can avoid another fetch.
                if (FwVersion == null)
                {
                    //download firmware information
                    var fwVersion = CgiFirmwareVersion.GetFwVersion();

                    //validation
                    if (fwVersion != null)
                    {
                        //apply global value
                        FwVersion = fwVersion;

                        //render grid
                        dgvMain.DataSource = FromVersionInfo(fwVersion);
                    }
                }
                else
                    //render grid
                    dgvMain.DataSource = FromVersionInfo(FwVersion);
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString(), @"Firmware Version Error");
                Close();
            }
        }
    }
}