using System.Collections.Generic;

namespace DatabaseInterface.Structure.Tables {
    /// <summary> A table managing the resource results of recipes </summary>
    class RecipeResultTable : Table {
        public Column RecipeID { get; }
        public Column Tier { get; }
        public Column ResourceID { get; }
        public Column Amount { get; }

        /// <summary> Create a recipe result table object </summary>
        public RecipeResultTable() : base("RecipeResults", " PRIMARY KEY (recipe_id, resource_id)") {
            RecipeID = new Column(Column.Columns.RecipeId, "NOT NULL REFERENCES Recipes (recipe_id) ON DELETE RESTRICT ON UPDATE CASCADE");
            Tier = new Column(Column.Columns.Tier, "NOT NULL");
            ResourceID = new Column(Column.Columns.ResourceId, "NOT NULL REFERENCES Resources (resource_id) ON DELETE RESTRICT ON UPDATE CASCADE");
            Amount = new Column(Column.Columns.Amount, "NOT NULL DEFAULT (1)");
        }

        /// <summary> Create the recipe result table in the database </summary>
        public override void Create() => Create(new List<Column>() { RecipeID, Tier, ResourceID, Amount });

        /// <summary> Insert a resource to the result tier of a recipe in the table </summary>
        /// <param name="recipeId">The recipe id to add the resource to</param>
        /// <param name="tier">The result tier to add the resource to</param>
        /// <param name="resourceId">The resource to add to the result tier</param>
        /// <param name="amount">The amount of the resource to add</param>
        public void InsertRecipeResult(int recipeId, int tier, int resourceId, int amount) {
            InsertDataRow(new List<(Column, object)>() { (RecipeID, recipeId), (Tier, tier), (ResourceID, resourceId), (Amount, amount) });
        }

        /// <summary> Remove a resource from the result tier of a recipe in the table </summary>
        /// <param name="recipeId">The recipe id to remove the resource from</param>
        /// <param name="tier">The result tier to remove the resource from</param>
        /// <param name="resourceId">The resource to remove from the result tier</param>
        public void RemoveRecipeResult(int recipeId, int tier, int resourceId) {
            RemoveDataRow(new List<(Column, object)>() { (RecipeID, recipeId), (Tier, tier), (ResourceID, resourceId) });
        }
    }
}
