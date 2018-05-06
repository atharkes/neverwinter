using System.Collections.Generic;

namespace DatabaseInterface.Data {
    /// <summary> A profession has recipes and certain grade </summary>
    public class Profession {
        /// <summary> The id of the profession </summary>
        internal int ID { get; }
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
        /// <summary> The grade at which the epic tool is unlocked </summary>
        public const int ToolUnlockGrade = 2;
        /// <summary> Whether the epic tool is avaiable, increasing success rates </summary>
        public bool HasTool => Grade >= ToolUnlockGrade;

        /// <summary> Create a new profession object with no recipes </summary>
        internal Profession(string name, int grade = 0) {
            Name = name;
            Grade = grade;
            Recipes = new List<Recipe>();
            Upgrade = new List<(Resource, int)>[Grades];
            for (int i = 0; i < Grades; i++) {
                Upgrade[i] = new List<(Resource, int)>();
            }
            Database.ProfessionTable.InsertProfession(name, grade);
            ID = Database.ProfessionTable.GetProfessionID(name);
        }
        
        /// <summary> The recipes that are currently available corresponding to the grade </summary>
        /// <returns>The recipes that are available</returns>
        public List<Recipe> AvailableRecipes() {
            throw new System.NotImplementedException();
        }
    }
}
