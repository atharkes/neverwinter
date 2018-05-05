using System.Collections.Generic;

namespace Mastercrafter {
    /// <summary> A profession has recipes and certain grade </summary>
    public class Profession {
        /// <summary> The name of this profession </summary>
        public string Name { get; }
        /// <summary> The grade of this profession </summary>
        public int Grade { get; }
        /// <summary> The recipes in this profession </summary>
        public List<Recipe> Recipes { get; }

        /// <summary> The resources that are needed to upgrade this profession </summary>
        public List<(Resource Resource, int Amount)>[] Upgrade { get; }
        /// <summary> The amount of profession grades currently in the game </summary>
        public const int Grades = 4;

        /// <summary> Create a new profession object with no recipes </summary>
        public Profession(string name) {
            Name = name;
            Grade = 0;
            Recipes = new List<Recipe>();
            Upgrade = new List<(Resource, int)>[Grades];
            for (int i = 0; i < Grades; i++) {
                Upgrade[i] = new List<(Resource, int)>();
            }
        }
        
        /// <summary> The recipes that are currently available corresponding to the grade </summary>
        /// <returns>The recipes that are available</returns>
        public List<Recipe> AvailableRecipes() {
            throw new System.NotImplementedException();
        }
    }
}
