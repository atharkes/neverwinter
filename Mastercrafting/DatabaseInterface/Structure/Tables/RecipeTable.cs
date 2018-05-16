using DatabaseInterface.Data;
using DatabaseInterface.Structure.Columns;
using System;
using System.Collections.Generic;
using System.Data;

namespace DatabaseInterface.Structure.Tables {
    /// <summary> A table managing recipes </summary>
    class RecipeTable : Table {
        public override string Name => "Recipes";
        public override string Constraints => "";
        public RecipeId RecipeId { get; }
        public RecipeName RecipeName { get; }
        public ProfessionId ProfessionId { get; }
        public Grade Grade { get; }

        /// <summary> Create a new recipe table object </summary>
        public RecipeTable() {
            RecipeId = new RecipeId("NOT NULL UNIQUE PRIMARY KEY AUTOINCREMENT");
            RecipeName = new RecipeName("NOT NULL UNIQUE");
            ProfessionId = new ProfessionId($"NOT NULL REFERENCES {TableManager.Profession.Name} ({TableManager.Profession.ProfessionId.Name}) ON DELETE RESTRICT ON UPDATE CASCADE");
            Grade = new Grade("NOT NULL");
        }

        /// <summary> Create the recipe table in the database </summary>
        public override void Create() => Create(new List<IColumn>() { RecipeName, ProfessionId, Grade, RecipeId });

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

        /// <summary> Get a recipe on a certain id </summary>
        /// <param name="recipeId">The id of the recipe to get</param>
        /// <returns>The recipe corresponding to the id</returns>
        public Recipe GetRecipe(long recipeId) {
            DataTable table = GetDataRows(new List<(IColumn, object)>() { (RecipeId, recipeId) });
            if (table.Rows.Count == 0) {
                throw new ArgumentException("The requested recipe does not exist in the database");
            }
            return LoadRecipe(table.Rows[0]);
        }

        /// <summary> Load a recipe from a datarow from the table </summary>
        /// <param name="row">The datarow. Must be from this table</param>
        /// <returns>The recipe corresponding to the datarow</returns>
        Recipe LoadRecipe(DataRow row) {
            string name = RecipeName.Parse(row);
            long professionId = ProfessionId.Parse(row);
            int grade = Grade.Parse(row);
            Profession profession = TableManager.Profession.GetProfession(professionId);
            return Recipe.Factory.CreateRecipe(name, profession, grade);
        }

        /// <summary> Add a new recipe to the table </summary>
        /// <param name="name">The name of the recipe</param>
        /// <param name="professionID">The id of the profession the recipe belongs to</param>
        /// <param name="grade">The grade of the recipe</param>
        public void InsertRecipe(string name, long professionID, int grade) {
            InsertDataRow(new List<(IColumn, object)>() { (RecipeName, name), (ProfessionId, professionID), (Grade, grade) });
        }

        /// <summary> Remove a recipe from the table </summary>
        /// <param name="recipeId">The id of the recipe to remove</param>
        public void RemoveRecipe(long recipeId) {
            RemoveDataRow(new List<(IColumn, object)>() { (RecipeId, recipeId) });
        }

        /// <summary> Get the id of a recipe </summary>
        /// <param name="recipe">The name of the recipe to get the id for</param>
        /// <returns>The id of the recipe</returns>
        public long GetRecipeID(string recipe) {
            DataTable result = GetDataRows(new List<(IColumn, object)>() { (RecipeName, recipe) });
            if (result.Rows.Count == 0) {
                throw new ArgumentException("The recipe does not exist in the database");
            } else if (result.Rows.Count > 1) {
                throw new ArgumentException("There are multiple entries of the recipe in the database");
            }
            return RecipeId.Parse(result.Rows[0]);
        }
    }
}
