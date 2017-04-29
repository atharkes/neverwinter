using System;
using System.Windows.Forms;

namespace MastercraftWFA {
    public partial class Recipe : Form {
        public Recipe(string recipe) {
            InitializeComponent();
            FillData(recipe);
        }

        void FillData(string recipe) {
            dataGridView1.DataSource = Database.Query(
                "SELECT resource, amount, price, date(updated) AS updated, (amount * price) AS totalCost " +
                "FROM consumedResources " +
                "INNER JOIN resources " +
                "ON consumedResources.resource = resources.name " +
                "WHERE recipe = '" + recipe + "'");
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex != 0 || e.RowIndex < 0 || e.RowIndex >= dataGridView1.RowCount - 1)
                return;
            // Open Resource Window
            DataGridViewCell field = dataGridView1[e.ColumnIndex, e.RowIndex];
            string query = Convert.ToString(field.Value);
        }
    }
}