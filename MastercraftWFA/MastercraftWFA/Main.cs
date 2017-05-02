﻿using System;
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
            List<int> toolOptions = new List<int>() { 0, 1 };
            DataGridViewComboBoxColumn toolComboBoxColumn = (DataGridViewComboBoxColumn)dataGridViewProfessions.Columns["tool"];
            toolComboBoxColumn.DataSource = toolOptions;
            dataGridViewProfessions.DataSource = Database.Query("SELECT * FROM professions");
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
                if (row.Cells["name"].Value == null || row.Cells["name"].Value == DBNull.Value || String.IsNullOrWhiteSpace(row.Cells["name"].Value.ToString()))
                    continue;
                string insertRow = "('" + row.Cells["name"].Value + "', " + row.Cells["tool"].Value + ")";
                Database.AddRow("professions", insertRow);
            }
            editButton_Professions.Show();
            insertButton_Professions.Hide();
        }
        #endregion


        #region Recipes Methods
        void FillDataRecipes(string profession) {
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
            DataTable tier1Table = Database.Query(Database.GetResultsQuery(profession, 1));
            DataTable tier2Table = Database.Query(Database.GetResultsQuery(profession, 2));
            DataTable tier3Table = Database.Query(Database.GetResultsQuery(profession, 3));
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
                string insertRow = "('" + cell.Value + "', '" + activeProfession + "')";
                Database.AddRow("recipes", insertRow);
            }
            editButton_Recipes.Show();
            insertButton_Recipes.Hide();
        }
        #endregion


        #region Resources Methods
        void FillDataResources() {
            dataGridViewResources.DataSource = Database.Query(
                "SELECT name, price, date(updated) AS updated " +
                "FROM resources"
            );
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
            dataGridViewResourcesConsumed.DataSource = Database.Query(
                "SELECT tier, resource, amount " +
                "FROM results " +
                "INNER JOIN resources " +
                "ON results.resource = resources.name " +
                "WHERE recipe = '" + recipe + "'");
        }

        #endregion

        
    }
}