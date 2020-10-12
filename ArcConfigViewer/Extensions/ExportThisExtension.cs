using ArcConfigViewer.Enums;
using ArcProcessor;
using ArcWaitWindow;
using System.Data;
using System.Windows.Forms;

namespace ArcConfigViewer.Extensions
{
    public static class ExportThisExtension
    {
        private static void ExportThis(object sender, ArcWaitWindowEventArgs e)
        {
            if (e.Arguments.Count != 4) return;

            var table = (DataTable)e.Arguments[0];
            var format = (ExportFormat)e.Arguments[1];
            var fileName = (string)e.Arguments[2];
            var silent = (bool)e.Arguments[3];
            ExportThis(table, format, fileName, silent, false);
        }

        public static void ExportThis(this DataTable table, ExportFormat format, string fileName, bool silent = false, bool waitWindow = true)
        {
            if (waitWindow)
            {
                ArcWaitWindow.ArcWaitWindow.Show(ExportThis, @"Exporting...", table, format, fileName, silent);
            }
            else
            {
                var success = true;

                switch (format)
                {
                    case ExportFormat.Json:
                        table.ToJson(fileName);
                        break;

                    case ExportFormat.Xml:
                        table.ToXml(fileName);
                        break;

                    case ExportFormat.Csv:
                        table.ToCsv(fileName);
                        break;

                    case ExportFormat.Cfg:
                        table.ToCfg(fileName);
                        break;

                    case ExportFormat.Txt:
                        table.ToTxt(fileName);
                        break;

                    default:
                        if (!silent)
                        {
                            UiMessages.Error(@"Unrecognised export format");
                            success = false;
                        }

                        break;
                }

                if (!silent && success)
                    UiMessages.Info($"Successfully exported data to: {fileName}");
            }
        }

        public static void ExportThis(this DataTable table, ExportFormat format, bool silent = false)
        {
            var sfd = new SaveFileDialog
            {
                Title = @"Export Data"
            };

            switch (format)
            {
                case ExportFormat.Csv:
                    sfd.Filter = @"CSV File|*.csv";
                    break;

                case ExportFormat.Json:
                    sfd.Filter = @"JSON File|*.json";
                    break;

                case ExportFormat.Xml:
                    sfd.Filter = @"XML File|*.xml";
                    break;

                case ExportFormat.Cfg:
                    sfd.Filter = @"CFG File|*.cfg";
                    break;

                case ExportFormat.Txt:
                    sfd.Filter = @"TXT File|*.txt";
                    break;

                default:
                    sfd.Filter = @"TXT File|*.txt";
                    break;
            }

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportThis(table, format, sfd.FileName, silent);
            }
        }
    }
}