using ArcConfigViewer.Enums;
using ArcConfigViewer.Extensions;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ArcConfigViewer
{
    public partial class ConnectedDevices : Form
    {
        public DataTable Data { get; set; }
        public bool LinkRateAverageOnlineOnly { get; set; } = true;

        public ConnectedDevices()
        {
            InitializeComponent();
        }

        private void ConnectedDevices_Load(object sender, EventArgs e)
        {
            SetDataSource(Data);
        }

        private void UpdateOnlineOfflineCount()
        {
            try
            {
                decimal countOnline = 0;
                decimal countOffline = 0;

                var t = (DataTable)dgvMain.DataSource;

                foreach (DataRow r in t.Rows)
                {
                    var onlineStatus = (string)r[@"Online"];

                    if (onlineStatus == @"Offline" || onlineStatus == @"0")
                        countOffline++;
                    else
                        countOnline++;
                }

                var onlinePercentage = countOffline > 0 && countOnline > 0
                    ? Math.Round(countOnline / t.Rows.Count * 100, 2)
                    : 0;

                //apply new values
                lblOfflineCount.Text = countOffline.ToString();
                lblOnlineCount.Text = countOnline.ToString();
                lblOnlinePerc.Text = $"{onlinePercentage}%";
            }
            catch
            {
                lblOfflineCount.Text = @"0";
                lblOnlineCount.Text = @"0";
                lblOnlinePerc.Text = @"0.00%";
                //ignore
            }
        }

        private void UpdateOnlineColour()
        {
            try
            {
                foreach (DataGridViewRow r in dgvMain.Rows)
                {
                    if (r.Cells[0] != null)
                    {
                        if (bool.TryParse(r.Cells[0].Value.ToString(), out var b))
                        {
                            var style = new DataGridViewCellStyle
                            {
                                BackColor = b ? Color.Green : Color.Red,
                                SelectionBackColor = b ? Color.Green : Color.Red,
                                Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold),
                                ForeColor = Color.White
                            };
                            r.Cells[0].Value = b ? @"Online" : @"Offline";
                            r.Cells[0].Style = style;
                        }
                    }
                }
            }
            catch
            {
                //ignore
            }
        }

        private void SetDataSource(DataTable data)
        {
            //original data count and the data count currently being viewed
            var originalCount = Data.Rows.Count;
            var newCount = data.Rows.Count;

            //update the count label
            lblViewingValue.Text = $"{newCount}/{originalCount}";

            //apply new data
            dgvMain.DataSource = data;

            //fix UI online colours
            UpdateOnlineColour();

            //calculate and update link rate average
            UpdateLinkRateAverage(LinkRateAverageOnlineOnly);

            //apply and calculate offline/online counter
            UpdateOnlineOfflineCount();
        }

        public void UpdateLinkRateAverage(bool onlyLineLinks)
        {
            //calculate average to nearest whole number
            var lnkAverage = Math.Round(AvgLinkRate(onlyLineLinks));

            //set average
            lblAvgLinkRateValue.Text = $"{lnkAverage}Mbps";
        }

        public decimal AvgLinkRate(bool onlyOnlineLinks)
        {
            try
            {
                var t = (DataTable)dgvMain.DataSource;

                if (t != null)
                    if (t.Rows.Count > 0)
                    {
                        var lnkRateCount = t.Rows.Count;
                        var lnkRateSum = 0;

                        foreach (DataRow l in t.Rows)
                        {
                            try
                            {
                                var rawLinkRate = ((string)l[@"Link Rate"]).Substring(0, ((string)l[@"Link Rate"]).Length - 4);
                                var r = Convert.ToInt32(rawLinkRate);

                                if (((string)l[@"Online"] == @"Offline" || (string)l[@"Online"] == @"0") && onlyOnlineLinks)
                                    lnkRateCount--;
                                else
                                    lnkRateSum += r;
                            }
                            catch (Exception ex)
                            {
                                UiMessages.Error(ex.ToString());
                                break;
                            }
                        }

                        //calculate average
                        var lnkAverage =
                            lnkRateSum > 0 && lnkRateCount > 0
                            ? lnkRateSum / lnkRateCount
                            : 0;

                        //return average
                        return lnkAverage;
                    }
            }
            catch (Exception ex)
            {
                UiMessages.Error($"Link rate maths error: {ex.Message}");
            }

            //default
            return 0;
        }

        public static void ShowConnectedDevices(DataTable devices)
        {
            var frm = new ConnectedDevices
            {
                Data = devices
            };
            frm.ShowDialog();
        }

        private void DoGridSearch(SearchContext cxt)
        {
            var query = $"`{cxt.SearchColumn}` LIKE '%{cxt.SearchTerm}%'";
            var table = Data.Copy();
            var filteredTable = table.Select(query);

            if (filteredTable.Length > 0)
                SetDataSource(filteredTable.CopyToDataTable());
            else
            {
                UiMessages.Warning($"Nothing found for '{cxt.SearchTerm}'", @"No Results");
                CancelSearch();
            }
        }

        private void StartSearch()
        {
            var cxt = Search.StartSearch(SearchMode.Grid, Data);
            if (cxt.SearchSubmitted)
            {
                DoGridSearch(cxt);

                itmSearch.Text = @"Cancel Search";
            }
        }

        private void CancelSearch()
        {
            if (dgvMain.DataSource != null)
                SetDataSource(Data);

            itmSearch.Text = @"Search";
        }

        private void ItmExportCSV_Click(object sender, EventArgs e)
        {
            try
            {
                var t = (DataTable)dgvMain.DataSource;

                if (t != null)
                    if (t.Rows.Count > 0)
                        t.ExportThis(ExportFormat.Csv);
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }
        }

        private void ItmExportJSON_Click(object sender, EventArgs e)
        {
            try
            {
                var t = (DataTable)dgvMain.DataSource;

                if (t != null)
                    if (t.Rows.Count > 0)
                        t.ExportThis(ExportFormat.Json);
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }
        }

        private void ItmExportXML_Click(object sender, EventArgs e)
        {
            try
            {
                var t = (DataTable)dgvMain.DataSource;

                if (t != null)
                    if (t.Rows.Count > 0)
                        t.ExportThis(ExportFormat.Xml);
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }
        }

        private void ItmSearch_Click(object sender, EventArgs e)
        {
            if (itmSearch.Text == @"Search")
                StartSearch();
            else
                CancelSearch();
        }

        private void ItmAvgOnlineOnly_Click(object sender, EventArgs e)
        {
            LinkRateAverageOnlineOnly = itmAvgOnlineOnly.Checked;
            UpdateLinkRateAverage(LinkRateAverageOnlineOnly);
        }
    }
}