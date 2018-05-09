using DatabaseInterface;
using DatabaseInterface.Data;
using System.Collections.Generic;

namespace RecipeDataParser {
    class Program {
        static void Main(string[] args) {
            Database.InitializeDatabase("test.sqlite");

            Profession.Factory.CreateProfession("Artificing", 3);
            Profession.Factory.CreateProfession("Jewelcrafting", 3);

            List<Profession> professions = Profession.Factory.LoadProfessions();
            List<Resource> resources = Resource.Factory.LoadResources();
            List<Recipe> recipes = Recipe.Factory.LoadRecipes();
            Recipe.Factory.LoadRecipeCosts();
            Recipe.Factory.LoadRecipeResults();

            Database.CloseDatabase();
        }
    }
}
