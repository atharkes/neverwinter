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

        /// <summary> The resources and the amount that are consumed by this recipe </summary>
        Dictionary<Resource, int> consumed { get; }
        /// <summary> The results per tier of this recipe </summary>
        Dictionary<Resource, int>[] result { get; }

        /// <summary> Create a new recipe object with empty lists </summary>
        internal Recipe(string name, Profession profession, int grade = 0, int guildMarks = 0) {
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
            Database.RecipeTable.InsertRecipe(name, profession.ID, grade);
            ID = Database.RecipeTable.GetRecipeID(name);
        }

        /// <summary> Whether the recipe is deletable yet </summary>
        internal bool Deletable => consumed.Count == 0 && result.All(dic => dic.Count == 0);

        /// <summary> The resources consumed by this recipe </summary>
        public List<Resource> ConsumedResources => consumed.Keys.ToList();

        /// <summary> The amount that is consumed of a certain resource </summary>
        /// <param name="resource">The resource to get the amount for</param>
        /// <returns>The amount of the resource</returns>
        public int ConsumedAmount(Resource resource) => consumed[resource];

        /// <summary> Add a resource to the recipe cost </summary>
        /// <param name="resource">The resource to add</param>
        /// <param name="amount">The amount of the resource</param>
        public void AddConsumed(Resource resource, int amount) {
            consumed.Add(resource, amount);
            Database.RecipeCostTable.InsertRecipeCost(ID, resource.ID, amount);
        }

        /// <summary> Remove a resouce from the recipe cost</summary>
        /// <param name="resource">The resource to remove</param>
        public void RemoveConsumed(Resource resource) {
            consumed.Remove(resource);
            Database.RecipeCostTable.RemoveRecipeCost(ID, resource.ID);
        }

        /// <summary> Add a resource to a result of the recipe </summary>
        /// <param name="tier">The tier of the result</param>
        /// <param name="resource">The resource to add to the result tier</param>
        /// <param name="amount">The amount of the resource to add</param>
        public void AddResultResource(int tier, Resource resource, int amount) {
            result[tier].Add(resource, amount);
            Database.RecipeResultTable.InsertRecipeResult(ID, tier, resource.ID, amount);
        }

        /// <summary> Remove a resource from a result of the recipe </summary>
        /// <param name="tier">The tier of the result</param>
        /// <param name="resource">The resource to remove from the result tier</param>
        public void RemoveResultResource(int tier, Resource resource) {
            result[tier].Remove(resource);
            Database.RecipeResultTable.RemoveRecipeResult(ID, tier, resource.ID);
        }

        /// <summary> The cost to start this recipe in astral diamonds </summary>
        /// <returns>The amount of astral diamonds the resources cost</returns>
        public int ConsumedCost() {
            throw new System.NotImplementedException();
        }

        /// <summary> The expected profit of this recipe </summary>
        /// <param name="tier">The tier percentage the recipe is done at</param>
        /// <returns>The profit in astral diamonds</returns>
        public int Profit(float tier = 1.75f) {
            throw new System.NotImplementedException();
        }
    }
}
