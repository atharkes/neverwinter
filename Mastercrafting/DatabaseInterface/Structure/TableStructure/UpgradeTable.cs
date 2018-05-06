using System.Collections.Generic;

namespace DatabaseInterface.Structure.TableStructure {
    class UpgradeTable : Table {
        public override string Name => "ProfessionUpgrades";
        public override string Constraints => $"PRIMARY KEY ({ProfessionID.Name}, {Grade.Name}, {ResourceID.Name})";
        public Column ProfessionID { get; }
        public Column Grade { get; }
        public Column ResourceID { get; }
        public Column Amount { get; }

        public UpgradeTable() {
            ProfessionID = new Column(Column.Columns.ProfessionId, $"NOT NULL REFERENCES {TableManager.Profession.Name} ({TableManager.Profession.ProfessionID.Name}) ON DELETE RESTRICT ON UPDATE CASCADE");
            Grade = new Column(Column.Columns.Grade, "NOT NULL");
            ResourceID = new Column(Column.Columns.ResourceId, $"NOT NULL REFERENCES {TableManager.Resource.Name} ({TableManager.Resource.ResourceID.Name}) ON DELETE RESTRICT ON UPDATE CASCADE");
            Amount = new Column(Column.Columns.Amount, "NOT NULL DEFAULT (1)");
        }

        public override void Create() => Create(new List<Column>() { ProfessionID, Grade, ResourceID, Amount });
    }
}
