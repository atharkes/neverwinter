using DatabaseInterface.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseInterface.Factory {
    /// <summary> Creates recipes, making sure there are no multiple objects of the same recipe </summary>
    public class RecipeFactory {
        /// <summary> The set of all recipe objects </summary>
        internal HashSet<Recipe> Recipes = new HashSet<Recipe>();
        /// <summary> The function used to create recipes </summary>
        Func<string, Profession, int, int, Recipe> createRecipe;

        /// <summary> Create a new recipe factory </summary>
        /// <param name="createRecipe">The function used to create recipes with</param>
        internal RecipeFactory(Func<string, Profession, int, int, Recipe> createRecipe) {
            this.createRecipe = createRecipe;
        }

        /// <summary> Load all the recipes from the recipe table </summary>
        /// <returns>A list of all the recipes</returns>
        public List<Recipe> LoadRecipes() {
            return TableManager.Recipe.LoadRecipes();
        }

        /// <summary> Loads the costs of recipes </summary>
        public void LoadRecipeCosts() {
            TableManager.RecipeCost.LoadRecipeCosts();
        }

        /// <summary> Loads the results of recipes </summary>
        public void LoadRecipeResults() {
            TableManager.RecipeResult.LoadRecipeResults();
        }

        /// <summary> Create a new recipe, or get a reference to the already existing object </summary>
        /// <param name="name">The name of the recipe</param>
        /// <param name="profession">The profession this recipe belongs to</param>
        /// <param name="grade">The grade of this recipe</param>
        /// <param name="guildMarks">The amount of guildmarks it costs to insta complete this recipe</param>
        /// <returns>The recipe object corresponding to the name</returns>
        public Recipe CreateRecipe(string name, Profession profession, int grade = 0, int guildMarks = 0) {
            Recipe recipe = Recipes.FirstOrDefault(r => r.Name == name);
            if (Equals(recipe, default(Profession))) {
                recipe = createRecipe.Invoke(name, profession, grade, guildMarks);
                Recipes.Add(recipe);
            }
            return recipe;
        }

        /// <summary> Remove a recipe </summary>
        /// <param name="recipe">The recipe to remove</param>
        public void RemoveRecipe(Recipe recipe) {
            if (!recipe.Deletable) {
                throw new ArgumentException("There are still resouces in this recipe");
            }
            Recipes.Remove(recipe);
            TableManager.Recipe.RemoveRecipe(recipe.ID);
            (recipe as IDisposable).Dispose();
        }
    }
}
