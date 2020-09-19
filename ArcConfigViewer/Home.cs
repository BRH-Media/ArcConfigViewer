using ArcConfigViewer.Enums;
using ArcConfigViewer.Extensions;
using ICSharpCode.SharpZipLib.Tar;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using WaitWindow;

// ReSharper disable InvertIf

namespace ArcConfigViewer
{
    public partial class Home : Form
    {
        public string CurrentFile { get; set; } = @"";
        public const string ExtractDir = @"config";
        public DataTable OriginalData { get; set; } = null;

        public Home()
        {
            InitializeComponent();
        }

        private static byte[] DecompressBytes(byte[] gzBytes)
        {
            try
            {
                byte[] decompressedBytes;
                using (var rawStream = new MemoryStream(gzBytes))
                {
                    using (var decompressionStream = new GZipStream(rawStream, CompressionMode.Decompress))
                    {
                        var ms = new MemoryStream();
                        decompressionStream.CopyTo(ms);
                        decompressedBytes = ms.ToArray();
                    }
                }

                return decompressedBytes;
            }
            catch (Exception ex)
            {
                UiMessages.Error($"Decompression failed!\n\n{ex}");
                return null;
            }
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

        private void ProcessConfigArchive(object sender, WaitWindowEventArgs e)
        {
            var fileName = (string)e.Arguments[0];
            ProcessConfigArchive(fileName, false);
        }

        private void ProcessConfigArchive(string fileName, bool waitWindow = true)
        {
            if (waitWindow)
            {
                WaitWindow.WaitWindow.Show(ProcessConfigArchive, @"Processing archive...", fileName);
            }
            else
            {
                if (File.Exists(fileName))
                {
                    var tar = DecryptDecompress(fileName);
                    using (var sourceStream = new MemoryStream(tar))
                    {
                        using (var tarArchive = TarArchive.CreateInputTarArchive(sourceStream, TarBuffer.DefaultBlockFactor))
                        {
                            if (Directory.Exists(ExtractDir))
                                Directory.Delete(ExtractDir, true);
                            //put 'config' folder in current directory
                            tarArchive.ExtractContents(@".\");

                            //UI load
                            LoadTreeView(ExtractDir);
                        }
                    }
                }
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

                        if (trvMain.Nodes.Count > 0)
                            //expand root node
                            trvMain.Nodes[0].Expand();
                    });
                }
                else
                {
                    //load tree view
                    trvMain.Nodes.Clear();
                    TreeBuilder.BuildTree(new DirectoryInfo(directory), trvMain.Nodes);

                    if (trvMain.Nodes.Count > 0)
                        //expand root node
                        trvMain.Nodes[0].Expand();
                }
            }
        }

        private void ItmFileOpenConfig_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(ExtractDir))
            {
                if (Directory.GetFiles(ExtractDir).Length > 0)
                    if (UiMessages.Question(@"You already have an extracted config file; load it instead?"))
                    {
                        LoadTreeView(ExtractDir);
                        return;
                    }
            }

            var filePath = GetFileName();
            if (!string.IsNullOrEmpty(filePath))
            {
                CurrentFile = filePath;

                ProcessConfigArchive(filePath);

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

        private static byte[] DecryptDecompress(string filePath)
        {
            return DecompressBytes(LoadFileAndDecrypt(filePath));
        }

        private static byte[] LoadFileAndDecrypt(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    const string password = @"2&15u69A";
                    var cipherBytes = File.ReadAllBytes(filePath);
                    var decryptedBytes = OpenSslAes.Decrypt(cipherBytes, password);
                    return decryptedBytes;
                }
            }
            catch (Exception ex)
            {
                UiMessages.Error($"Decryption error:\n\n{ex}");
            }

            //default
            return null;
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
                    DoGridSearch(cxt);
            }
            else
            {
                var cxt = Search.StartSearch(SearchMode.Text);
                if (cxt.SearchSubmitted)
                    DoTextSearch(cxt);
            }

            itmSearch.Text = @"Cancel Search";
        }

        private void DoTextSearch(SearchContext cxt)
        {
            var startIndex = 0;

            while (startIndex < txtMain.TextLength)
            {
                var wordStartIndex = txtMain.Find(cxt.SearchTerm, startIndex, RichTextBoxFinds.None);
                if (wordStartIndex > -1)
                {
                    txtMain.SelectionStart = wordStartIndex;
                    txtMain.SelectionLength = cxt.SearchTerm.Length;
                    txtMain.SelectionBackColor = Color.Yellow;
                }
                else
                    break;

                startIndex += wordStartIndex + cxt.SearchTerm.Length;
            }
        }

        private void DoGridSearch(SearchContext cxt)
        {
            var query = $"`{cxt.SearchColumn}` LIKE '%{cxt.SearchTerm}%'";
            var table = OriginalData.Copy();
            var filteredTable = table.Select(query);

            if (filteredTable.Length > 0)
                dgvMain.DataSource = filteredTable.CopyToDataTable();
            else
                UiMessages.Error($"Nothing found for '{cxt.SearchTerm}'", @"No Results");
        }

        private void TxtMain_Resize(object sender, EventArgs e)
        {
            CopyLabelPosition();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            CopyLabelPosition();
        }

        private void ItmRefreshConfig_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CurrentFile))
                ProcessConfigArchive(CurrentFile);
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
    }
}