using DatabaseInterface.Structure.Columns;
using System.Collections.Generic;

namespace DatabaseInterface.Structure.Tables {
    /// <summary> A table managing the price history of resources </summary>
    class ResourcePriceTable : Table {
        public override string Name => "ResourcePrices";
        public override string Constraints => $"PRIMARY KEY ({ResourceId.Name}, {Date.Name})";
        public ResourceId ResourceId { get; }
        public Price Price { get; }
        public Date Date { get; }

        /// <summary> Create a new resource price history table object </summary>
        public ResourcePriceTable() {
            ResourceId = new ResourceId($"NOT NULL REFERENCES {TableManager.Resource.Name} ({TableManager.Resource.ResourceId.Name}) ON DELETE RESTRICT ON UPDATE CASCADE");
            Price = new Price("NOT NULL");
            Date = new Date("NOT NULL");
        }

        /// <summary> Create the resource price history table in the database </summary>
        public override void Create() => Create(new List<IColumn>() { ResourceId, Price, Date });
    }
}
