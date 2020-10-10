using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace ArcConfigViewer.Extensions
{
    public static class TxtUtility
    {
        public static void ToTxt(this DataTable table, string filePath)
        {
            try
            {
                //save all new export file lines to this list
                var linesToWrite = new List<string>();

                //loop through all rows
                foreach (DataRow r in table.Rows)
                {
                    //amount of columns in this row
                    var colCount = r.ItemArray.Length;

                    //validate if there is any data
                    if (colCount > 0)
                    {
                        //validate for data null
                        if (r[0] == DBNull.Value)
                            continue;

                        //different routines depending on data structure
                        if (colCount == 1)
                        {
                            if (!string.IsNullOrEmpty((string)r[0]))
                                linesToWrite.Add((string)r[0]);
                        }
                        else
                        {
                            //loop through each cell and delimit it with "&cd&"
                            var newLine = r.ItemArray.Where(s => !string.IsNullOrWhiteSpace((string)s))
                                .Aggregate(@"", (current, s) => string.IsNullOrEmpty(current)
                                    ? (string)s
                                    : $"{current}&cd&{s}");

                            //apply the new line
                            linesToWrite.Add(newLine);
                        }
                    }
                }

                //finally, write the new lines
                if (linesToWrite.Count > 0)
                    File.WriteAllLines(filePath, linesToWrite);
            }
            catch (Exception)
            {
                //ignore
            }
        }
    }
}