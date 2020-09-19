using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace ArcConfigViewer.Extensions
{
    public static class JsonUtility
    {
        public static void ToJson(this DataTable dt, string filePath)
        {
            try
            {
                var lst = new List<Dictionary<string, object>>();
                foreach (DataRow row in dt.Rows)
                {
                    var item = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                        item.Add(col.ColumnName, Convert.IsDBNull(row[col]) ? null : row[col]);
                    lst.Add(item);
                }

                File.WriteAllText(filePath, JsonConvert.SerializeObject(lst, Formatting.Indented));
            }
            catch (Exception)
            {
                //ignore it
            }
        }
    }
}