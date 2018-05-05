using System;
using System.Collections.Generic;

namespace Mastercrafter {
    /// <summary> A resource that is used by recipes </summary>
    public class Resource {
        /// <summary> The name of this resource </summary>
        public string Name { get; }
        /// <summary> The price of this resource in astral diamonds </summary>
        public int Price { get; }

        /// <summary> All known prices of this resource with the time they are recorded </summary>
        public List<(DateTime Date, int Price)> PriceHistory { get; }

        /// <summary> Create a new resource object </summary>
        public Resource(string name) {
            Name = name;
            Price = 1;
            PriceHistory = new List<(DateTime, int)>();
        }
    }
}
