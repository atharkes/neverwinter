using DatabaseInterface.Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseInterface.Data {
    /// <summary> A resource that is used by recipes </summary>
    public class Resource {
        /// <summary> The id of the resource </summary>
        internal long ID { get; }
        /// <summary> The name of this resource </summary>
        public string Name { get => name; set { TableManager.Resource.UpdateResourceName(ID, value); name = value; } }
        /// <summary> The price of this resource in astral diamonds </summary>
        public int Price { get => price; set { TableManager.Resource.UpdateResourcePrice(ID, value); price = value; } }

        string name;
        int price;
        /// <summary> All known prices of this resource with the time they are recorded </summary>
        SortedList<DateTime, int> priceHistory { get; }

        /// <summary> The factory used to create resources </summary>
        public static readonly ResourceFactory Factory = new ResourceFactory((n, p) => new Resource(n, p));
        /// <summary> Create a new resource object </summary>
        private Resource(string name, int price) {
            priceHistory = new SortedList<DateTime, int>();
            this.name = name;
            this.price = price;
            TableManager.Resource.InsertResource(name, price);
            ID = TableManager.Resource.GetResourceID(name);
            Price = price;
        }

        /// <summary> The string representing this resource </summary>
        /// <returns>The name of the resource</returns>
        public override string ToString() => Name;

        /// <summary> Return a copy of the price history </summary>
        /// <returns>The copy of the history</returns>
        public Dictionary<DateTime, int> GetPriceHistory() {
            return new Dictionary<DateTime, int>(priceHistory);
        }

        /// <summary> Add a price to the history </summary>
        /// <param name="date">The date the price is logged at</param>
        /// <param name="price">The price at the specific date</param>
        internal void AddPriceHistory(DateTime date, int price) {
            priceHistory.Add(date, price);
        }

        /// <summary> Gets the recipes in which this resource is consumed </summary>
        /// <returns>A list of the recipes this resource is consumed by</returns>
        public List<Recipe> ConsumedBy() {
            List<Recipe> recipes = Recipe.Factory.GetRecipes();
            return recipes.Where(r => r.ConsumedResources().Contains(this)).ToList();
        }

        /// <summary> Gets the recipes in which this resource is a result </summary>
        /// <returns>A list of recipes this resource is a result of</returns>
        public List<Recipe> ResultOf() {
            List<Recipe> recipes = Recipe.Factory.GetRecipes();
            return recipes.Where(r => r.ResultResources(2).Contains(this)).ToList();
        }
    }
}
