using DatabaseInterface.Data;
using DatabaseInterface.Structure.Columns;
using DatabaseInterface.Structure.Constraints;
using System.Collections.Generic;
using System.Data;

namespace DatabaseInterface.Structure.Tables {
    /// <summary> A table managing the resource costs of recipes </summary>
    class RecipeConsumedTable : Table {
        public override string Name => "RecipeCosts";
        public override string Constraints => $"PRIMARY KEY ({RecipeId.Name}, {ResourceId.Name})";
        public RecipeId RecipeId { get; }
        public ResourceId ResourceId { get; }
        public Amount Amount { get; }

        /// <summary> Create a recipe cost table object </summary>
        public RecipeConsumedTable() {
            RecipeId = new RecipeId(new NotNull(), new ForeignKey(TableManager.Recipe, TableManager.Recipe.RecipeId));
            ResourceId = new ResourceId(new NotNull(), new ForeignKey(TableManager.Resource, TableManager.Resource.ResourceId));
            Amount = new Amount(new NotNull(), new Default<int>(1));
        }

        /// <summary> Create the recipe cost table in the database </summary>
        public override void Create() => Create(RecipeId, ResourceId, Amount);

        /// <summary> Load all recipe costs from the database </summary>
        public override void LoadData() {
            DataTable table = GetAllData();
            foreach (DataRow row in table.Rows) {
                long recipeId = RecipeId.Parse(row);
                long resourceId = ResourceId.Parse(row);
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
            InsertDataRow((RecipeId, recipeId), (ResourceId, resourceId), (Amount, amount));
        }

        /// <summary> Remove a resource cost from a recipe in the table </summary>
        /// <param name="recipeId">The id of the recipe to remove the resource from</param>
        /// <param name="resourceId">The id of the resource to remove from the recipe</param>
        public void RemoveRecipeCost(long recipeId, long resourceId) {
            RemoveDataRow((RecipeId, recipeId), (ResourceId, resourceId));
        }
    }
}
