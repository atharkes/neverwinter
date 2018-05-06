using System.Collections.Generic;

namespace DatabaseInterface.Structure.Tables {
    /// <summary> A table managing the resource costs of recipes </summary>
    class RecipeCostTable : Table {
        public Column RecipeID { get; }
        public Column ResourceID { get; }
        public Column Amount { get; }

        /// <summary> Create a recipe cost table object </summary>
        public RecipeCostTable() : base("RecipeCost", " PRIMARY KEY (recipe_id, resource_id)") {
            RecipeID = new Column(Column.Columns.RecipeId, "NOT NULL REFERENCES Recipes (recipe_id) ON DELETE RESTRICT ON UPDATE CASCADE");
            ResourceID = new Column(Column.Columns.ResourceId, "NOT NULL REFERENCES Resources (resource_id) ON DELETE RESTRICT ON UPDATE CASCADE");
            Amount = new Column(Column.Columns.Amount, "NOT NULL DEFAULT (1)");
        }

        /// <summary> Create the recipe cost table in the database </summary>
        public override void Create() => Create(new List<Column>() { RecipeID, ResourceID, Amount });

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
