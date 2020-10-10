using ArcConfigViewer.Enums;
using ArcConfigViewer.Extensions;
using libbrhscgui.Components;
using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

// ReSharper disable InconsistentNaming

namespace ArcConfigViewer.UI
{
    public partial class PhoneLog : Form
    {
        public DataTable Data { get; set; }
        public string HandsetColumn { get; set; } = @"Handset";

        public PhoneLog()
        {
            InitializeComponent();
        }

        private void PhoneLog_Load(object sender, EventArgs e)
        {
            SetDataSource(Data);
            PrepareUI();
            LoadHandsets();
        }

        public string VOIPNumberFormatted()
        {
            try
            {
                var voipNumber = VOIPNumber();

                if (!string.IsNullOrEmpty(voipNumber))
                {
                    var nationalNumber = PhoneNumberUtil.GetInstance()
                        .Parse(voipNumber, "");
                    var formattedNumber =
                        PhoneNumberUtil.GetInstance().Format(nationalNumber, PhoneNumberFormat.NATIONAL);
                    return formattedNumber;
                }
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }

            //default
            return @"";
        }

        public string VOIPNumber()
        {
            try
            {
                if (Data != null)
                    if (Data.Rows.Count > 0)
                        return
                            Data.Columns.Contains(@"VOIP #")
                                ? (string)Data.Rows[0][@"VOIP #"]
                                : @"";
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }

            //default
            return @"";
        }

        public long ColumnValueCount(string column, string filter)
        {
            try
            {
                if (Data != null)
                    if (Data.Rows.Count > 0)
                        return ((DataTable)dgvMain.DataSource)
                            .Select(
                                $"`{column}` LIKE '%{filter}%'"
                                )
                            .Length;
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }

            //default
            return 0;
        }

        public long PollTypeCount(string typeFilter)
        {
            //column to summarise
            const string column = @"Type";

            //poll and return filtered results
            return ColumnValueCount(column, typeFilter);
        }

        public double MissedCalls => PollTypeCount(@"MISS");
        public double OutCalls => PollTypeCount(@"OUT");
        public double InCalls => PollTypeCount(@"IN");

        private void UpdateCallCounts()
        {
            lblTotalMissedValue.Text = MissedCalls.ToString();
            lblTotalOutValue.Text = OutCalls.ToString();
            lblTotalInValue.Text = InCalls.ToString();
        }

        private void UpdateBilledCallTime()
        {
            //summarise all time (true for only 'OUT' calls)
            var t = TotalTime(true);
            lblTotalBilledTimeValue.Text =
                t.TotalSeconds > 0
                    ? t.ToString()
                    : @"Unknown";
        }

        private void UpdateTotalCallTime()
        {
            //summarise all time (false for all calls)
            var t = TotalTime();
            lblTotalCallTimeValue.Text =
                t.TotalSeconds > 0
                    ? t.ToString()
                    : @"Unknown";
        }

        private void UpdateCallRatio()
        {
            var i = InCalls;
            var o = OutCalls;

            //This ratio is (INCOMING):(OUTGOING)
            var ratioP1 = Math.Round(i / i, 3);
            var ratioP2 = Math.Round(o / i, 3);
            var ratioP3 = $"{ratioP1}:{ratioP2}";

            //update UI
            lblCallRatioValue.Text = ratioP3;
        }

        private TimeSpan TotalTime(bool justOutTime = false)
        {
            try
            {
                if (Data != null)
                    if (Data.Rows.Count > 0)
                    {
                        var totalTime = new TimeSpan(0);
                        var t = (DataTable)dgvMain.DataSource;
                        if (t != null)
                            foreach (DataRow r in t.Rows)
                            {
                                try
                                {
                                    if (r[@"Type"] != null)
                                        if (!r[@"Type"].ToString().Contains(@"OUT") && justOutTime)
                                            continue;

                                    if (r[@"Duration"] != null)
                                        if (!string.IsNullOrWhiteSpace((string)r[@"Duration"]))
                                        {
                                            var v = (string)r[@"Duration"];
                                            var d = TimeSpan.Parse(v);
                                            totalTime = totalTime.Add(d);
                                        }
                                }
                                catch
                                {
                                    /* ignore */
                                }
                            }

                        return totalTime;
                    }
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }

            //default
            return TimeSpan.Zero;
        }

        public void SetDataSource(DataTable source)
        {
            dgvMain.DataSource = source;
            UpdateCallCounts();
            UpdateBilledCallTime();
            UpdateTotalCallTime();
            UpdateCallRatio();
        }

        public static void LoadLog(DataTable log)
        {
            var logForm = new PhoneLog
            {
                Data = log
            };
            logForm.ShowDialog();
        }

        private void PrepareUI()
        {
            if (Data != null)
                if (Data.Rows.Count > 0)
                {
                    itmSearch.Enabled = true;
                    itmHandset.Enabled = true;
                    itmExport.Enabled = true;
                    lblVoipValue.Text = VOIPNumberFormatted();
                }
        }

        private void LoadHandsets()
        {
            try
            {
                if (Data != null)
                {
                    if (Data.Rows.Count > 0)
                    {
                        if (Data.Columns.Contains(HandsetColumn))
                        {
                            //get only distinct (unique; no duplicates) handsets
                            var uniqueHandsets = Data.DefaultView.ToTable(true, HandsetColumn);
                            var handsetsList = new List<string>();

                            //filter out nulls
                            for (var i = 0; i < uniqueHandsets.Rows.Count; i++)
                            {
                                var u = uniqueHandsets.Rows[i];
                                if (u[0] != null)
                                    if (!string.IsNullOrWhiteSpace((string)u[0]))
                                        handsetsList.Add((string)u[0]);
                            }

                            //clear existing handset controls
                            itmHandset.DropDownItems.Clear();

                            //add controls
                            var i_ = 0;
                            foreach (var h in handsetsList)
                            {
                                //construct new menu item for handset
                                var dropDown = new ToolStripMenuItem
                                {
                                    Name = $"Handset{i_}",
                                    Text = h
                                };

                                //give the new item a handler so it can do its work
                                dropDown.Click += HandsetFilterHandler;

                                //add to menu
                                itmHandset.DropDownItems.Add(dropDown);

                                //counter
                                i_++;
                            }

                            //prompt repaint
                            itmHandset.Invalidate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }
        }

        private void HandsetFilterHandler(object sender, EventArgs e)
        {
            try
            {
                //double check the sender's authenticity as a menu item
                if (sender.GetType() == typeof(ToolStripMenuItem))
                {
                    //recast sender to restore type
                    var handsetItem = (ToolStripMenuItem)sender;

                    //value to filter is the menu item's text
                    var filterBy = handsetItem.Text;

                    //new search context for filtering
                    var searchContext = new SearchContext
                    {
                        SearchColumn = HandsetColumn,
                        SearchSubmitted = true,
                        SearchTerm = filterBy
                    };

                    //set UI
                    itmSearch.Text = @"Cancel Search";
                    itmHandset.Enabled = false;

                    //initialise search
                    DoGridSearch(searchContext);
                }
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }
        }

        private void BillPrice()
        {
            try
            {
                //make sure there's an actual value to calculate
                if (lblTotalBilledTimeValue.Text != @"Unknown"
                    && lblTotalBilledTimeValue.Text != @"00:00:00")
                {
                    var guiHandler = new UserInteraction();
                    var r = guiHandler.showInputForm(@"Enter call charge per minute",
                        @"Bill Price Prediction");
                    if (r.txt != @"!cancel=user")
                    {
                        if (decimal.TryParse(r.txt, out var callCharge))
                        {
                            //convert existing label back to a time value
                            var t = TimeSpan.Parse(lblTotalBilledTimeValue.Text);
                            var m = Convert.ToDecimal(t.TotalMinutes);

                            if (callCharge > 0)
                            {
                                var p = Math.Round(m * callCharge, 2);

                                UiMessages.Info($"You're looking at around ${p} ({Math.Round(m, 2)} minutes) worth of outgoing calls");
                            }
                            else
                                UiMessages.Info($"You're looking at $0.00 ({Math.Round(m, 2)} minutes) worth of outgoing calls");
                        }
                        else
                            UiMessages.Error(@"Your value wasn't valid; ensure it's a number and try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }
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
            itmHandset.Enabled = true;
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
                itmHandset.Enabled = false;
            }
            else
            {
                UiMessages.Warning($"Nothing found for '{cxt.SearchTerm}'", @"No Results");
                CancelSearch();
            }
        }

        private void ItmExportJson_Click(object sender, EventArgs e)
        {
            try
            {
                if (Data != null)
                    if (Data.Rows.Count > 0)
                    {
                        var t = (DataTable)dgvMain.DataSource;
                        t.ExportThis(ExportFormat.Json);
                    }
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }
        }

        private void ItmExportCsv_Click(object sender, EventArgs e)
        {
            try
            {
                if (Data != null)
                    if (Data.Rows.Count > 0)
                    {
                        var t = (DataTable)dgvMain.DataSource;
                        t.ExportThis(ExportFormat.Csv);
                    }
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }
        }

        private void ItmExportXml_Click(object sender, EventArgs e)
        {
            try
            {
                if (Data != null)
                    if (Data.Rows.Count > 0)
                    {
                        var t = (DataTable)dgvMain.DataSource;
                        t.ExportThis(ExportFormat.Xml);
                    }
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
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

        private void LblTotalBilledTimeValue_Click(object sender, EventArgs e)
        {
            BillPrice();
        }

        private void LblTotalBilledTime_Click(object sender, EventArgs e)
        {
            BillPrice();
        }
    }
}