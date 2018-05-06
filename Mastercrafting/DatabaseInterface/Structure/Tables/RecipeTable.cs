using System;
using System.Collections.Generic;
using System.Data;

namespace DatabaseInterface.Structure.Tables {
    /// <summary> A table managing recipes </summary>
    class RecipeTable : Table {
        public Column RecipeID { get; }
        public Column Recipe { get; }
        public Column ProfessionID { get; }
        public Column Grade { get; }

        /// <summary> Create a new recipe table object </summary>
        public RecipeTable() : base("Recipes") {
            RecipeID = new Column(Column.Columns.RecipeId, "NOT NULL UNIQUE PRIMARY KEY AUTOINCREMENT");
            Recipe = new Column(Column.Columns.Recipe, "NOT NULL UNIQUE");
            ProfessionID = new Column(Column.Columns.ProfessionId, "NOT NULL REFERENCES Professions (profession_id) ON DELETE RESTRICT ON UPDATE CASCADE");
            Grade = new Column(Column.Columns.Grade, "NOT NULL");
        }

        /// <summary> Create the recipe table in the database </summary>
        public override void Create() => Create(new List<Column>() { Recipe, ProfessionID, Grade, RecipeID });

        /// <summary> Add a new recipe to the table </summary>
        /// <param name="name">The name of the recipe</param>
        /// <param name="professionID">The id of the profession the recipe belongs to</param>
        /// <param name="grade">The grade of the recipe</param>
        public void InsertRecipe(string name, int professionID, int grade) {
            InsertDataRow(new List<(Column, object)>() { (Recipe, name), (ProfessionID, professionID), (Grade, grade) });
        }

        /// <summary> Remove a recipe from the table </summary>
        /// <param name="recipeId">The id of the recipe to remove</param>
        public void RemoveRecipe(int recipeId) => RemoveDataRow(new List<(Column, object)>() { (RecipeID, recipeId) });

        /// <summary> Get the id of a recipe </summary>
        /// <param name="recipe">The name of the recipe to get the id for</param>
        /// <returns>The id of the recipe</returns>
        public int GetRecipeID(string recipe) {
            DataTable result = GetDataRows(new List<(Column, object)>() { (Recipe, recipe) });
            if (result.Rows.Count == 1) {
                return result.Rows[0].Field<int>(RecipeID.Name);
            } else if (result.Rows.Count == 0) {
                throw new ArgumentException("The recipe does not exist in the database");
            } else {
                throw new ArgumentException("There are multiple entries of the recipe in the database");
            }
        }
    }
}
