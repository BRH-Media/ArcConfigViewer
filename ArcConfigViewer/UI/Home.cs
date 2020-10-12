using ArcAuthentication;
using ArcAuthentication.CGI;
using ArcAuthentication.Security;
using ArcConfigKeyExtractor;
using ArcConfigViewer.Enums;
using ArcConfigViewer.Extensions;
using ArcProcessor;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using ArcAuthentication.CGI.DataService;
using ArcAuthentication.UI;

// ReSharper disable UnusedMember.Local
// ReSharper disable InconsistentNaming
// ReSharper disable InvertIf

namespace ArcConfigViewer.UI
{
    public partial class Home : Form
    {
        public string CurrentFile { get; set; } = @"";
        public DataTable OriginalData { get; set; }

        public Home()
        {
            InitializeComponent();
        }

        private void TrvMain_AfterSelect(TreeNode n)
        {
            var eventArgs = new TreeViewEventArgs(n);
            TrvMain_AfterSelect(eventArgs);
        }

        private void TrvMain_AfterSelect(TreeViewEventArgs e)
        {
            TrvMain_AfterSelect(null, e);
        }

        private void TrvMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (File.Exists(e.Node.Name))
                //X.509 certificates
                if (e.Node.Name.EndsWith(@".crt"))
                {
                    var certBytes = File.ReadAllBytes(e.Node.Name);
                    var cert = new X509Certificate2(certBytes);
                    X509Certificate2UI.DisplayCertificate(cert);
                }
                //Arcadyan config
                else if (e.Node.Name.EndsWith(@".dft") || e.Node.Name.EndsWith(@".glbcfg"))
                {
                    SetTable(FileToDataTable(e.Node.Name));
                }
                //SQLite Databases
                else if (e.Node.Name.EndsWith(@".db") || e.Node.Name.EndsWith(@".sqlite"))
                {
                    SqliteBrowser.ShowBrowser(e.Node.Name);
                }
                //Anything else is treated as a text file
                else
                {
                    //try text load
                    SetText(File.ReadAllText(e.Node.Name));
                }
            else
            {
                SetClear();
            }
        }

        private void LoadTreeView(string directory)
        {
            if (Directory.Exists(directory))
            {
                if (InvokeRequired)
                {
                    BeginInvoke((MethodInvoker)delegate
                    {
                        //load tree view
                        trvMain.Nodes.Clear();
                        TreeBuilder.BuildTree(new DirectoryInfo(directory), trvMain.Nodes);

                        //do node transform if any exist
                        if (trvMain.Nodes.Count > 0)
                        {
                            //reference root node
                            var root = trvMain.Nodes[0];

                            //expand root node
                            root.Expand();

                            //select first sub node if there are any
                            if (root.Nodes.Count > 0)
                            {
                                var firstSubNode = root.Nodes[0];
                                trvMain.SelectedNode = firstSubNode;
                                TrvMain_AfterSelect(firstSubNode);
                            }
                        }
                    });
                }
                else
                {
                    //load tree view
                    trvMain.Nodes.Clear();
                    TreeBuilder.BuildTree(new DirectoryInfo(directory), trvMain.Nodes);

                    //do node transform if any exist
                    if (trvMain.Nodes.Count > 0)
                    {
                        //reference root node
                        var root = trvMain.Nodes[0];

                        //expand root node
                        root.Expand();

                        //select first sub node if there are any
                        if (root.Nodes.Count > 0)
                        {
                            var firstSubNode = root.Nodes[0];
                            trvMain.SelectedNode = firstSubNode;
                            TrvMain_AfterSelect(firstSubNode);
                        }
                    }
                }
            }
        }

        private void ItmFileOpenConfig_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(ArcArchive.ExtractDir))
            {
                if (Directory.GetFiles(ArcArchive.ExtractDir).Length > 0)
                    if (UiMessages.Question(@"You already have an extracted config file; load it instead?"))
                    {
                        LoadTreeView(ArcArchive.ExtractDir);
                        return;
                    }
            }

            var filePath = GetFileName();

            if (!string.IsNullOrEmpty(filePath))
            {
                CurrentFile = filePath;

                //decrypt and extract
                ArcArchive.ProcessConfigArchive(filePath);

                //UI setup
                LoadTreeView(ArcArchive.ExtractDir);
                itmRefreshConfig.Enabled = true;
            }
        }

        private static DataTable FileToDataTable(string filePath)
        {
            try
            {
                var table = new DataTable(@"LH1000_Config");
                table.Columns.Add(@"Setting", typeof(string));
                table.Columns.Add(@"Value", typeof(string));

                var decompressedString = File.ReadAllText(filePath);
                var lineSplit = decompressedString.Split(
                    new[] { "\r\n", "\r", "\n" },
                    StringSplitOptions.None
                ).ToList();

                //trim first line due to gibberish
                lineSplit.RemoveAt(0);

                const char delimiter = '=';
                foreach (object[] s in lineSplit.Select(l => l.Split(delimiter)).Where(s => s.Length == 2))
                {
                    table.Rows.Add(s);
                }

                return table;
            }
            catch (Exception ex)
            {
                UiMessages.Error($"Data load error:\n\n{ex}");
            }

            //default
            return null;
        }

        private void DoubleClickProcessor(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderType = sender.GetType();
                var gridType = typeof(DataGridView);
                if (senderType == gridType)
                {
                    var gridView = (DataGridView)sender;

                    if (gridView.Rows.Count <= 0) return;

                    var value = gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        Clipboard.SetText(value);
                        //UiMessages.Info(value, @"Cell Content");
                    }
                }
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }
        }

        private string GetFileName()
        {
            return ofdRouterConfiguration.ShowDialog() == DialogResult.OK ? ofdRouterConfiguration.FileName : @"";
        }

        private void SetText(string text)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    dgvMain.Enabled = false;
                    dgvMain.Visible = false;
                    dgvMain.DataSource = null;

                    txtMain.Text = text;
                    txtMain.Enabled = true;
                    txtMain.Visible = true;

                    itmExport.Enabled = false;

                    itmSearch.Enabled = true;
                    CancelSearch();

                    lnkCopy.Enabled = true;
                    lnkCopy.Visible = true;
                    CopyLabelPosition();
                });
            }
            else
            {
                dgvMain.Enabled = false;
                dgvMain.Visible = false;
                dgvMain.DataSource = null;

                txtMain.Text = text;
                txtMain.Enabled = true;
                txtMain.Visible = true;

                itmExport.Enabled = false;

                itmSearch.Enabled = true;
                CancelSearch();

                lnkCopy.Enabled = true;
                lnkCopy.Visible = true;
                CopyLabelPosition();
            }
        }

        private void SetTable(DataTable table)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    txtMain.Enabled = false;
                    txtMain.Visible = false;
                    txtMain.Clear();

                    dgvMain.Enabled = true;
                    dgvMain.Visible = true;
                    dgvMain.DataSource = table;

                    itmExport.Enabled = true;

                    itmSearch.Enabled = true;
                    CancelSearch();

                    lnkCopy.Enabled = false;
                    lnkCopy.Visible = false;
                });
            }
            else
            {
                txtMain.Enabled = false;
                txtMain.Visible = false;
                txtMain.Clear();

                dgvMain.Enabled = true;
                dgvMain.Visible = true;
                dgvMain.DataSource = table;

                itmExport.Enabled = true;

                itmSearch.Enabled = true;
                CancelSearch();

                lnkCopy.Enabled = false;
                lnkCopy.Visible = false;
            }

            //set global values
            OriginalData = table;
        }

        private void SetClear()
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    dgvMain.Enabled = false;
                    dgvMain.Visible = false;
                    dgvMain.DataSource = null;

                    txtMain.Clear();
                    txtMain.Enabled = true;
                    txtMain.Visible = true;

                    itmExport.Enabled = false;

                    itmSearch.Enabled = false;
                    CancelSearch();
                });
            }
            else
            {
                dgvMain.Enabled = false;
                dgvMain.Visible = false;
                dgvMain.DataSource = null;

                txtMain.Clear();
                txtMain.Enabled = true;
                txtMain.Visible = true;

                itmExport.Enabled = false;

                itmSearch.Enabled = false;
                CancelSearch();
            }
        }

        private void CopyLabelPosition()
        {
            const int offset = 10;

            var txtPos = txtMain.Location;
            var txtSze = txtMain.Size;

            var lblSze = lnkCopy.Size;

            var newX = (txtPos.X + txtSze.Width) - lblSze.Width - offset;
            var newY = (txtPos.Y + txtSze.Height) - lblSze.Height - offset;

            lnkCopy.Location = new Point(newX, newY);
        }

        private void CancelSearch()
        {
            if (dgvMain.Visible)
            {
                if (dgvMain.DataSource != null)
                    dgvMain.DataSource = OriginalData;
            }
            else
            {
                if (!string.IsNullOrEmpty(txtMain.Text))
                {
                    txtMain.SelectionStart = 0;
                    txtMain.SelectAll();
                    txtMain.SelectionBackColor = SystemColors.Control;
                }
            }

            itmSearch.Text = @"Search";
        }

        private void StartSearch()
        {
            if (dgvMain.Visible)
            {
                var cxt = Search.StartSearch(SearchMode.Grid, (DataTable)dgvMain.DataSource);
                if (cxt.SearchSubmitted)
                {
                    DoGridSearch(cxt);
                }
            }
            else
            {
                var cxt = Search.StartSearch(SearchMode.Text);
                if (cxt.SearchSubmitted)
                {
                    DoTextSearch(cxt);
                }
            }
        }

        private void DoTextSearch(SearchContext cxt)
        {
            var startIndex = 0;
            var foundMatch = false;

            while (startIndex < txtMain.TextLength)
            {
                var wordStartIndex = txtMain.Find(cxt.SearchTerm, startIndex, RichTextBoxFinds.None);
                if (wordStartIndex > -1)
                {
                    foundMatch = true;

                    txtMain.SelectionStart = wordStartIndex;
                    txtMain.SelectionLength = cxt.SearchTerm.Length;
                    txtMain.SelectionBackColor = Color.Yellow;
                }
                else
                    break;

                startIndex += wordStartIndex + cxt.SearchTerm.Length;
            }

            if (!foundMatch)
            {
                UiMessages.Warning($"Nothing found for '{cxt.SearchTerm}'", @"No Results");
                CancelSearch();
            }
            else
                itmSearch.Text = @"Cancel Search";
        }

        private void DoGridSearch(SearchContext cxt)
        {
            var query = $"`{cxt.SearchColumn}` LIKE '%{cxt.SearchTerm}%'";
            var table = OriginalData.Copy();
            var filteredTable = table.Select(query);

            if (filteredTable.Length > 0)
            {
                dgvMain.DataSource = filteredTable.CopyToDataTable();
                itmSearch.Text = @"Cancel Search";
            }
            else
            {
                UiMessages.Warning($"Nothing found for '{cxt.SearchTerm}'", @"No Results");
                CancelSearch();
            }
        }

        private void TxtMain_Resize(object sender, EventArgs e)
        {
            CopyLabelPosition();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            CopyLabelPosition();

            //update menu to reflect auth status
            //this retains the status after the program is closed
            UIAuthUpdate();
        }

        private void ItmRefreshConfig_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CurrentFile))
                ArcArchive.ProcessConfigArchive(CurrentFile);
        }

        private void LnkCopy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMain.Text))
                Clipboard.SetText(txtMain.Text);
        }

        private void ItmExportCfg_Click(object sender, EventArgs e)
        {
            if (dgvMain.DataSource != null && dgvMain.Visible)
            {
                var t = (DataTable)dgvMain.DataSource;
                t.ExportThis(ExportFormat.Cfg);
            }
        }

        private void ItmExportCsv_Click(object sender, EventArgs e)
        {
            if (dgvMain.DataSource != null && dgvMain.Visible)
            {
                var t = (DataTable)dgvMain.DataSource;
                t.ExportThis(ExportFormat.Csv);
            }
        }

        private void ItmExportXml_Click(object sender, EventArgs e)
        {
            if (dgvMain.DataSource != null && dgvMain.Visible)
            {
                var t = (DataTable)dgvMain.DataSource;
                t.ExportThis(ExportFormat.Xml);
            }
        }

        private void ItmExportJson_Click(object sender, EventArgs e)
        {
            if (dgvMain.DataSource != null && dgvMain.Visible)
            {
                var t = (DataTable)dgvMain.DataSource;
                t.ExportThis(ExportFormat.Json);
            }
        }

        private void ItmSearch_Click(object sender, EventArgs e)
        {
            if (itmSearch.Text == @"Search")
                StartSearch();
            else
                CancelSearch();
        }

        private void ItmConnectedDevicesList_Click(object sender, EventArgs e)
        {
            try
            {
                //test authentication
                var success = Authenticated();

                if (success)
                {
                    var init = new CgiStations();
                    var dt = init.GrabTable();

                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            ConnectedDevices.ShowConnectedDevices(dt);
                        }
                        else
                            UiMessages.Warning(
                                @"Topology info from modem returned 0 devices connected; operation failed.",
                                @"Data Error");
                    }
                    else
                        UiMessages.Warning("Topology info from modem returned nothing useful. " +
                                           "Please note that this is rate-limited, and the modem will reject too many requests within an undefined time-frame.",
                            @"Data Error");
                }
                else
                    UiMessages.Warning(@"Authentication required; please authenticate first.");
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }
        }

        private void ItmFetchFromModem_Click(object sender, EventArgs e)
        {
            try
            {
                //test authentication
                var success = Authenticated();

                if (success)
                {
                    var cfg = new CgiConfigFile();
                    var file = cfg.GrabFile();

                    if (file != null)
                    {
                        if (file.Length > 0)
                        {
                            ArcArchive.ProcessConfigArchive(file);

                            //update UI
                            LoadTreeView(ArcArchive.ExtractDir);
                        }
                        else
                            UiMessages.Warning(@"Configuration file from modem returned 0 bytes; operation failed.",
                                @"Data Error");
                    }
                    else
                        UiMessages.Warning(@"Configuration file from modem returned null bytes; operation failed.",
                            @"Data Error");
                }
                else
                    UiMessages.Warning(@"Authentication required; please authenticate first.");
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }
        }

        private void ItmCallLog_Click(object sender, EventArgs e)
        {
            try
            {
                //test authentication
                var success = Authenticated();

                if (success)
                {
                    var log = new CgiCallLog();
                    var table = log.GrabTable();

                    if (table != null)
                    {
                        if (table.Rows.Count > 0)
                        {
                            PhoneLog.LoadLog(table);
                        }
                        else
                            UiMessages.Warning(@"Call log from modem returned 0 rows; operation failed.", @"Data Error");
                    }
                    else
                        UiMessages.Warning(@"Call log from modem returned null bytes; operation failed.", @"Data Error");
                }
                else
                    UiMessages.Warning(@"Authentication required; please authenticate first.");
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }
        }

        private void ItmFetchSystemLogs_Click(object sender, EventArgs e)
        {
            try
            {
                //test authentication
                var success = Authenticated();

                if (success)
                    SystemLogs.ShowSystemLogViewer();
                else
                    UiMessages.Warning(@"Authentication required; please authenticate first.");
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }
        }

        private void ItmFirmwareVersion_Click(object sender, EventArgs e)
        {
            try
            {
                //test authentication
                var success = Authenticated();

                if (success)
                    FirmwareVersion.ShowVersionInfo();
                else
                    UiMessages.Warning(@"Authentication required; please authenticate first.");
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }
        }

        private void UpdateUIAuthenticate(bool authenticated = false)
        {
            try
            {
                itmAuthenticateGrant.Enabled = !authenticated;
                itmTryDefault.Enabled = !authenticated;
                itmAuthenticateRevoke.Enabled = authenticated;
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }
        }

        private static bool Authenticated(bool tryLogin = false)
        {
            try
            {
                var testLogin = ArcLogin.TestLogin();
                if (!testLogin && tryLogin)
                {
                    var loginTry = LoginForm.ShowLogin();
                    return loginTry;
                }

                return testLogin;
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }

            //default
            return false;
        }

        private void UIAuthUpdate()
        {
            try
            {
                //test authentication
                var testLogin = ArcLogin.TestLogin();
                if (testLogin)
                    UpdateUIAuthenticate(true);
                else if (Global.InitToken == null)
                    UpdateUIAuthenticate();
                else
                    UpdateUIAuthenticate();
            }
            catch (Exception)
            {
                //ignore all errors
            }
        }

        private void ItmAuthenticateGrant_Click(object sender, EventArgs e)
        {
            try
            {
                //test authentication
                var testLogin = ArcLogin.TestLogin();
                if (testLogin)
                    UiMessages.Warning(@"Authentication failed: user is already authenticated");
                else if (Global.InitToken == null)
                {
                    var loginSuccess = LoginForm.ShowLogin();
                    if (loginSuccess)
                    {
                        UpdateUIAuthenticate(true);
                        UiMessages.Info(@"Successfully authenticated user");
                    }
                    else
                        UiMessages.Warning(@"Authentication failed: login was unsuccessful");
                }
                else
                    UiMessages.Warning(@"Authentication failed: login data already initialised");
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }
        }

        private void ItmAuthenticateRevoke_Click(object sender, EventArgs e)
        {
            try
            {
                //test authentication
                var testLogin = ArcLogin.TestLogin();
                if (!testLogin)
                    UiMessages.Warning(@"Revocation failed: login not yet initiated");
                else if (Global.InitToken != null)
                {
                    var logoutSuccess = Global.InitToken.Revoke();
                    if (logoutSuccess)
                    {
                        UpdateUIAuthenticate();
                        Global.InitToken = null;
                        UiMessages.Info(@"Successfully logged user out");
                    }
                    else
                        UiMessages.Warning(@"Revocation failed: logout was unsuccessful");
                }
                else
                    UiMessages.Warning(@"Revocation failed: login data not yet initiated");
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }
        }

        private void ItmTryDefault_Click(object sender, EventArgs e)
        {
            try
            {
                //test authentication
                var testLogin = ArcLogin.TestLogin();
                if (testLogin)
                    UiMessages.Warning(@"Authentication failed: user is already authenticated");
                else if (Global.InitToken == null)
                {
                    //LH1000 default is admin:Telstra
                    var defaultLogin = new ArcCredential(@"admin", @"Telstra");

                    //login with default credentials
                    var loginSuccess = ArcLogin.DoLogin(defaultLogin);
                    if (loginSuccess)
                    {
                        UpdateUIAuthenticate(true);
                        UiMessages.Info(@"Successfully authenticated user");
                    }
                    else
                        UiMessages.Warning(@"Authentication failed: login was unsuccessful");
                }
                else
                    UiMessages.Warning(@"Authentication failed: login data already initialised");
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }
        }

        private void ItmElfDecryptionKey_Click(object sender, EventArgs e)
        {
            var elfProcessor = new ElfDissector(@"httpd");
            elfProcessor.ExtractStrings();
        }

        private void ItmExploits_Click(object sender, EventArgs e)
        {
        }

        private void ItmExploitTelnet_Click(object sender, EventArgs e)
        {
        }
    }
}