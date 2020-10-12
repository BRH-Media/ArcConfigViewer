using ArcAuthentication.CGI;
using ArcAuthentication.Enums;
using ArcConfigViewer.Enums;
using ArcConfigViewer.Extensions;
using ArcProcessor;
using System;
using System.Data;
using System.Windows.Forms;
using ArcAuthentication.CGI.DataService;

namespace ArcConfigViewer.UI
{
    public partial class SystemLogs : Form
    {
        public DataTable Data { get; set; }

        public SystemLogs()
        {
            InitializeComponent();
        }

        private void SetDataSource(DataTable data, bool overrideGlobal = false)
        {
            try
            {
                dgvMain.DataSource = data;
                if (overrideGlobal)
                    Data = data;

                //adjust 'Viewing' label
                lblViewingValue.Text = $"{data.Rows.Count}/{Data.Rows.Count}";
            }
            catch
            {
                //ignore error
            }
        }

        private void LoadLog(LogType type)
        {
            try
            {
                //download data from modem
                var handler = new CgiSystemLog(type);
                var table = handler.GrabTable();

                //validate
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        //apply log to grid (and global)
                        SetDataSource(table, true);

                        //adjust 'Current Log File' label
                        lblCurrentLogFileValue.Text = type.ToString();
                    }
                    else
                        UiMessages.Warning(@"Modem returned 0 log entries; operation failed.");
                }
                else
                    UiMessages.Warning(@"Modem returned a null result; operation failed.");
            }
            catch (Exception ex)
            {
                UiMessages.Error($"Error whilst loading the log:\n\n{ex}");
            }
        }

        private void SystemLogs_Load(object sender, EventArgs e)
        {
        }

        public static void ShowSystemLogViewer()
        {
            var logViewer = new SystemLogs();
            logViewer.ShowDialog();
        }

        private void StartSearch()
        {
            var cxt = Search.StartSearch(SearchMode.Grid, Data);
            if (cxt.SearchSubmitted)
                DoGridSearch(cxt);
        }

        private void CancelSearch()
        {
            if (dgvMain.DataSource != null)
                SetDataSource(Data);

            itmSearch.Text = @"Search";
            itmLogType.Enabled = true;
        }

        private void DoGridSearch(SearchContext cxt)
        {
            var query = $"`{cxt.SearchColumn}` LIKE '%{cxt.SearchTerm}%'";
            var table = Data.Copy();
            var filteredTable = table.Select(query);

            if (filteredTable.Length > 0)
            {
                SetDataSource(filteredTable.CopyToDataTable());
                itmSearch.Text = @"Cancel Search";
                itmLogType.Enabled = false;
            }
            else
            {
                UiMessages.Warning($"Nothing found for '{cxt.SearchTerm}'", @"No Results");
                CancelSearch();
            }
        }

        private void ItmSearch_Click(object sender, EventArgs e)
        {
            if (dgvMain.DataSource != null)
                if (itmSearch.Text == @"Search")
                    StartSearch();
                else
                    CancelSearch();
        }

        private void ItmLogTypeAll_Click(object sender, EventArgs e)
        {
            LoadLog(LogType.FullLog);
        }

        private void ItmLogTypeTR069_Click(object sender, EventArgs e)
        {
            LoadLog(LogType.TR069Log);
        }

        private void ItmLogTypeSystem_Click(object sender, EventArgs e)
        {
            LoadLog(LogType.SystemLog);
        }

        private void ItmLogTypeHardware_Click(object sender, EventArgs e)
        {
            LoadLog(LogType.HardwareLog);
        }

        private void ItmLogTypeVOIP_Click(object sender, EventArgs e)
        {
            LoadLog(LogType.VOIPLog);
        }

        private void ItmLogTypeWAN_Click(object sender, EventArgs e)
        {
            LoadLog(LogType.WANLog);
        }

        private void ItmLogTypeWLAN_Click(object sender, EventArgs e)
        {
            LoadLog(LogType.WLANLog);
        }

        private void ItmLogTypeWiFiBooster_Click(object sender, EventArgs e)
        {
            LoadLog(LogType.BoosterLog);
        }

        private void ItmExportTXT_Click(object sender, EventArgs e)
        {
            try
            {
                if (Data != null)
                    if (Data.Rows.Count > 0)
                    {
                        var t = (DataTable)dgvMain.DataSource;
                        t.ExportThis(ExportFormat.Txt);
                    }
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }
        }
    }
}