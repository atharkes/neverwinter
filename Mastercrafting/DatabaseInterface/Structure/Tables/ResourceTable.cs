using System.Collections.Generic;

namespace DatabaseInterface.Structure.Tables {
    class ResourceTable : Table {
        public Column ResourceID { get; }
        public Column Resource { get; }
        public Column Price { get; }
        public Column Date { get; }

        public ResourceTable() : base("Resources") {
            ResourceID = new Column(Column.Columns.resource_id, "NOT NULL UNIQUE PRIMARY KEY AUTOINCREMENT");
            Resource = new Column(Column.Columns.resource, "NOT NULL UNIQUE");
            Price = new Column(Column.Columns.price, "NOT NULL DEFAULT (1)");
            Date = new Column(Column.Columns.date, "NOT NULL DEFAULT (CURRENT_TIMESTAMP)");
        }

        public override void Create() => Create(new List<Column>() { Resource, ResourceID, Price, Date });

        public void InsertResource(string name, int cost = 1) => InsertDataRow(new List<(Column, string)>() { (Resource, name), (Price, cost.ToString()) });
    }
}
