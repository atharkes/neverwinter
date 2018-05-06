using System;
using System.Collections.Generic;
using System.Data;

namespace DatabaseInterface.Structure.Tables {
    /// <summary> A table managing professsions and their grades </summary>
    class ProfessionTable : Table {
        public Column ProfessionID { get; }
        public Column Profession { get; }
        public Column Grade { get; }

        /// <summary> Create a new profession table object </summary>
        public ProfessionTable() : base("Professions") {
            ProfessionID = new Column(Column.Columns.ProfessionId, "NOT NULL UNIQUE PRIMARY KEY AUTOINCREMENT");
            Profession = new Column(Column.Columns.Profession, "NOT NULL UNIQUE");
            Grade = new Column(Column.Columns.Grade, "NOT NULL DEFAULT (0)");
        }

        /// <summary> Create the profession table in the database </summary>
        public override void Create() => Create(new List<Column>() { Profession, ProfessionID, Grade });

        /// <summary> Insert a new profession into the table </summary>
        /// <param name="name">The name of the profession</param>
        /// <param name="grade">The grade of the profession</param>
        public void InsertProfession(string name, int grade = 0) => InsertDataRow(new List<(Column, object)>() { (Profession, name), (Grade, grade) });

        /// <summary> Remove a profession from the table </summary>
        /// <param name="name">The id of the profession to remove</param>
        public void RemoveProfession(int professionId) => RemoveDataRow(new List<(Column, object)>() { (ProfessionID, professionId) });

        /// <summary> Get the id of a profession </summary>
        /// <param name="profession">The name of the profession</param>
        /// <returns>The id of the profession</returns>
        public int GetProfessionID(string profession) {
            DataTable result = GetDataRows(new List<(Column, object)>() { (Profession, profession) });
            if (result.Rows.Count == 1) {
                return result.Rows[0].Field<int>(ProfessionID.Name);
            } else if (result.Rows.Count == 0) {
                throw new ArgumentException("The recipe does not exist in the database");
            } else {
                throw new ArgumentException("There are multiple entries of the recipe in the database");
            }
        }
    }
}
