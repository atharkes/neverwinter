using DatabaseInterface.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace DatabaseInterface.Structure.TableStructure {
    /// <summary> A table managing professsions and their grades </summary>
    class ProfessionTable : Table {
        public Column ProfessionID { get; }
        public Column ProfessionName { get; }
        public Column Grade { get; }

        /// <summary> Create a new profession table object </summary>
        public ProfessionTable() : base("Professions") {
            ProfessionID = new Column(Column.Columns.ProfessionId, "NOT NULL UNIQUE PRIMARY KEY AUTOINCREMENT");
            ProfessionName = new Column(Column.Columns.ProfessionName, "NOT NULL UNIQUE");
            Grade = new Column(Column.Columns.Grade, "NOT NULL DEFAULT (0)");
        }

        /// <summary> Create the profession table in the database </summary>
        public override void Create() => Create(new List<Column>() { ProfessionName, ProfessionID, Grade });

        /// <summary> Load all profession from the database </summary>
        /// <returns>The professions loaded from the database</returns>
        public List<Profession> LoadProfessions() {
            List<Profession> professions = new List<Profession>();
            DataTable table = GetAllData();
            foreach (DataRow row in table.Rows) {
                professions.Add(LoadProfession(row));
            }
            return professions;
        }

        /// <summary> Get a profession on a certain id </summary>
        /// <param name="professionId">The id of the profession to get</param>
        /// <returns>The profession corresponding to the id</returns>
        public Profession GetProfession(int professionId) {
            DataTable table = GetDataRows(new List<(Column, object)>() { (ProfessionID, professionId) });
            if (table.Rows.Count == 0) {
                throw new ArgumentException("The requested profession does not exist in the database");
            }
            return LoadProfession(table.Rows[0]);
        }

        /// <summary> Load a profession from a datarow from the table </summary>
        /// <param name="row">The datarow. Must be from this table</param>
        /// <returns>The profession corresponding to the datarow</returns>
        Profession LoadProfession(DataRow row) {
            string name = row.Field<string>(ProfessionName.Name);
            int grade = row.Field<int>(Grade.Name);
            return Profession.Factory.CreateProfession(name, grade);
        }

        /// <summary> Insert a new profession into the table </summary>
        /// <param name="name">The name of the profession</param>
        /// <param name="grade">The grade of the profession</param>
        public void InsertProfession(string name, int grade = 0) => InsertDataRow(new List<(Column, object)>() { (ProfessionName, name), (Grade, grade) });

        /// <summary> Remove a profession from the table </summary>
        /// <param name="name">The id of the profession to remove</param>
        public void RemoveProfession(int professionId) => RemoveDataRow(new List<(Column, object)>() { (ProfessionID, professionId) });

        /// <summary> Get the id of a profession </summary>
        /// <param name="profession">The name of the profession</param>
        /// <returns>The id of the profession</returns>
        public int GetProfessionID(string profession) {
            DataTable table = GetDataRows(new List<(Column, object)>() { (ProfessionName, profession) });
            if (table.Rows.Count == 0) {
                throw new ArgumentException("The requested profession does not exist in the database");
            } else if (table.Rows.Count > 1) {
                throw new ArgumentException("There are multiple entries of the profession in the database");
            }
            return table.Rows[0].Field<int>(ProfessionID.Name);
        }
    }
}
