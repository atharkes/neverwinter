using DatabaseInterface;
using DatabaseInterface.Data;
using System;
using System.IO;
using System.Linq;

namespace RecipeDataParser {
    /// <summary> Top level class of the application </summary>
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
            ParseProfessionData();
            Database.CloseDatabase();
        }

        /// <summary> Parse data in the profession files </summary>
        static void ParseProfessionData() {
            foreach (string filePath in Directory.EnumerateFiles(ProfessionDataFolder)) {
                Console.WriteLine("Reading File: {0}", Path.GetFileName(filePath));
                string professionName = Path.GetFileNameWithoutExtension(filePath);
                Profession profession = Profession.Factory.CreateProfession(professionName);
                using (StreamReader sr = new StreamReader(filePath)) {
                    Recipe recipe = null;
                    int grade = 0;
                    while (!sr.EndOfStream) {
                        string[] row = sr.ReadLine().Split(';');
                        RowType rowType = IdentifyRow(row);
                        switch (rowType) {
                            case RowType.TierDelimiter: {
                                // Set Grade
                                grade = row[0].Count(c => c == 'I');
                                break;
                            }
                            case RowType.RecipeInitial: {
                                // Create Recipe
                                string recipeName = row[2];
                                recipe = Recipe.Factory.CreateRecipe(recipeName, profession, grade);
                                // Add Result Tier 1
                                string[] result = row[8].Split(',');
                                foreach (string resourceAmountPair in result) {
                                    (Resource resource, int amount) = ParseResourceAmountPair(resourceAmountPair.Trim());
                                    recipe?.AddResultResource(0, resource, amount);
                                }
                                break;
                            }
                            case RowType.RecipeConsumes: {
                                // Add Consumed Resources
                                string[] consumes = row[4].Split(',');
                                foreach (string resourceAmountPair in consumes) {
                                    (Resource resource, int amount) = ParseResourceAmountPair(resourceAmountPair.Trim());
                                    recipe?.AddConsumed(resource, amount);
                                }
                                // Add Result Tier 2
                                string[] result = row[8].Split(',');
                                foreach (string resourceAmountPair in result) {
                                    (Resource resource, int amount) = ParseResourceAmountPair(resourceAmountPair.Trim());
                                    recipe?.AddResultResource(1, resource, amount);
                                }
                                break;
                            }
                            case RowType.RecipeFinal: {
                                // Add Result Tier 3
                                string[] result = row[8].Split(',');
                                foreach (string resourceAmountPair in result) {
                                    (Resource resource, int amount) = ParseResourceAmountPair(resourceAmountPair.Trim());
                                    recipe?.AddResultResource(2, resource, amount);
                                }
                                break;
                            }
                        }
                    }
                }
            }
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

        /// <summary> Parse a pair of a resource and it's amount (12x [Purple Vitriol]) </summary>
        /// <returns>The resource and it's amount</returns>
        static (Resource, int) ParseResourceAmountPair(string resourceAmountPair) {
            int resourceStartIndex = resourceAmountPair.IndexOf('[') + 1;
            int resourceEndIndex = resourceAmountPair.IndexOf(']');

            // For Gold, Silver, and Copper
            if (resourceStartIndex == 0 && resourceEndIndex == -1) {
                int index = 0;
                int amount = 0;
                while (Char.IsNumber(resourceAmountPair[index])) {
                    amount = amount * 10 + resourceAmountPair[index];
                    index++;
                }
                string goldName = resourceAmountPair.Substring(index);
                Resource goldType = Resource.Factory.CreateResource(goldName);
                return (goldType, amount);
            }

            string resourceName = resourceAmountPair.Substring(resourceStartIndex, resourceEndIndex - resourceStartIndex);
            Resource resource = Resource.Factory.CreateResource(resourceName);

            if (!Char.IsNumber(resourceAmountPair[0])) {
                return (resource, 1);
            } else {
                int amountEndIndex = resourceAmountPair.IndexOf('x');
                int amount = int.Parse(resourceAmountPair.Substring(0, amountEndIndex));
                return (resource, amount);
            }
        }
    }
}
