using DatabaseInterface.Data;
using System.Collections.Generic;
using System.Data;

namespace DatabaseInterface.Structure.TableStructure {
    /// <summary> A table managing the resource results of recipes </summary>
    class RecipeResultTable : Table {
        public override string Name => "RecipeResults";
        public override string Constraints => $"PRIMARY KEY ({RecipeID.Name}, {Tier.Name}, {ResourceID.Name})";
        public Column<long> RecipeID { get; }
        public Column<int> Tier { get; }
        public Column<long> ResourceID { get; }
        public Column<int> Amount { get; }

        /// <summary> Create a recipe result table object </summary>
        public RecipeResultTable() {
            RecipeID = new Column<long>(Columns.RecipeId, $"NOT NULL REFERENCES {TableManager.Recipe.Name} ({TableManager.Recipe.RecipeID.Name}) ON DELETE RESTRICT ON UPDATE CASCADE");
            Tier = new Column<int>(Columns.Tier, "NOT NULL");
            ResourceID = new Column<long>(Columns.ResourceId, $"NOT NULL REFERENCES {TableManager.Resource.Name} ({TableManager.Resource.ResourceID.Name}) ON DELETE RESTRICT ON UPDATE CASCADE");
            Amount = new Column<int>(Columns.Amount, "NOT NULL DEFAULT (1)");
        }

        /// <summary> Create the recipe result table in the database </summary>
        public override void Create() => Create(new List<IColumn>() { RecipeID, Tier, ResourceID, Amount });

        /// <summary> Load all recipe results from the database </summary>
        public void LoadRecipeResults() {
            DataTable table = GetAllData();
            foreach (DataRow row in table.Rows) {
                int tier = Tier.Parse(row);
                long recipeId = RecipeID.Parse(row);
                long resourceId = ResourceID.Parse(row);
                int amount = Amount.Parse(row);
                Recipe recipe = TableManager.Recipe.GetRecipe(recipeId);
                Resource resource = TableManager.Resource.GetResource(resourceId);
                recipe.AddResultResource(tier, resource, amount);
            }
        }

        /// <summary> Insert a resource to the result tier of a recipe in the table </summary>
        /// <param name="recipeId">The recipe id to add the resource to</param>
        /// <param name="tier">The result tier to add the resource to</param>
        /// <param name="resourceId">The resource to add to the result tier</param>
        /// <param name="amount">The amount of the resource to add</param>
        public void InsertRecipeResult(long recipeId, int tier, long resourceId, int amount) {
            InsertDataRow(new List<(IColumn, object)>() { (RecipeID, recipeId), (Tier, tier), (ResourceID, resourceId), (Amount, amount) });
        }

        /// <summary> Remove a resource from the result tier of a recipe in the table </summary>
        /// <param name="recipeId">The recipe id to remove the resource from</param>
        /// <param name="tier">The result tier to remove the resource from</param>
        /// <param name="resourceId">The resource to remove from the result tier</param>
        public void RemoveRecipeResult(long recipeId, int tier, long resourceId) {
            RemoveDataRow(new List<(IColumn, object)>() { (RecipeID, recipeId), (Tier, tier), (ResourceID, resourceId) });
        }
    }
}
