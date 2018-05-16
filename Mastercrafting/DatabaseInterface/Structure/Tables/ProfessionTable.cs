using DatabaseInterface.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace DatabaseInterface.Structure.Tables {
    /// <summary> A table managing professsions and their grades </summary>
    class ProfessionTable : Table {
        public override string Name => "Professions";
        public override string Constraints => "";
        public Column<long> ProfessionID { get; }
        public Column<string> ProfessionName { get; }
        public Column<int> Grade { get; }

        /// <summary> Create a new profession table object </summary>
        public ProfessionTable() {
            ProfessionID = new Column<long>(ColumnType.ProfessionId, "NOT NULL UNIQUE PRIMARY KEY AUTOINCREMENT");
            ProfessionName = new Column<string>(ColumnType.ProfessionName, "NOT NULL UNIQUE");
            Grade = new Column<int>(ColumnType.Grade, "NOT NULL DEFAULT (0)");
        }

        /// <summary> Create the profession table in the database </summary>
        public override void Create() => Create(new List<IColumn>() { ProfessionName, ProfessionID, Grade });

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
        public Profession GetProfession(long professionId) {
            DataTable table = GetDataRows(new List<(IColumn, object)>() { (ProfessionID, professionId) });
            if (table.Rows.Count == 0) {
                throw new ArgumentException("The requested profession does not exist in the database");
            }
            return LoadProfession(table.Rows[0]);
        }

        /// <summary> Load a profession from a datarow from the table </summary>
        /// <param name="row">The datarow. Must be from this table</param>
        /// <returns>The profession corresponding to the datarow</returns>
        Profession LoadProfession(DataRow row) {
            string name = ProfessionName.Parse(row);
            int grade = Grade.Parse(row);
            return Profession.Factory.CreateProfession(name, grade);
        }

        /// <summary> Insert a new profession into the table </summary>
        /// <param name="name">The name of the profession</param>
        /// <param name="grade">The grade of the profession</param>
        public void InsertProfession(string name, int grade = 0) => InsertDataRow(new List<(IColumn, object)>() { (ProfessionName, name), (Grade, grade) });

        /// <summary> Remove a profession from the table </summary>
        /// <param name="name">The id of the profession to remove</param>
        public void RemoveProfession(long professionId) => RemoveDataRow(new List<(IColumn, object)>() { (ProfessionID, professionId) });

        /// <summary> Get the id of a profession </summary>
        /// <param name="profession">The name of the profession</param>
        /// <returns>The id of the profession</returns>
        public long GetProfessionID(string profession) {
            DataTable table = GetDataRows(new List<(IColumn, object)>() { (ProfessionName, profession) });
            if (table.Rows.Count == 0) {
                throw new ArgumentException("The requested profession does not exist in the database");
            } else if (table.Rows.Count > 1) {
                throw new ArgumentException("There are multiple entries of the profession in the database");
            }
            return ProfessionID.Parse(table.Rows[0]);
        }
    }
}
