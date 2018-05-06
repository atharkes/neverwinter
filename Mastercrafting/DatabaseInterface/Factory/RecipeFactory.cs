using DatabaseInterface.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseInterface.Factory {
    /// <summary> Creates recipes, making sure there are no multiple objects of the same recipe </summary>
    public static class RecipeFactory {
        /// <summary> The set of all recipe objects </summary>
        static HashSet<Recipe> recipes = new HashSet<Recipe>();

        /// <summary> Create a new recipe, or get a reference to the already existing object </summary>
        /// <param name="name">The name of the recipe</param>
        /// <param name="profession">The profession this recipe belongs to</param>
        /// <param name="grade">The grade of this recipe</param>
        /// <param name="guildMarks">The amount of guildmarks it costs to insta complete this recipe</param>
        /// <returns>The recipe object corresponding to the name</returns>
        public static Recipe CreateRecipe(string name, Profession profession, int grade = 0, int guildMarks = 0) {
            Recipe recipe = recipes.FirstOrDefault(r => r.Name == name);
            if (Equals(recipe, default(Profession))) {
                recipe = new Recipe(name, profession, grade, guildMarks);
                recipes.Add(recipe);
            }
            return recipe;
        }

        /// <summary> Remove a recipe </summary>
        /// <param name="recipe">The recipe to remove</param>
        public static void RemoveRecipe(Recipe recipe) {
            if (!recipe.Deletable) {
                throw new ArgumentException("There are still resouces in this recipe");
            }
            recipes.Remove(recipe);
            Database.RecipeTable.RemoveRecipe(recipe.ID);
            (recipe as IDisposable).Dispose();
        }
    }
}
