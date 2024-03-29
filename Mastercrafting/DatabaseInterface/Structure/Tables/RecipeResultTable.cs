﻿using DatabaseInterface.Data;
using DatabaseInterface.Structure.Columns;
using DatabaseInterface.Structure.Constraints;
using System.Data;

namespace DatabaseInterface.Structure.Tables {
    /// <summary> A table managing the resource results of recipes </summary>
    class RecipeResultTable : Table {
        public override string Name => "RecipeResults";
        public override string Constraints => $"PRIMARY KEY ({RecipeId.Name}, {Tier.Name}, {ResourceId.Name})";
        public RecipeId RecipeId { get; }
        public Tier Tier { get; }
        public ResourceId ResourceId { get; }
        public Amount Amount { get; }

        /// <summary> Create a recipe result table object </summary>
        public RecipeResultTable() {
            RecipeId = new RecipeId(new NotNull(), new ForeignKey(TableManager.Recipe, TableManager.Recipe.RecipeId));
            Tier = new Tier(new NotNull());
            ResourceId = new ResourceId(new NotNull(), new ForeignKey(TableManager.Resource, TableManager.Resource.ResourceId));
            Amount = new Amount(new NotNull(), new Default<int>(1));
        }

        /// <summary> Create the recipe result table in the database </summary>
        public override void Create() => Create(RecipeId, Tier, ResourceId, Amount);

        /// <summary> Load all recipe results from the database </summary>
        public override void LoadData() {
            DataTable table = GetAllData();
            foreach (DataRow row in table.Rows) {
                int tier = Tier.Parse(row);
                long recipeId = RecipeId.Parse(row);
                long resourceId = ResourceId.Parse(row);
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
            InsertDataRow((RecipeId, recipeId), (Tier, tier), (ResourceId, resourceId), (Amount, amount));
        }

        /// <summary> Remove a resource from the result tier of a recipe in the table </summary>
        /// <param name="recipeId">The recipe id to remove the resource from</param>
        /// <param name="tier">The result tier to remove the resource from</param>
        /// <param name="resourceId">The resource to remove from the result tier</param>
        public void RemoveRecipeResult(long recipeId, int tier, long resourceId) {
            RemoveDataRow((RecipeId, recipeId), (Tier, tier), (ResourceId, resourceId));
        }
    }
}
