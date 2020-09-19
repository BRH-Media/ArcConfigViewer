using System;
using System.Data;
using System.IO;
using System.Linq;

namespace ArcConfigViewer.Extensions
{
    public static class CfgUtility
    {
        public static void ToCfg(this DataTable table, string filePath)
        {
            try
            {
                const char delimiter = '=';
                var fileContent = table.Rows.Cast<DataRow>()
                    .Where(r => r.ItemArray.Length == 2)
                    .Aggregate(@"", (current, r)
                        => current + $"{r.ItemArray[0]}{delimiter}{r.ItemArray[1]}\n");

                //finalise file
                File.WriteAllText(filePath, fileContent);
            }
            catch (Exception)
            {
                //ignore
            }
        }
    }
}