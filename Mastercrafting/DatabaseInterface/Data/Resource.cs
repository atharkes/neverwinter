using DatabaseInterface.Factory;
using DatabaseInterface.Structure.TableStructure;
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

        /// <summary> The factory used to create resources </summary>
        public static readonly ResourceFactory Factory = new ResourceFactory((n, p) => new Resource(n, p));
        /// <summary> Create a new resource object </summary>
        private Resource(string name, int price = 1) {
            Name = name;
            Price = price;
            priceHistory = new List<(DateTime, int)>();
            TableManager.Resource.InsertResource(name, price);
            ID = TableManager.Resource.GetResourceID(name);
        }

        /// <summary> Return a copy of the price history </summary>
        /// <returns>The copy of the history</returns>
        public List<(DateTime Date, int Price)> GetPriceHistory() {
            return new List<(DateTime, int)>(priceHistory);
        }

        /// <summary> Add a price to the history </summary>
        /// <param name="date">The date the price is logged at</param>
        /// <param name="price">The price at the specific date</param>
        public void AddPriceHistory(DateTime date, int price) {
            priceHistory.Add((date, price));
        }
    }
}
