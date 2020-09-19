using System;
using System.Data;
using System.Windows.Forms;

namespace ArcConfigViewer.Extensions
{
    public static class XmlUtility
    {
        public static void ToXml(this DataTable table, string filePath)
        {
            try
            {
                var ds = new DataSet("LH1000_Config");
                var data = table.Copy();

                ds.Tables.Add(data);
                //hierarchical XML format
                ds.WriteXml(filePath, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}