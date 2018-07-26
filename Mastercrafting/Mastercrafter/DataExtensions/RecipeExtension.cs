using DatabaseInterface.Data;
using System;

namespace Mastercrafter.DataExtensions {
    /// <summary> Extension methods for the Recipe data class </summary>
    public static class RecipeExtension {
        /// <summary> Computes the cost of starting a recipe </summary>
        /// <param name="recipe">The recipe to start</param>
        /// <returns>The cost of starting the recipe</returns>
        public static int StartCost(this Recipe recipe) {
            int cost = 0;
            foreach (Resource resource in recipe.ConsumedResources()) {
                cost += Math.Min(resource.Price, resource.CraftCost());
            }
            return cost;
        }
    }
}
