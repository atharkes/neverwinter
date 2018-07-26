using DatabaseInterface.Data;
using DatabaseInterface.Structure.Columns;
using DatabaseInterface.Structure.Constraints;
using System;
using System.Collections.Generic;
using System.Data;

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

        /// <summary> Load the data in the table </summary>
        public override void LoadData() {
            DataTable table = GetAllData();
            foreach (DataRow row in table.Rows) {
                long resourceId = ResourceId.Parse(row);
                Resource resource = TableManager.Resource.GetResource(resourceId);
                DateTime date = Date.Parse(row);
                int price = Price.Parse(row);
                resource.AddPriceHistory(date, price);
            }
        }
    }
}
