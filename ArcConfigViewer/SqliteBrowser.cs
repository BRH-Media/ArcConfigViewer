using System;
using System.Collections;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using ArcWaitWindow;

// ReSharper disable InvertIf

namespace ArcConfigViewer
{
    public partial class SqliteBrowser : Form
    {
        public string DbFile { get; set; } = @"";
        public DataSet Database { get; set; }
        public SQLiteConnection GlobalConnection { get; set; } = null;

        public SqliteBrowser()
        {
            InitializeComponent();
        }

        public ArrayList GetTables(SQLiteConnection c)
        {
            var list = new ArrayList();

            // executes query that select names of all tables in master table of the database
            const string query = "SELECT name FROM sqlite_master " +
                                 "WHERE type = 'table'";
            try
            {
                var table = GetDataTable(query, c);

                // Return all table names in the ArrayList

                foreach (DataRow row in table.Rows)
                {
                    var name = row.ItemArray[0].ToString();
                    list.Add(name);
                }
            }
            catch (Exception e)
            {
                UiMessages.Error($"Table load error\n\n{e}");
            }
            return list;
        }

        public DataTable GetDataTable(string sql, SQLiteConnection c)
        {
            try
            {
                var dt = new DataTable();
                if (c.State == ConnectionState.Closed) c.Open();
                using (var cmd = new SQLiteCommand(sql, c))
                {
                    using (var rdr = cmd.ExecuteReader())
                    {
                        dt.Load(rdr);
                        return dt;
                    }
                }
            }
            catch (Exception e)
            {
                UiMessages.Error($"Table load error\n\n{e}");
                return null;
            }
        }

        private void LoadEntireDatabase(object sender, WaitWindowEventArgs e)
        {
            e.Result = LoadEntireDatabase(false);
        }

        private DataSet LoadEntireDatabase(bool waitWindow = true)
        {
            if (waitWindow)
            {
                return (DataSet)WaitWindow.Show(LoadEntireDatabase, @"Loading SQLite database...");
            }

            try
            {
                var conn = new SQLiteConnection($@"Data Source={DbFile}");
                conn.Open();

                GlobalConnection = conn;

                var d = new DataSet();
                foreach (var tableName in GetTables(GlobalConnection))
                {
                    d.Tables.Add(GetDataTable($"SELECT * FROM `{tableName}`", GlobalConnection));
                }

                GlobalConnection.Close();

                return d;
            }
            catch (Exception ex)
            {
                UiMessages.Error($"Database load error\n\n{ex}");
            }

            return null;
        }

        private void PopulateTables()
        {
            lstTables.Items.Clear();
            if (Database != null)
            {
                foreach (DataTable t in Database.Tables)
                {
                    lstTables.Items.Add(t.TableName);
                }

                if (lstTables.Items.Count > 0)
                    lstTables.SelectedIndex = 0;
            }
        }

        private void SqliteBrowser_Load(object sender, EventArgs e)
        {
            Database = LoadEntireDatabase();
            PopulateTables();
        }

        public static void ShowBrowser(string dbFilePath)
        {
            var db = new SqliteBrowser
            {
                DbFile = dbFilePath
            };
            db.ShowDialog();
        }

        private void LstTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTables.SelectedIndex > -1 && Database != null)
            {
                var dt = Database.Tables[lstTables.SelectedIndex];
                dgvMain.DataSource = dt;
            }
            else
                dgvMain.DataSource = null;
        }
    }
}