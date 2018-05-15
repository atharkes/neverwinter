using DatabaseInterface.Data;
using System.Collections.Generic;
using System.Data;

namespace DatabaseInterface.Structure.Tables {
    /// <summary> A table managing the resource costs of recipes </summary>
    class RecipeCostTable : Table {
        public override string Name => "RecipeCosts";
        public override string Constraints => $"PRIMARY KEY ({RecipeID.Name}, {ResourceID.Name})";
        public Column<long> RecipeID { get; }
        public Column<long> ResourceID { get; }
        public Column<int> Amount { get; }

        /// <summary> Create a recipe cost table object </summary>
        public RecipeCostTable() {
            RecipeID = new Column<long>(Columns.RecipeId, $"NOT NULL REFERENCES {TableManager.Recipe.Name} ({TableManager.Recipe.RecipeID.Name}) ON DELETE RESTRICT ON UPDATE CASCADE");
            ResourceID = new Column<long>(Columns.ResourceId, $"NOT NULL REFERENCES {TableManager.Resource.Name} ({TableManager.Resource.ResourceID.Name}) ON DELETE RESTRICT ON UPDATE CASCADE");
            Amount = new Column<int>(Columns.Amount, "NOT NULL DEFAULT (1)");
        }

        /// <summary> Create the recipe cost table in the database </summary>
        public override void Create() => Create(new List<IColumn>() { RecipeID, ResourceID, Amount });

        /// <summary> Load all recipe costs from the database </summary>
        public void LoadRecipeCosts() {
            DataTable table = GetAllData();
            foreach (DataRow row in table.Rows) {
                long recipeId = RecipeID.Parse(row);
                long resourceId = ResourceID.Parse(row);
                int amount = Amount.Parse(row);
                Recipe recipe = TableManager.Recipe.GetRecipe(recipeId);
                Resource resource = TableManager.Resource.GetResource(resourceId);
                recipe.AddConsumed(resource, amount);
            }
        }

        /// <summary> Add a resource cost to a recipe in the table </summary>
        /// <param name="recipeId">The id of the recipe to add the resource to</param>
        /// <param name="resourceId">The id of the resource to add to the recipe</param>
        /// <param name="amount">The amount of the resource</param>
        public void InsertRecipeCost(long recipeId, long resourceId, int amount) {
            InsertDataRow(new List<(IColumn, object)>() { (RecipeID, recipeId), (ResourceID, resourceId), (Amount, amount) });
        }

        /// <summary> Remove a resource cost from a recipe in the table </summary>
        /// <param name="recipeId">The id of the recipe to remove the resource from</param>
        /// <param name="resourceId">The id of the resource to remove from the recipe</param>
        public void RemoveRecipeCost(long recipeId, long resourceId) {
            RemoveDataRow(new List<(IColumn, object)>() { (RecipeID, recipeId), (ResourceID, resourceId) });
        }
    }
}
