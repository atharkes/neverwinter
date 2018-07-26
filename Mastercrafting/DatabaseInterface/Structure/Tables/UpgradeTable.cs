using DatabaseInterface.Data;
using DatabaseInterface.Structure.Columns;
using DatabaseInterface.Structure.Constraints;
using System.Collections.Generic;
using System.Data;

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
            ProfessionId = new ProfessionId(new NotNull(), new ForeignKey(TableManager.Profession, TableManager.Profession.ProfessionId));
            Grade = new Grade(new NotNull());
            ResourceId = new ResourceId(new NotNull(), new ForeignKey(TableManager.Resource, TableManager.Resource.ResourceId));
            Amount = new Amount(new NotNull(), new Default<int>(1));
        }

        /// <summary> Create the profession upgrade table in the database </summary>
        public override void Create() => Create(new List<IColumn>() { ProfessionId, Grade, ResourceId, Amount });

        /// <summary> Loads the data in this table </summary>
        public override void LoadData() {
            DataTable table = GetAllData();
            foreach (DataRow row in table.Rows) {
                Profession profession = TableManager.Profession.GetProfession(ProfessionId.Parse(row));
                int grade = Grade.Parse(row);
                Resource resource = TableManager.Resource.GetResource(ResourceId.Parse(row));
                int amount = Amount.Parse(row);
                profession.AddUpgradeCost(grade, resource, amount);
            }
        }
    }
}
