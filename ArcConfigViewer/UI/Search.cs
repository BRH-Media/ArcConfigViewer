using ArcConfigViewer.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault

namespace ArcConfigViewer.UI
{
    public partial class Search : Form
    {
        public SearchMode Mode { get; set; } = SearchMode.Text;
        public string SearchColumn { get; set; } = @"";
        public string SearchTerm { get; set; } = @"";
        public List<string> SearchColumnsList { get; set; } = new List<string>();

        public Search()
        {
            InitializeComponent();
        }

        public static SearchContext StartSearch(SearchMode mode, DataTable data = null)
        {
            var cxt = new SearchContext();

            var frm = new Search
            {
                Mode = mode
            };

            if (mode == SearchMode.Grid)
            {
                var columns =
                    (from DataColumn c in data?.Columns select c.ColumnName)
                    .ToList();
                frm.SearchColumnsList = columns;
            }

            if (frm.ShowDialog() == DialogResult.OK)
            {
                cxt.SearchColumn = frm.SearchColumn;
                cxt.SearchTerm = frm.SearchTerm;
                cxt.SearchSubmitted = true;
            }

            return cxt;
        }

        private void RefitUi(SearchMode mode)
        {
            const int genericOffset = 12;
            const int windowsHeightOffset = 39;
            const int windowsWidthOffset = 16;

            var width = Width;
            var height = Height;

            switch (mode)
            {
                case SearchMode.Grid:
                    width = btnSearchGrid.Location.X + btnSearchGrid.Width + genericOffset + windowsWidthOffset;
                    height = btnSearchGrid.Location.Y + btnSearchGrid.Height + genericOffset + windowsHeightOffset;
                    break;

                case SearchMode.Text:
                    width = btnSearchText.Location.X + btnSearchText.Width + genericOffset + windowsWidthOffset;
                    height = btnSearchText.Location.Y + btnSearchText.Height + genericOffset + windowsHeightOffset;
                    break;
            }

            Size = new Size(width, height);
        }

        private void SwitchUi(SearchMode mode)
        {
            switch (mode)
            {
                case SearchMode.Grid:
                    pnlTextSearch.Enabled = false;
                    pnlTextSearch.Visible = false;

                    pnlGridSearch.Enabled = true;
                    pnlGridSearch.Visible = true;

                    AcceptButton = btnSearchGrid;

                    break;

                case SearchMode.Text:
                    pnlTextSearch.Enabled = true;
                    pnlTextSearch.Visible = true;

                    pnlGridSearch.Enabled = false;
                    pnlGridSearch.Visible = false;

                    AcceptButton = btnSearchText;

                    break;
            }
        }

        private void PrepareUi()
        {
            SwitchUi(Mode);
            RefitUi(Mode);

            cbxColumn.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxColumn.Items.Clear();

            foreach (var s in SearchColumnsList)
            {
                cbxColumn.Items.Add(s);
            }

            if (cbxColumn.Items.Count > 0)
                cbxColumn.SelectedIndex = 0;
        }

        private void Search_Load(object sender, EventArgs e)
        {
            PrepareUi();
        }

        private void BtnCancelGrid_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnSearchGrid_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearchTerm.Text) && cbxColumn.SelectedIndex > -1)
            {
                SearchColumn = cbxColumn.SelectedItem.ToString();
                SearchTerm = txtSearchTerm.Text;

                DialogResult = DialogResult.OK;
                Close();
            }
            else
                UiMessages.Error(@"Please correctly fill all required fields", @"Validation Error");
        }

        private void BtnTextCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnTextSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTextSearchTerm.Text))
            {
                SearchTerm = txtTextSearchTerm.Text;

                DialogResult = DialogResult.OK;
                Close();
            }
            else
                UiMessages.Error(@"Please correctly fill all required fields", @"Validation Error");
        }
    }
}