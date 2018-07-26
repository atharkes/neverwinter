using DatabaseInterface.Data;
using DatabaseInterface.Structure.Columns;
using DatabaseInterface.Structure.Constraints;
using System;
using System.Data;

namespace DatabaseInterface.Structure.Tables {
    /// <summary> A table managing professsions and their grades </summary>
    class ProfessionTable : Table {
        public override string Name => "Professions";
        public override string Constraints => "";
        public ProfessionId ProfessionId { get; }
        public ProfessionName ProfessionName { get; }
        public Grade Grade { get; }

        /// <summary> Create a new profession table object </summary>
        public ProfessionTable() {
            ProfessionId = new ProfessionId(new NotNull(), new Unique(), new PrimaryKey(true));
            ProfessionName = new ProfessionName(new NotNull(), new Unique());
            Grade = new Grade(new NotNull(), new Default<int>(0));
        }

        /// <summary> Create the profession table in the database </summary>
        public override void Create() => Create(ProfessionName, ProfessionId, Grade);

        /// <summary> Load all profession from the database </summary>
        public override void LoadData() {
            DataTable table = GetAllData();
            foreach (DataRow row in table.Rows) {
                LoadProfession(row);
            }
        }

        /// <summary> Get a profession on a certain id </summary>
        /// <param name="professionId">The id of the profession to get</param>
        /// <returns>The profession corresponding to the id</returns>
        public Profession GetProfession(long professionId) {
            DataTable table = GetDataRows((ProfessionId, professionId));
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
        public void InsertProfession(string name, int grade = 0) => InsertDataRow((ProfessionName, name), (Grade, grade));

        /// <summary> Remove a profession from the table </summary>
        /// <param name="name">The id of the profession to remove</param>
        public void RemoveProfession(long professionId) => RemoveDataRow((ProfessionId, professionId));

        /// <summary> Get the id of a profession </summary>
        /// <param name="profession">The name of the profession</param>
        /// <returns>The id of the profession</returns>
        public long GetProfessionID(string profession) {
            DataTable table = GetDataRows((ProfessionName, profession));
            if (table.Rows.Count == 0) {
                throw new ArgumentException("The requested profession does not exist in the database");
            } else if (table.Rows.Count > 1) {
                throw new ArgumentException("There are multiple entries of the profession in the database");
            }
            return ProfessionId.Parse(table.Rows[0]);
        }
    }
}
