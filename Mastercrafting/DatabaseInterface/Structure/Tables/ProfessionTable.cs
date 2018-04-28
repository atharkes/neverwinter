using System.Collections.Generic;

namespace DatabaseInterface.Structure.Tables {
    class ProfessionTable : Table {
        public Column ProfessionID { get; }
        public Column Profession { get; }
        public Column Grade { get; }

        public ProfessionTable() : base("Professions") {
            ProfessionID = new Column(Column.Columns.profession_id, "NOT NULL UNIQUE PRIMARY KEY AUTOINCREMENT");
            Profession = new Column(Column.Columns.profession, "NOT NULL UNIQUE");
            Grade = new Column(Column.Columns.grade, "NOT NULL DEFAULT (0)");
        }

        public override void Create() => Create(new List<Column>() { Profession, ProfessionID, Grade });

        public void InsertProfession(string name, int grade = 0) => InsertDataRow(new List<(Column, string)>() { (Profession, name), (Grade, grade.ToString()) });
    }
}
