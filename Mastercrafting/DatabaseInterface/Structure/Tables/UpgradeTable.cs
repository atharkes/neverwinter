using DatabaseInterface.Structure.Columns;
using System.Collections.Generic;

namespace DatabaseInterface.Structure.Tables {
    /// <summary> A table managing the cost of upgrading professions </summary>
    class UpgradeTable : Table {
        public override string Name => "ProfessionUpgrades";
        public override string Constraints => $"PRIMARY KEY ({ProfessionId.Name}, {Grade.Name}, {ResourceId.Name})";
        public ProfessionId ProfessionId { get; }
        public Grade Grade { get; }
        public ResourceId ResourceId { get; }
        public Amount Amount { get; }

        /// <summary> Create a new profession upgrade table object </summary>
        public UpgradeTable() {
            ProfessionId = new ProfessionId($"NOT NULL REFERENCES {TableManager.Profession.Name} ({TableManager.Profession.ProfessionId.Name}) ON DELETE RESTRICT ON UPDATE CASCADE");
            Grade = new Grade("NOT NULL");
            ResourceId = new ResourceId($"NOT NULL REFERENCES {TableManager.Resource.Name} ({TableManager.Resource.ResourceId.Name}) ON DELETE RESTRICT ON UPDATE CASCADE");
            Amount = new Amount("NOT NULL DEFAULT (1)");
        }

        /// <summary> Create the profession upgrade table in the database </summary>
        public override void Create() => Create(new List<IColumn>() { ProfessionId, Grade, ResourceId, Amount });
    }
}
