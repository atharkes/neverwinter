using System;
using System.Collections.Generic;

namespace DatabaseInterface.Data {
    /// <summary> A resource that is used by recipes </summary>
    public class Resource {
        /// <summary> The id of the resource </summary>
        internal int ID { get; }
        /// <summary> The name of this resource </summary>
        public string Name { get; }
        /// <summary> The price of this resource in astral diamonds </summary>
        public int Price { get; }

        /// <summary> All known prices of this resource with the time they are recorded </summary>
        List<(DateTime Date, int Price)> priceHistory { get; }

        /// <summary> Create a new resource object </summary>
        internal Resource(string name, int price = 1) {
            Name = name;
            Price = price;
            priceHistory = new List<(DateTime, int)>();
            Database.ResourceTable.InsertResource(name, price);
            ID = Database.ResourceTable.GetResourceID(name);
        }

        public List<(DateTime Date, int Price)> GetPriceHistory() {
            return new List<(DateTime, int)>(priceHistory);
        }

        public void AddPriceHistory(DateTime date, int price) {
            priceHistory.Add((date, price));
        }
    }
}
