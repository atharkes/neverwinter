using System.Collections.Generic;

namespace DatabaseInterface.Structure.Tables {
    class UpgradeTable : Table {
        public Column ProfessionID { get; }
        public Column Grade { get; }
        public Column ResourceID { get; }
        public Column Amount { get; }

        public UpgradeTable() : base("Upgrades", "PRIMARY KEY (profession_id, grade, resource_id)") {
            ProfessionID = new Column(Column.Columns.profession_id, "NOT NULL REFERENCES Professions (profession_id) ON DELETE RESTRICT ON UPDATE CASCADE");
            Grade = new Column(Column.Columns.grade, "NOT NULL");
            ResourceID = new Column(Column.Columns.resource_id, "NOT NULL REFERENCES Resources (resource_id) ON DELETE RESTRICT ON UPDATE CASCADE");
            Amount = new Column(Column.Columns.amount, "NOT NULL DEFAULT (1)");
        }

        public override void Create() => Create(new List<Column>() { ProfessionID, Grade, ResourceID, Amount });
    }
}
