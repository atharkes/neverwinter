using System.Collections.Generic;

namespace Mastercrafter {
    /// <summary> A recipe that consumes resources to create results </summary>
    public class Recipe {
        /// <summary> The name of this recipe </summary>
        public string Name { get; }
        /// <summary> The grade of this recipe </summary>
        public int Grade { get; }
        /// <summary> The cost in guildmarks to instantly get a tier 3 result. 0 indicates it can't be done </summary>
        public int GuildMarks { get; }
        /// <summary> The cost to instantly complete this recipe </summary>
        public int AstralDiamonds { get; }

        /// <summary> The resources and the amount that are consumed by this recipe </summary>
        public List<(Resource Resource, int Amount)> Consumed { get; }
        /// <summary> The results per tier of this recipe </summary>
        public List<(Resource Resource, int Amount)>[] Result { get; }
        /// <summary> The amount of tiers available </summary>
        public const int Tiers = 3;

        /// <summary> Create a new recipe object with empty lists </summary>
        public Recipe(string name, int guildMarks = 0) {
            Name = name;
            GuildMarks = guildMarks;
            AstralDiamonds = 20_000;
            Consumed = new List<(Resource, int)>();
            Result = new List<(Resource, int)>[Tiers];
            for (int i = 0; i < Tiers; i++) {
                Result[i] = new List<(Resource, int)>();
            }
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
