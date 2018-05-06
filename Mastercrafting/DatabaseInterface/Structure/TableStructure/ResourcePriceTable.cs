using System.Collections.Generic;

namespace DatabaseInterface.Structure.TableStructure {
    class ResourcePriceTable : Table {
        public const string TableName = "PriceHistory";
        public Column ResourceID { get; }
        public Column Price { get; }
        public Column Date { get; }

        public ResourcePriceTable() : base("PriceHistory", "PRIMARY KEY (resource_id, date)") {
            ResourceID = new Column(Column.Columns.ResourceId, "REFERENCES Resources (resource_id) ON DELETE RESTRICT ON UPDATE CASCADE");
            Price = new Column(Column.Columns.Price, "NOT NULL");
            Date = new Column(Column.Columns.Date, "NOT NULL");
        }

        public override void Create() => Create(new List<Column>() { ResourceID, Price, Date });
    }
}
