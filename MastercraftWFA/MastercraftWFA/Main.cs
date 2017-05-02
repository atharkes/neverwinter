using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MastercraftWFA {
    public partial class Main : Form {
        public Main() {
            InitializeComponent();
            insertButton.Hide();
            FillData();
        }

        void FillData() {
            List<int> toolOptions = new List<int>() { 0, 1 };
            DataGridViewComboBoxColumn toolComboBoxColumn = (DataGridViewComboBoxColumn)professionsGridView.Columns["tool"];
            toolComboBoxColumn.DataSource = toolOptions;
            professionsGridView.DataSource = Database.Query("SELECT * FROM professions");
        }

        private void ProfessionsGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0 && e.RowIndex < professionsGridView.RowCount - 1) {
                // Open Profession Window
                DataGridViewCell field = professionsGridView[e.ColumnIndex, e.RowIndex];
                string query = field.Value.ToString();
                Profession profession = new Profession(query) {
                    Location = new System.Drawing.Point(this.Size.Width + this.Location.X, this.Location.Y),
                    StartPosition = FormStartPosition.Manual,
                    Text = query
                };
                profession.Show();
            }
        }

        private void InsertButton_Click(object sender, System.EventArgs e) {
            professionsGridView.Columns["name"].ReadOnly = true;
            professionsGridView.Columns["tool"].ReadOnly = true;
            foreach (DataGridViewRow row in professionsGridView.Rows) {
                if (row.Cells["name"].Value == null || row.Cells["name"].Value == DBNull.Value || String.IsNullOrWhiteSpace(row.Cells["name"].Value.ToString()))
                    continue;
                string insertRow = "('" + row.Cells["name"].Value + "', " + row.Cells["tool"].Value + ")";
                Database.AddRow("professions", insertRow);
            }
            editButton.Show();
            insertButton.Hide();
        }

        private void EditButton_Click(object sender, EventArgs e) {
            professionsGridView.Columns["name"].ReadOnly = false;
            professionsGridView.Columns["tool"].ReadOnly = false;
            insertButton.Show();
            editButton.Hide();
        }
    }
}