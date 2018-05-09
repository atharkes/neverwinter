using System;
using System.Collections.Generic;

namespace DatabaseInterface.Structure.TableStructure {
    /// <summary> A table managing the price history of resources </summary>
    class ResourcePriceTable : Table {
        public override string Name => "ResourcePrices";
        public override string Constraints => $"PRIMARY KEY ({ResourceID.Name}, {Date.Name})";
        public Column<long> ResourceID { get; }
        public Column<int> Price { get; }
        public Column<DateTime> Date { get; }

        /// <summary> Create a new resource price history table object </summary>
        public ResourcePriceTable() {
            ResourceID = new Column<long>(Columns.ResourceId, $"NOT NULL REFERENCES {TableManager.Resource.Name} ({TableManager.Resource.ResourceID.Name}) ON DELETE RESTRICT ON UPDATE CASCADE");
            Price = new Column<int>(Columns.Price, "NOT NULL");
            Date = new Column<DateTime>(Columns.Date, "NOT NULL");
        }

        /// <summary> Create the resource price history table in the database </summary>
        public override void Create() => Create(new List<IColumn>() { ResourceID, Price, Date });
    }
}
