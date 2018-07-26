using DatabaseInterface.Data;
using DatabaseInterface.Structure.Columns;
using DatabaseInterface.Structure.Constraints;
using System;
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
            RecipeId = new RecipeId(new NotNull(), new Unique(), new PrimaryKey(true));
            RecipeName = new RecipeName(new NotNull(), new Unique());
            ProfessionId = new ProfessionId(new NotNull(), new ForeignKey(TableManager.Profession, TableManager.Profession.ProfessionId));
            Grade = new Grade(new NotNull());
        }

        /// <summary> Create the recipe table in the database </summary>
        public override void Create() => Create(RecipeName, ProfessionId, Grade, RecipeId);

        /// <summary> Load all profession from the database </summary>
        /// <returns>The professions loaded from the database</returns>
        public override void LoadData() {
            DataTable table = GetAllData();
            foreach (DataRow row in table.Rows) {
                LoadRecipe(row);
            }
        }

        /// <summary> Get a recipe on a certain id </summary>
        /// <param name="recipeId">The id of the recipe to get</param>
        /// <returns>The recipe corresponding to the id</returns>
        public Recipe GetRecipe(long recipeId) {
            DataTable table = GetDataRows((RecipeId, recipeId));
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

        /// <summary> Update the name of a recipe </summary>
        /// <param name="recipeId">The id of the recipe to update to name of</param>
        /// <param name="name">The new name of the recipe</param>
        public void UpdateRecipeName(long recipeId, string name) {
            UpdateDataRow((false, RecipeId, recipeId), (true, RecipeName, name));
        }

        /// <summary> Update the grade of a recipe </summary>
        /// <param name="recipeId">The id of the recipe to update the grade of</param>
        /// <param name="grade">The new grade of the recipe</param>
        public void UpdateRecipeGrade(long recipeId, int grade) {
            UpdateDataRow((false, RecipeId, recipeId), (true, Grade, grade));
        }

        /// <summary> Add a new recipe to the table </summary>
        /// <param name="name">The name of the recipe</param>
        /// <param name="professionID">The id of the profession the recipe belongs to</param>
        /// <param name="grade">The grade of the recipe</param>
        public void InsertRecipe(string name, long professionID, int grade) {
            InsertDataRow((RecipeName, name), (ProfessionId, professionID), (Grade, grade));
        }

        /// <summary> Remove a recipe from the table </summary>
        /// <param name="recipeId">The id of the recipe to remove</param>
        public void RemoveRecipe(long recipeId) {
            RemoveDataRow((RecipeId, recipeId));
        }

        /// <summary> Get the id of a recipe </summary>
        /// <param name="recipe">The name of the recipe to get the id for</param>
        /// <returns>The id of the recipe</returns>
        public long GetRecipeID(string recipe) {
            DataTable result = GetDataRows((RecipeName, recipe));
            if (result.Rows.Count == 0) {
                throw new ArgumentException("The recipe does not exist in the database");
            } else if (result.Rows.Count > 1) {
                throw new ArgumentException("There are multiple entries of the recipe in the database");
            }
            return RecipeId.Parse(result.Rows[0]);
        }
    }
}
