using DatabaseInterface.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace DatabaseInterface.Structure.TableStructure {
    /// <summary> A table managing recipes </summary>
    class RecipeTable : Table {
        public override string Name => "Recipes";
        public override string Constraints => "";
        public Column RecipeID { get; }
        public Column RecipeName { get; }
        public Column ProfessionID { get; }
        public Column Grade { get; }

        /// <summary> Create a new recipe table object </summary>
        public RecipeTable() {
            RecipeID = new Column(Column.Columns.RecipeId, "NOT NULL UNIQUE PRIMARY KEY AUTOINCREMENT");
            RecipeName = new Column(Column.Columns.RecipeName, "NOT NULL UNIQUE");
            ProfessionID = new Column(Column.Columns.ProfessionId, $"NOT NULL REFERENCES {TableManager.Profession.Name} ({TableManager.Profession.ProfessionID.Name}) ON DELETE RESTRICT ON UPDATE CASCADE");
            Grade = new Column(Column.Columns.Grade, "NOT NULL");
        }

        /// <summary> Create the recipe table in the database </summary>
        public override void Create() => Create(new List<Column>() { RecipeName, ProfessionID, Grade, RecipeID });

        /// <summary> Load all profession from the database </summary>
        /// <returns>The professions loaded from the database</returns>
        public List<Recipe> LoadRecipes() {
            List<Recipe> recipes = new List<Recipe>();
            DataTable table = GetAllData();
            foreach (DataRow row in table.Rows) {
                recipes.Add(LoadRecipe(row));
            }
            return recipes;
        }

        /// <summary> Load a recipe from a datarow from the table </summary>
        /// <param name="row">The datarow. Must be from this table</param>
        /// <returns>The recipe corresponding to the datarow</returns>
        Recipe LoadRecipe(DataRow row) {
            string name = row.Field<string>(RecipeName.Name);
            int professionId = row.Field<int>(ProfessionID.Name);
            Profession profession = TableManager.Profession.GetProfession(professionId);
            int grade = row.Field<int>(Grade.Name);
            return Recipe.Factory.CreateRecipe(name, profession, grade);
        }

        /// <summary> Add a new recipe to the table </summary>
        /// <param name="name">The name of the recipe</param>
        /// <param name="professionID">The id of the profession the recipe belongs to</param>
        /// <param name="grade">The grade of the recipe</param>
        public void InsertRecipe(string name, int professionID, int grade) {
            InsertDataRow(new List<(Column, object)>() { (RecipeName, name), (ProfessionID, professionID), (Grade, grade) });
        }

        /// <summary> Remove a recipe from the table </summary>
        /// <param name="recipeId">The id of the recipe to remove</param>
        public void RemoveRecipe(int recipeId) => RemoveDataRow(new List<(Column, object)>() { (RecipeID, recipeId) });

        /// <summary> Get the id of a recipe </summary>
        /// <param name="recipe">The name of the recipe to get the id for</param>
        /// <returns>The id of the recipe</returns>
        public int GetRecipeID(string recipe) {
            DataTable result = GetDataRows(new List<(Column, object)>() { (RecipeName, recipe) });
            if (result.Rows.Count == 0) {
                throw new ArgumentException("The recipe does not exist in the database");
            } else if (result.Rows.Count > 1) {
                throw new ArgumentException("There are multiple entries of the recipe in the database");
            }
            return result.Rows[0].Field<int>(RecipeID.Name);
        }
    }
}
