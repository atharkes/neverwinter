using DatabaseInterface;
using DatabaseInterface.Data;
using System;
using System.Collections.Generic;
using System.IO;

namespace RecipeDataParser {
    class Program {
        /// <summary> The folder in which the data files of the different professions are stored </summary>
        public static string ProfessionDataFolder => Path.Combine(Environment.CurrentDirectory, @"RecipeData");

        /// <summary> The types of rows in the data </summary>
        public enum RowTypes {
            Empty,
            TierDelimiter,
            TierHeader,
            RecipeInitial,
            RecipeConsumes,
            RecipeFinal
        }

        /// <summary> Main call point of the RecipeDataParser project </summary>
        /// <param name="args">The arguments given on execution</param>
        static void Main(string[] args) {
            Database.InitializeDatabase("test.sqlite");

            // Load all data currently in the database
            List<Profession> professions = Profession.Factory.LoadProfessions();
            List<Resource> resources = Resource.Factory.LoadResources();
            List<Recipe> recipes = Recipe.Factory.LoadRecipes();
            Recipe.Factory.LoadRecipeCosts();
            Recipe.Factory.LoadRecipeResults();

            // Parse profession data
            foreach (string filePath in Directory.EnumerateFiles(ProfessionDataFolder)) {
                Console.WriteLine("Reading File: {0}", Path.GetFileName(filePath));
                using (StreamReader sr = new StreamReader(filePath)) {
                   
                }
            }

            Database.CloseDatabase();
        }
    }
}
