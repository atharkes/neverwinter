using System;
using System.Data;
using System.Windows.Forms;

namespace MastercraftWFA {
    public partial class Profession : Form {
        public Profession(string profession) {
            InitializeComponent();
            FillData(profession);
        }

        void FillData(string profession) {
            DataTable costTable = Database.Query(
                "SELECT recipe, SUM(price * amount) AS cost " +
                "FROM (" +
                    "SELECT recipe, resource, price, amount " +
                    "FROM recipes " +
                    "INNER JOIN consumedResources " +
                    "ON recipes.name = consumedResources.recipe " +
                    "INNER JOIN resources " +
                    "ON consumedResources.resource = resources.name " +
                    "WHERE profession = '" + profession + "'" +
                ") GROUP BY recipe"
            );
            DataTable tier1Table = Database.GetRecipeResults(profession, 1);
            DataTable tier2Table = Database.GetRecipeResults(profession, 2);
            DataTable tier3Table = Database.GetRecipeResults(profession, 3);
            costTable.Merge(tier1Table);
            costTable.Merge(tier2Table);
            costTable.Merge(tier3Table);
            costTable.Columns.Add("tier1profit", typeof(int), "tier1 - cost");
            costTable.Columns.Add("tier2profit", typeof(int), "tier2 - cost");
            costTable.Columns.Add("tier3profit", typeof(int), "tier3 - cost");
            costTable.Columns.Add("profit", typeof(int));
            // Compute profit value
            for (int i = 0; i < costTable.Rows.Count; i++) {
                bool tool = Database.HasTool(profession);
                Int64 cost = costTable.Rows[i].Field<Int64>("cost");
                Int64 tier1Reward = costTable.Rows[i].Field<Int64>("tier1");
                Int64 tier2Reward = costTable.Rows[i].Field<Int64>("tier2");
                Int64 tier3Reward = costTable.Rows[i].Field<Int64>("tier3");
                Int64 tier3ChanceReward = (int)(tool ? 0.75 * tier3Reward + 0.25 * tier2Reward : 0.35 * tier3Reward + 0.65 * tier2Reward);
                Int64 profit = Math.Max(tier1Reward, tier2Reward);
                profit = Math.Max(profit, tier3ChanceReward);
                profit -= cost;
                costTable.Rows[i].SetField("profit", profit); 
            }
            dataGridView1.DataSource = costTable;
        }

        

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex != 0 || e.RowIndex < 0 || e.RowIndex >= dataGridView1.RowCount - 1)
                return;
            // Open Recipe Window
            DataGridViewCell field = dataGridView1[e.ColumnIndex, e.RowIndex];
            string query = (string)field.Value;
            Recipe recipe = new Recipe(query) {
                Location = new System.Drawing.Point(this.Size.Width + this.Location.X, this.Location.Y),
                StartPosition = FormStartPosition.Manual,
                Text = query
            };
            recipe.Show();
        }
    }
}