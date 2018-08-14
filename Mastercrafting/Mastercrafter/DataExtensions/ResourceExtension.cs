using DatabaseInterface.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastercrafter.DataExtensions {
    /// <summary> Extension methods for the Resource data class </summary>
    public static class ResourceExtension {
        /// <summary> Returns a dictionary with all crafting costs </summary>
        /// <param name="resource">The resource to get the crafting costs for</param>
        /// <returns>A dictionary with all possible recipes and their costs</returns>
        public static SortedList<Recipe, int> RecipeCosts(this Resource resource) {
            SortedList<Recipe, int> recipeCosts = new SortedList<Recipe, int>();
            foreach (Recipe recipe in resource.ResultOf()) {
                recipeCosts.Add(recipe, recipe.StartCost());
            }
            return recipeCosts;
        }

        /// <summary> Gets the cheapest crafting cost of a recipe </summary>
        /// <param name="resource">The resource to get the crafting cost for</param>
        /// <returns>The cost to craft the resource</returns>
        public static int CraftCost(this Resource resource) {
            return resource.RecipeCosts().First().Value;
        }

        /// <summary> Returns the minimum cost of the resource </summary>
        /// <param name="resource">The resource to get the cost for</param>
        /// <returns>The lowest cost to get the resource</returns>
        public static int Cost(this Resource resource) {
            return Math.Min(resource.Price, resource.CraftCost());
        }
    }
}
