using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MastercraftWFA {
    public partial class Main : Form {
        DatabaseInterface database;
        string activeProfession;

        public Main() {
            InitializeComponent();
            database = new DatabaseInterface();
            FillDataProfessions();
            dataGridViewProfessions.AutoGenerateColumns = false;
            dataGridViewRecipes.AutoGenerateColumns = false;
            dataGridViewResources.AutoGenerateColumns = false;
            dataGridViewResourcesConsumed.AutoGenerateColumns = false;
            dataGridViewResourcesResults.AutoGenerateColumns = false;
        }


        #region Professions Methods
        void FillDataProfessions() {
            // Set Comboboxes
            DataGridViewComboBoxColumn toolComboBoxColumn = dataGridViewProfessions.Columns["grade"] as DataGridViewComboBoxColumn;
            toolComboBoxColumn.DataSource = database.GetGrades();
            // Query Data
            dataGridViewProfessions.DataSource = database.GetProfessionsTable();
        }

        private void DataGridViewProfessions_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (dataGridViewProfessions.Columns[Database.ColumnName[Database.Columns.profession]].Index == e.ColumnIndex && e.RowIndex >= 0 && e.RowIndex < dataGridViewProfessions.RowCount - 1) {
                // Filter on Profession
                DataGridViewCell field = dataGridViewProfessions[e.ColumnIndex, e.RowIndex];
                string query = field.Value.ToString();
                FillDataRecipes(query);
                activeProfession = query;
            }
        }

        private void DataGridViewProfessions_SelectionChanged(object sender, EventArgs e) {
            List<string> query = new List<string>();

            DataGridViewSelectedCellCollection selectedCells = dataGridViewProfessions.SelectedCells;
            foreach (DataGridViewCell cell in selectedCells) {
                if (dataGridViewProfessions.Columns[Database.ColumnName[Database.Columns.profession]].Index == cell.ColumnIndex && cell.RowIndex >= 0 && cell.RowIndex < dataGridViewProfessions.RowCount - 1)
                    query.Add(cell.Value.ToString());
            }

            if (query.Count > 0)
                FillDataRecipes(query);
        }

        private void EditButtonProfessions_Click(object sender, EventArgs e) {
            dataGridViewProfessions.Columns[Database.ColumnName[Database.Columns.profession]].ReadOnly = false;
            dataGridViewProfessions.Columns[Database.ColumnName[Database.Columns.grade]].ReadOnly = false;
            insertButton_Professions.Show();
            editButton_Professions.Hide();
        }

        private void InsertButtonProfessions_Click(object sender, EventArgs e) {
            dataGridViewProfessions.Columns[Database.ColumnName[Database.Columns.profession]].ReadOnly = true;
            dataGridViewProfessions.Columns[Database.ColumnName[Database.Columns.grade]].ReadOnly = true;
            foreach (DataGridViewRow row in dataGridViewProfessions.Rows) {
                DataGridViewCell cellName = row.Cells[Database.ColumnName[Database.Columns.profession]];
                DataGridViewCell cellTool = row.Cells[Database.ColumnName[Database.Columns.grade]];
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
            dataGridViewRecipes.DataSource = database.GetRecipesTable(profession);
        }

        void FillDataRecipes(List<string> professions) {
            dataGridViewRecipes.DataSource = database.GetRecipesTable(professions);
        }

        private void DataGridViewRecipes_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (dataGridViewRecipes.Columns[Database.ColumnName[Database.Columns.recipe]].Index == e.ColumnIndex && e.RowIndex >= 0 && e.RowIndex < dataGridViewRecipes.RowCount - 1) {
                // Filter on Recipe
                DataGridViewCell field = dataGridViewRecipes[e.ColumnIndex, e.RowIndex];
                string query = field.Value.ToString();
                FillDataResourcesConsumed(query);
                FillDataResourcesResults(query);
                FillDataResources(query);
            }
        }

        private void DataGridViewRecipes_SelectionChanged(object sender, EventArgs e) {
            List<string> recipes = new List<string>();
            DataGridViewSelectedCellCollection selectedCells = dataGridViewRecipes.SelectedCells;
            foreach (DataGridViewCell cell in selectedCells) {
                if (dataGridViewRecipes.Columns[Database.ColumnName[Database.Columns.recipe]].Index == cell.ColumnIndex && cell.RowIndex >= 0 && cell.RowIndex < dataGridViewRecipes.RowCount - 1)
                    recipes.Add(cell.Value.ToString());
            }

            if (recipes.Count > 0) {
                FillDataResourcesConsumed(recipes);
                FillDataResourcesResults(recipes);
                FillDataResources(recipes);
            }
            
        }
        #endregion


        #region Resources Methods
        void FillDataResources(string recipe) {
            dataGridViewResources.DataSource = database.GetResourcesTable(recipe);
        }

        void FillDataResources(List<string> recipes) {
            dataGridViewResources.DataSource = database.GetResourcesTable(recipes);
        }
        #endregion


        #region Resources Consumed Methods
        void FillDataResourcesConsumed(string recipe) {
            // Set Comboboxes
            DataGridViewComboBoxColumn resourcesComboBox = dataGridViewResourcesConsumed.Columns["resource_Consumed"] as DataGridViewComboBoxColumn;
            resourcesComboBox.DataSource = database.GetResourceList();
            // Query Data
            dataGridViewResourcesConsumed.DataSource = database.GetConsumedResourcesTable(recipe);
        }

        void FillDataResourcesConsumed(List<string> recipes) {
            if (recipes.Count == 1) {
                FillDataResourcesConsumed(recipes[0]);
            } else {
                dataGridViewResourcesConsumed.DataSource = "";
            }
        }
        #endregion


        #region Resources Results Methods
        void FillDataResourcesResults(string recipe) {
            // Set Comboboxes
            DataGridViewComboBoxColumn resourceComboBox = dataGridViewResourcesResults.Columns["resource_Results"] as DataGridViewComboBoxColumn;
            resourceComboBox.DataSource = database.GetResourceList();
            DataGridViewComboBoxColumn tierComboBox = (DataGridViewComboBoxColumn)dataGridViewResourcesResults.Columns["tier_Results"];
            tierComboBox.DataSource = database.GetTiers();
            // Query Data
            dataGridViewResourcesResults.DataSource = database.GetResultsTable(recipe);
        }

        void FillDataResourcesResults(List<string> recipes) {
            if (recipes.Count == 1) {
                FillDataResourcesResults(recipes[0]);
            } else {
                dataGridViewResourcesResults.DataSource = "";
            }
        }
        #endregion

    }
}