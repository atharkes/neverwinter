using DatabaseInterface.Data;
using System.Collections.Generic;
using System.Data;

namespace DatabaseInterface.Structure.TableStructure {
    /// <summary> A table managing the resource costs of recipes </summary>
    class RecipeCostTable : Table {
        public override string Name => "RecipeCosts";
        public override string Constraints => $"PRIMARY KEY ({RecipeID.Name}, {ResourceID.Name})";
        public Column RecipeID { get; }
        public Column ResourceID { get; }
        public Column Amount { get; }

        /// <summary> Create a recipe cost table object </summary>
        public RecipeCostTable() {
            RecipeID = new Column(Column.Columns.RecipeId, $"NOT NULL REFERENCES {TableManager.Recipe.Name} ({TableManager.Recipe.RecipeID.Name}) ON DELETE RESTRICT ON UPDATE CASCADE");
            ResourceID = new Column(Column.Columns.ResourceId, $"NOT NULL REFERENCES {TableManager.Resource.Name} ({TableManager.Resource.ResourceID.Name}) ON DELETE RESTRICT ON UPDATE CASCADE");
            Amount = new Column(Column.Columns.Amount, "NOT NULL DEFAULT (1)");
        }

        /// <summary> Create the recipe cost table in the database </summary>
        public override void Create() => Create(new List<Column>() { RecipeID, ResourceID, Amount });

        /// <summary> Load all recipe costs from the database </summary>
        public void LoadRecipeCosts() {
            DataTable table = GetAllData();
            foreach (DataRow row in table.Rows) {
                int recipeId = row.Field<int>(RecipeID.Name);
                Recipe recipe = TableManager.Recipe.GetRecipe(recipeId);
                int resourceId = row.Field<int>(ResourceID.Name);
                Resource resource = TableManager.Resource.GetResource(resourceId);
                int amount = row.Field<int>(Amount.Name);
                recipe.AddConsumed(resource, amount);
            }
        }

        /// <summary> Add a resource cost to a recipe in the table </summary>
        /// <param name="recipeId">The id of the recipe to add the resource to</param>
        /// <param name="resourceId">The id of the resource to add to the recipe</param>
        /// <param name="amount">The amount of the resource</param>
        public void InsertRecipeCost(int recipeId, int resourceId, int amount) {
            InsertDataRow(new List<(Column, object)>() { (RecipeID, recipeId), (ResourceID, resourceId), (Amount, amount) });
        }

        /// <summary> Remove a resource cost from a recipe in the table </summary>
        /// <param name="recipeId">The id of the recipe to remove the resource from</param>
        /// <param name="resourceId">The id of the resource to remove from the recipe</param>
        public void RemoveRecipeCost(int recipeId, int resourceId) {
            RemoveDataRow(new List<(Column, object)>() { (RecipeID, recipeId), (ResourceID, resourceId) });
        }
    }
}
