using System;
using System.Collections.Generic;

namespace Mastercrafting {

    class Program {
        static Database database;

        static HashSet<Resource> resources;
        static Dictionary<Profession, Profession> professions;

        static void Main(string[] args) {
            database = new Database("MCDatabase.sqlite");
            string input;
            while ((input = Console.ReadLine()) != "") {

            }
            //AddResource(new Resource("Adamant Sand", 2000));
            //AddProfession(new Profession("Artificing", true));
            database.CloseDatabase();
        }
        

        static void AddResource(Resource resource) {
            database.AddValue("resources", "('" + resource.name + "', " + resource.price + ", " + "DATETIME('NOW')" + ")");
            database.AddValue("priceHistory", "('" + resource.name + "', " + resource.price + ", " + "DATETIME('NOW')" + ")");
            //resources.Add(resource);
        }

        static void AddRecipe(Recipe recipe, Profession profession) {
            database.AddValue("recipes", "('" + recipe.name + "', '" + profession.name + "')");
            foreach (Tuple<Resource, int> tuple in recipe.consumedResources) {
                database.AddValue("consumedResources", "('" + recipe.name + "', '" + tuple.Item1.name + "', " + tuple.Item2 + ")");
            }
            for (int tier = 1; tier <= 3; tier++) {
                foreach (Tuple<Resource, int> tuple in recipe.results[tier]) {
                    database.AddValue("results", "('" + recipe.name + "', " + tier + ", '" + tuple.Item1.name + "', " + tuple.Item2 + ")");
                }
            }
            //professions[profession].AddRecipe(recipe);
        }

        static void AddProfession(Profession profession) {
            database.AddValue("professions", "('" + profession.name + "', " + (profession.tool == true ? 1 : 0) + ")");
            //professions.Add(profession, profession);
        }
    }


    class Recipe {
        public string name;
        public List<Tuple<Resource, int>> consumedResources;
        public List<Tuple<Resource, int>>[] results;

        public Recipe(string name, List<Tuple<Resource, int>> consumedResources, List<Tuple<Resource, int>>[] results) {
            this.name = name;
            this.consumedResources = consumedResources;
            this.results = results;
        }
    }

    class Resource {
        public string name;
        public int price;
        public DateTime lastUpdate;

        public Resource(string name, int price) {
            this.name = name;
            this.price = price;
            lastUpdate = DateTime.UtcNow;
        }

        public void UpdatePrice(int newPrice) {
            price = newPrice;
            lastUpdate = new DateTime();
        }

    }

    class Profession {
        public string name;
        public bool tool;
        public List<Recipe> recipes;

        public Profession(string name, bool tool) {
            this.name = name;
            this.tool = tool;
        }

        public void AddRecipe(Recipe recipe) {
            recipes.Add(recipe);
        }
    }
}