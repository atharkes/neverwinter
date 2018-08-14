using DatabaseInterface.Data;

namespace Mastercrafter.DataExtensions {
    /// <summary> Extension methods for the Recipe data class </summary>
    public static class RecipeExtension {
        /// <summary> Computes the cost of starting a recipe </summary>
        /// <param name="recipe">The recipe to start</param>
        /// <returns>The cost of starting the recipe in astral diamonds</returns>
        public static int StartCost(this Recipe recipe) {
            int cost = 0;
            foreach (Resource resource in recipe.ConsumedResources()) {
                cost += resource.Cost() * recipe.ConsumedAmount(resource);
            }
            return cost;
        }

        /// <summary> The reward of the result of the recipe at a specific tier </summary>
        /// <param name="recipe">The recipe to get the reward for</param>
        /// <param name="tier">The tier of the result</param>
        /// <returns>The reward of the recipe at the specified tier in astral diamonds</returns>
        public static int ResultReward(this Recipe recipe, int tier) {
            int reward = 0;
            foreach (Resource resource in recipe.ResultResources(tier)) {
                reward += resource.Cost() * recipe.ResultAmount(tier, resource); 
            }
            return reward;
        }

        /// <summary> The profit of doing this recipe at a specific tier </summary>
        /// <param name="recipe">The recipe to get the profit for</param>
        /// <param name="tier">The tier of the result</param>
        /// <returns>The profit of the recipe at the spcified tier in astral diamonds</returns>
        public static int Profit(this Recipe recipe, int tier) {
            return recipe.ResultReward(tier) - recipe.StartCost();
        }
    }
}
