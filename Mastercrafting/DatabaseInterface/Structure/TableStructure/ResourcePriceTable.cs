using System.Collections.Generic;

namespace DatabaseInterface.Structure.TableStructure {
    class ResourcePriceTable : Table {
        public override string Name => "ResourcePrices";
        public override string Constraints => $"PRIMARY KEY ({ResourceID.Name}, {Date.Name})";
        public Column ResourceID { get; }
        public Column Price { get; }
        public Column Date { get; }

        public ResourcePriceTable() {
            ResourceID = new Column(Column.Columns.ResourceId, $"NOT NULL REFERENCES {TableManager.Resource.Name} ({TableManager.Resource.ResourceID.Name}) ON DELETE RESTRICT ON UPDATE CASCADE");
            Price = new Column(Column.Columns.Price, "NOT NULL");
            Date = new Column(Column.Columns.Date, "NOT NULL");
        }

        public override void Create() => Create(new List<Column>() { ResourceID, Price, Date });
    }
}
