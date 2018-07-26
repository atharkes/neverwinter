using DatabaseInterface.Data;
using DatabaseInterface.Structure.Columns;
using DatabaseInterface.Structure.Constraints;
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
        public override void Create() => Create(ProfessionId, Grade, ResourceId, Amount);

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

        /// <summary> Insert an upgrade cost into the table </summary>
        /// <param name="professionId">The id of the profession to insert the upgrade cost of</param>
        /// <param name="grade">The grade to insert it at</param>
        /// <param name="resourceId">The id of the resource that is required</param>
        /// <param name="amount">The amount of the resource</param>
        public void InsertUpgradeCost(long professionId, int grade, long resourceId, int amount) {
            InsertDataRow((ProfessionId, professionId), (Grade, grade), (ResourceId, resourceId), (Amount, amount));
        }

        /// <summary> Remove an upgrade cost from the table </summary>
        /// <param name="professionId">The id of the profession to remove the upgrade cost of</param>
        /// <param name="grade">The grade the remove it at</param>
        /// <param name="resourceId">The id of the resource to remove</param>
        public void RemoveUpgradeCost(long professionId, int grade, long resourceId) {
            RemoveDataRow((ProfessionId, professionId), (Grade, grade), (ResourceId, resourceId));
        }
    }
}
