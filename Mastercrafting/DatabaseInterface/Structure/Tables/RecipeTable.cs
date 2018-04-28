using System.Collections.Generic;

namespace DatabaseInterface.Structure.Tables {
    class RecipeTable : Table {
        public Column RecipeID { get; }
        public Column Recipe { get; }
        public Column ProfessionID { get; }
        public Column Grade { get; }

        public RecipeTable() : base("Recipes") {
            RecipeID = new Column(Column.Columns.recipe_id, "NOT NULL UNIQUE PRIMARY KEY AUTOINCREMENT");
            Recipe = new Column(Column.Columns.recipe, "NOT NULL UNIQUE");
            ProfessionID = new Column(Column.Columns.profession_id, "NOT NULL REFERENCES Professions (profession_id) ON DELETE RESTRICT ON UPDATE CASCADE");
            Grade = new Column(Column.Columns.grade, "NOT NULL");
        }

        public override void Create() => Create(new List<Column>() { Recipe, ProfessionID, Grade, RecipeID });

        public void InsertRecipe(string name, int professionID, int grade) {
            InsertDataRow(new List<(Column, string)>() { (Recipe, name), (ProfessionID, professionID.ToString()), (Grade, grade.ToString()) });
        }
    }
}
