using System.Collections.Generic;

namespace DatabaseInterface.Structure.Tables {
    /// <summary> A table managing the cost of upgrading professions </summary>
    class UpgradeTable : Table {
        public override string Name => "ProfessionUpgrades";
        public override string Constraints => $"PRIMARY KEY ({ProfessionID.Name}, {Grade.Name}, {ResourceID.Name})";
        public Column<long> ProfessionID { get; }
        public Column<int> Grade { get; }
        public Column<long> ResourceID { get; }
        public Column<int> Amount { get; }

        /// <summary> Create a new profession upgrade table object </summary>
        public UpgradeTable() {
            ProfessionID = new Column<long>(ColumnType.ProfessionId, $"NOT NULL REFERENCES {TableManager.Profession.Name} ({TableManager.Profession.ProfessionID.Name}) ON DELETE RESTRICT ON UPDATE CASCADE");
            Grade = new Column<int>(ColumnType.Grade, "NOT NULL");
            ResourceID = new Column<long>(ColumnType.ResourceId, $"NOT NULL REFERENCES {TableManager.Resource.Name} ({TableManager.Resource.ResourceID.Name}) ON DELETE RESTRICT ON UPDATE CASCADE");
            Amount = new Column<int>(ColumnType.Amount, "NOT NULL DEFAULT (1)");
        }

        /// <summary> Create the profession upgrade table in the database </summary>
        public override void Create() => Create(new List<IColumn>() { ProfessionID, Grade, ResourceID, Amount });
    }
}
