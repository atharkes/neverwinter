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
        public enum RowType {
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

            // Parse profession data
            foreach (string filePath in Directory.EnumerateFiles(ProfessionDataFolder)) {
                Console.WriteLine("Reading File: {0}", Path.GetFileName(filePath));
                using (StreamReader sr = new StreamReader(filePath)) {
                    while (!sr.EndOfStream) {
                        string[] row = sr.ReadLine().Split(';');
                        Console.WriteLine(IdentifyRow(row));
                    }
                }
            }

            Database.CloseDatabase();
        }

        /// <summary> Identify the type a row </summary>
        /// <param name="row">The row to identify the type for</param>
        /// <returns>The type of the row</returns>
        static RowType IdentifyRow(string[] row) {
            if (row[0].StartsWith("Masterwork")) {
                return RowType.TierDelimiter;
            }
            if (row[0].StartsWith("Level Req.")) {
                return RowType.TierHeader;
            }
            if (int.TryParse(row[0], out int levelRequired)) {
                return RowType.RecipeInitial;
            }
            if (row[3].StartsWith("Consumes")) {
                return RowType.RecipeConsumes;
            }
            if (row[7].StartsWith("Tier 3")) {
                return RowType.RecipeFinal;
            }
            return RowType.Empty;
        }
    }
}
