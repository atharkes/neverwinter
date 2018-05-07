﻿using DatabaseInterface.Factory;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseInterface.Data {
    /// <summary> A recipe that consumes resources to create results </summary>
    public class Recipe {
        /// <summary> The id of the recipe </summary>
        internal int ID { get; }
        /// <summary> The name of this recipe </summary>
        public string Name { get; }
        /// <summary> The profession this recipe belongs to </summary>
        public Profession Profession { get; }
        /// <summary> The grade of this recipe </summary>
        public int Grade { get; }
        /// <summary> The cost in guildmarks to instantly get a tier 3 result. 0 indicates it can't be done </summary>
        public int GuildMarks { get; }
        /// <summary> The cost to instantly complete this recipe </summary>
        public int AstralDiamonds { get; }
        /// <summary> The amount of tiers available </summary>
        public const int Tiers = 3;

        /// <summary> Whether the recipe is deletable yet </summary>
        internal bool Deletable => consumed.Count == 0 && result.All(dic => dic.Count == 0);
        /// <summary> All resources used or rewarded by this recipe </summary>
        internal List<Resource> Resources => consumed.Keys.Concat(result.Aggregate((a, b) => a.Concat(b).ToDictionary(x => x.Key, x => x.Value)).Keys).ToList();

        /// <summary> The resources and the amount that are consumed by this recipe </summary>
        Dictionary<Resource, int> consumed { get; }
        /// <summary> The results per tier of this recipe </summary>
        Dictionary<Resource, int>[] result { get; }

        /// <summary> The factory used to create recipes </summary>
        public static readonly RecipeFactory Factory = new RecipeFactory((n, p, g, gm) => new Recipe(n, p, g, gm));
        /// <summary> Create a new recipe object with empty lists </summary>
        private Recipe(string name, Profession profession, int grade, int guildMarks) {
            Name = name;
            Profession = profession;
            Grade = grade;
            GuildMarks = guildMarks;
            AstralDiamonds = 20_000;
            consumed = new Dictionary<Resource, int>();
            result = new Dictionary<Resource, int>[Tiers];
            for (int i = 0; i < Tiers; i++) {
                result[i] = new Dictionary<Resource, int>();
            }
            TableManager.Recipe.InsertRecipe(name, profession.ID, grade);
            ID = TableManager.Recipe.GetRecipeID(name);
        }

        /// <summary> The resources consumed by this recipe </summary>
        /// <returns>A copy of the list of resources</returns>
        public List<Resource> ConsumedResources() => new List<Resource>(consumed.Keys);

        /// <summary> The amount that is consumed of a specific resource </summary>
        /// <param name="resource">The resource to get the amount for</param>
        /// <returns>The amount of the resource</returns>
        public int ConsumedAmount(Resource resource) => consumed[resource];

        /// <summary> The resources resulted by this recipe </summary>
        /// <param name="tier">The tier of the result</param>
        /// <returns>A copy of the list of resources for the specific result tier</returns>
        public List<Resource> ResultResources(int tier) => new List<Resource>(result[tier].Keys);

        /// <summary> The amount of the result of a specific resource </summary>
        /// <param name="tier">The tier of the result</param>
        /// <param name="resource">The resource that is resulted</param>
        /// <returns>The amount of the resource at the specific tier</returns>
        public int ResultAmount(int tier, Resource resource) => result[tier][resource];

        /// <summary> Add a resource to the recipe cost </summary>
        /// <param name="resource">The resource to add</param>
        /// <param name="amount">The amount of the resource</param>
        public void AddConsumed(Resource resource, int amount) {
            consumed.Add(resource, amount);
            TableManager.RecipeCost.InsertRecipeCost(ID, resource.ID, amount);
        }

        /// <summary> Remove a resouce from the recipe cost</summary>
        /// <param name="resource">The resource to remove</param>
        public void RemoveConsumed(Resource resource) {
            consumed.Remove(resource);
            TableManager.RecipeCost.RemoveRecipeCost(ID, resource.ID);
        }

        /// <summary> Add a resource to a result of the recipe </summary>
        /// <param name="tier">The tier of the result</param>
        /// <param name="resource">The resource to add to the result tier</param>
        /// <param name="amount">The amount of the resource to add</param>
        public void AddResultResource(int tier, Resource resource, int amount) {
            result[tier].Add(resource, amount);
            TableManager.RecipeResult.InsertRecipeResult(ID, tier, resource.ID, amount);
        }

        /// <summary> Remove a resource from a result of the recipe </summary>
        /// <param name="tier">The tier of the result</param>
        /// <param name="resource">The resource to remove from the result tier</param>
        public void RemoveResultResource(int tier, Resource resource) {
            result[tier].Remove(resource);
            TableManager.RecipeResult.RemoveRecipeResult(ID, tier, resource.ID);
        }
    }
}