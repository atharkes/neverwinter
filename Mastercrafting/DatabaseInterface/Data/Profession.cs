using DatabaseInterface.Factory;
using System.Collections.Generic;

namespace DatabaseInterface.Data {
    /// <summary> A profession has recipes and certain grade </summary>
    public class Profession {
        /// <summary> The id of the profession </summary>
        internal long ID { get; }
        /// <summary> The name of this profession </summary>
        public string Name { get; }
        /// <summary> The grade of this profession </summary>
        public int Grade { get; }
        /// <summary> The amount of profession grades currently in the game </summary>
        public const int Grades = 4;
        /// <summary> The grade at which the epic tool is unlocked </summary>
        public const int ToolUnlockGrade = 2;
        /// <summary> Whether the epic tool is avaiable, increasing success rates </summary>
        public bool HasTool => Grade >= ToolUnlockGrade;

        /// <summary> The recipes in this profession </summary>
        List<Recipe> recipes { get; }
        /// <summary> The resources that are needed to upgrade this profession </summary>
        Dictionary<Resource, int>[] upgrade { get; }

        /// <summary> The factory used to create professions </summary>
        public static readonly ProfessionFactory Factory = new ProfessionFactory((n, g) => new Profession(n, g));
        /// <summary> Create a new profession object with no recipes </summary>
        private Profession(string name, int grade) {
            Name = name;
            Grade = grade;
            recipes = new List<Recipe>();
            upgrade = new Dictionary<Resource, int>[Grades];
            for (int i = 0; i < Grades; i++) {
                upgrade[i] = new Dictionary<Resource, int>();
            }
            TableManager.Profession.InsertProfession(name, grade);
            ID = TableManager.Profession.GetProfessionID(name);
        }

        /// <summary> The string representing this profession </summary>
        /// <returns>The name of the profession</returns>
        public override string ToString() => Name;

        /// <summary> Gets the recipes in this profession </summary>
        /// <returns>A copy of the list of recipes</returns>
        public List<Recipe> Recipes => new List<Recipe>(recipes);

        public void AddUpgradeCost(int grade, Resource resource, int amount) {
            upgrade[grade].Add(resource, amount);
        }

        /// <summary> Add a recipe to profession </summary>
        /// <param name="recipe">The recipe to add to the profession</param>
        internal void AddRecipe(Recipe recipe) => recipes.Add(recipe);

        /// <summary> Remove a recipe from the profession </summary>
        /// <param name="recipe">The recipe to remove</param>
        internal void RemoveRecipe(Recipe recipe) => recipes.Remove(recipe);
    }
}
