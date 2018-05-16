using DatabaseInterface.Structure.Columns;
using DatabaseInterface.Structure.Constraints;
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
            ResourceId = new ResourceId(new NotNull(), new ForeignKey(TableManager.Resource, TableManager.Resource.ResourceId));
            Price = new Price(new NotNull());
            Date = new Date(new NotNull());
        }

        /// <summary> Create the resource price history table in the database </summary>
        public override void Create() => Create(new List<IColumn>() { ResourceId, Price, Date });
    }
}
