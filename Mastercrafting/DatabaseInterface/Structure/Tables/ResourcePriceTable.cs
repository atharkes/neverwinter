using DatabaseInterface.Data;
using DatabaseInterface.Structure.Columns;
using DatabaseInterface.Structure.Constraints;
using System;
using System.Data;

namespace DatabaseInterface.Structure.Tables {
    /// <summary> A table managing the price history of resources </summary>
    class ResourcePriceTable : Table {
        public override string Name => "ResourcePrices";
        public override string Constraints => $"PRIMARY KEY ({ResourceId.Name}, {Date.Name})";
        public ResourceId ResourceId { get; }
        public Date Date { get; }
        public Price Price { get; }

        /// <summary> Create a new resource price history table object </summary>
        public ResourcePriceTable() {
            ResourceId = new ResourceId(new NotNull(), new ForeignKey(TableManager.Resource, TableManager.Resource.ResourceId));
            Price = new Price(new NotNull());
            Date = new Date(new NotNull());
        }

        /// <summary> Create the resource price history table in the database </summary>
        public override void Create() => Create(ResourceId, Price, Date);

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

        /// <summary> Get the most recent price for a resource </summary>
        /// <param name="resourceId">The id of the resource to find the price for</param>
        /// <returns>The most recent price of the resource in the table</returns>
        public int MostRecentPrice(long resourceId) {
            DataTable table = GetDataRows((ResourceId, resourceId));
            DateTime currentDate = DateTime.MinValue;
            int price = int.MinValue;
            foreach (DataRow row in table.Rows) {
                DateTime date = Date.Parse(row);
                if (date > currentDate) {
                    price = Price.Parse(row);
                    currentDate = date;
                }
            }
            return price;
        }

        /// <summary> Insert a resource price into the table </summary>
        /// <param name="resourceId">The id of the resource to insert a price from</param>
        /// <param name="date">The date to log the price to</param>
        /// <param name="price">The price of the resource at the specified date</param>
        public void InsertResourcePrice(long resourceId, DateTime date, int price) {
            InsertDataRow((ResourceId, resourceId), (Date, date), (Price, price));
        }

        /// <summary> Remove a resource price from the table </summary>
        /// <param name="resourceId">The id of the resource to remove the price from</param>
        /// <param name="date">The date of the price log to remove</param>
        public void RemoveResourcePrice(long resourceId, DateTime date) {
            RemoveDataRow((ResourceId, resourceId), (Date, date));
        }
    }
}
