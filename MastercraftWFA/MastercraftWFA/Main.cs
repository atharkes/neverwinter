using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MastercraftWFA {
    public partial class Main : Form {

        string activeProfession;

        public Main() {
            InitializeComponent();
            FillDataProfessions();
            FillDataResources();
        }


        #region Professions Methods
        void FillDataProfessions() {
            List<int> gradeOptions = new List<int>() { 0, 1, 2, 3 };
            DataGridViewComboBoxColumn toolComboBoxColumn = (DataGridViewComboBoxColumn)dataGridViewProfessions.Columns["grade"];
            toolComboBoxColumn.DataSource = gradeOptions;
            dataGridViewProfessions.DataSource = Database.GetProfessions();
        }

        private void DataGridViewProfessions_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (dataGridViewProfessions.Columns["name"].Index == e.ColumnIndex && e.RowIndex >= 0 && e.RowIndex < dataGridViewProfessions.RowCount - 1) {
                // Filter on Profession
                DataGridViewCell field = dataGridViewProfessions[e.ColumnIndex, e.RowIndex];
                string query = field.Value.ToString();
                FillDataRecipes(query);
                activeProfession = query;
            }
        }

        private void EditButtonProfessions_Click(object sender, EventArgs e) {
            dataGridViewProfessions.Columns["name"].ReadOnly = false;
            dataGridViewProfessions.Columns["tool"].ReadOnly = false;
            insertButton_Professions.Show();
            editButton_Professions.Hide();
        }

        private void InsertButtonProfessions_Click(object sender, System.EventArgs e) {
            dataGridViewProfessions.Columns["name"].ReadOnly = true;
            dataGridViewProfessions.Columns["tool"].ReadOnly = true;
            foreach (DataGridViewRow row in dataGridViewProfessions.Rows) {
                DataGridViewCell cellName = row.Cells["name"];
                DataGridViewCell cellTool = row.Cells["tool"];
                if (cellName.Value == null || cellName.Value == DBNull.Value || String.IsNullOrWhiteSpace(cellName.Value.ToString()))
                    continue;
                Database.InsertProfession((string)cellName.Value, (int)cellTool.Value);
            }
            editButton_Professions.Show();
            insertButton_Professions.Hide();
        }
        #endregion


        #region Recipes Methods
        void FillDataRecipes(string profession) {
            DataTable costTable = Database.GetRecipesCost(profession);
            DataTable tier1Table = Database.GetRecipesReward(profession, 1);
            DataTable tier2Table = Database.GetRecipesReward(profession, 2);
            DataTable tier3Table = Database.GetRecipesReward(profession, 3);
            costTable.Merge(tier1Table);
            costTable.Merge(tier2Table);
            costTable.Merge(tier3Table);
            costTable.Columns.Add("tier1profit", typeof(int), "tier1reward - cost");
            costTable.Columns.Add("tier2profit", typeof(int), "tier2reward - cost");
            costTable.Columns.Add("tier3profit", typeof(int), "tier3reward - cost");
            costTable.Columns.Add("profit", typeof(int));
            // Compute profit value
            for (int i = 0; i < costTable.Rows.Count; i++) {
                bool tool = Database.HasTool(profession);
                Int64 cost = costTable.Rows[i].Field<Int64>("cost");
                Int64 tier1Reward = costTable.Rows[i].Field<Int64>("tier1reward");
                Int64 tier2Reward = costTable.Rows[i].Field<Int64>("tier2reward");
                Int64 tier3Reward = costTable.Rows[i].Field<Int64>("tier3reward");
                Int64 tier3ChanceReward = (int)(tool ? 0.75 * tier3Reward + 0.25 * tier2Reward : 0.35 * tier3Reward + 0.65 * tier2Reward);
                Int64 profit = Math.Max(tier1Reward, tier2Reward);
                profit = Math.Max(profit, tier3ChanceReward);
                profit -= cost;
                costTable.Rows[i].SetField("profit", profit);
            }
            dataGridViewRecipes.DataSource = costTable;
        }

        private void DataGridViewRecipes_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (dataGridViewRecipes.Columns["name_Recipes"].Index == e.ColumnIndex && e.RowIndex >= 0 && e.RowIndex < dataGridViewRecipes.RowCount - 1) {
                // Filter on Recipe
                DataGridViewCell field = dataGridViewRecipes[e.ColumnIndex, e.RowIndex];
                string query = field.Value.ToString();
                FillDataResourcesConsumed(query);
                FillDataResourcesResults(query);
            }
        }

        private void EditButton_Recipes_Click(object sender, EventArgs e) {
            dataGridViewRecipes.Columns["name_Recipes"].ReadOnly = false;
            insertButton_Recipes.Show();
            editButton_Recipes.Hide();
        }

        private void InsertButton_Recipes_Click(object sender, EventArgs e) {
            dataGridViewRecipes.Columns["name_Recipes"].ReadOnly = true;
            foreach (DataGridViewRow row in dataGridViewRecipes.Rows) {
                DataGridViewCell cell = row.Cells["name_Recipes"];
                if (cell.Value == null || cell.Value == DBNull.Value || String.IsNullOrWhiteSpace(cell.Value.ToString()))
                    continue;
                Database.InsertRecipe((string)cell.Value, activeProfession);
            }
            editButton_Recipes.Show();
            insertButton_Recipes.Hide();
        }
        #endregion


        #region Resources Methods
        void FillDataResources() {
            dataGridViewResources.DataSource = Database.GetAllResources();
        }

        private void EditButton_Resources_Click(object sender, EventArgs e) {
            dataGridViewResources.Columns["name_Resources"].ReadOnly = false;
            dataGridViewResources.Columns["price_Resources"].ReadOnly = false;
            insertButton_Resources.Show();
            editButton_Resources.Hide();
        }

        private void InsertButton_Resources_Click(object sender, EventArgs e) {
            dataGridViewResources.Columns["name_Resources"].ReadOnly = true;
            dataGridViewResources.Columns["price_Resources"].ReadOnly = true;
            foreach (DataGridViewRow row in dataGridViewResources.Rows) {
                DataGridViewCell cellResource = row.Cells["name_Resources"];
                DataGridViewCell cellPrice = row.Cells["price_Resources"];
                if (cellResource.Value == null || cellResource.Value == DBNull.Value || String.IsNullOrWhiteSpace(cellResource.Value.ToString()))
                    continue;
                Database.InsertResource((string)cellResource.Value, (int)cellPrice.Value);
            }
            editButton_Resources.Show();
            insertButton_Resources.Hide();
        }
        #endregion


        #region Resources Consumed Methods
        void FillDataResourcesConsumed(string recipe) {
            // Set Comboboxes
            DataTable results = Database.Query("SELECT name FROM resources");
            List<string> options = new List<string>();
            foreach (DataRow row in results.Rows) {
                options.Add(row.Field<string>("name"));
            }
            DataGridViewComboBoxColumn toolComboBoxColumn = (DataGridViewComboBoxColumn)dataGridViewResourcesConsumed.Columns["resource_Consumed"];
            toolComboBoxColumn.DataSource = options;
            // Query Data
            dataGridViewResourcesConsumed.DataSource = Database.Query(
                "SELECT resource, amount " +
                "FROM consumedResources " +
                "INNER JOIN resources " +
                "ON consumedResources.resource = resources.name " +
                "WHERE recipe = '" + recipe + "'");
        }
        #endregion


        #region Resources Results Methods
        void FillDataResourcesResults(string recipe) {
            // Set Comboboxes
            DataTable results = Database.Query("SELECT name FROM resources");
            List<string> options = new List<string>();
            foreach (DataRow row in results.Rows) {
                options.Add(row.Field<string>("name"));
            }
            DataGridViewComboBoxColumn toolComboBoxColumn = (DataGridViewComboBoxColumn)dataGridViewResourcesResults.Columns["resource_Results"];
            toolComboBoxColumn.DataSource = options;

            List<int> tierOptions = new List<int>() { 1, 2, 3 };
            toolComboBoxColumn = (DataGridViewComboBoxColumn)dataGridViewResourcesResults.Columns["tier_Results"];
            toolComboBoxColumn.DataSource = tierOptions;
            // Query Data
            dataGridViewResourcesResults.DataSource = Database.Query(
                "SELECT tier, resource, amount " +
                "FROM results " +
                "INNER JOIN resources " +
                "ON results.resource = resources.name " +
                "WHERE recipe = '" + recipe + "'");
        }


        #endregion

    }
}