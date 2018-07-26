using DatabaseInterface.Data;
using DatabaseInterface.Structure.Columns;
using DatabaseInterface.Structure.Constraints;
using System;
using System.Collections.Generic;
using System.Data;

namespace DatabaseInterface.Structure.Tables {
    /// <summary> A table managing resources and their costs </summary>
    class ResourceTable : Table {
        public override string Name => "Resources";
        public override string Constraints => "";
        public ResourceId ResourceId { get; }
        public ResourceName ResourceName { get; }
        public Price Price { get; }
        public Date Date { get; }

        /// <summary> Create a new resource table object </summary>
        public ResourceTable() {
            ResourceId = new ResourceId(new NotNull(), new Unique(), new PrimaryKey(true));
            ResourceName = new ResourceName(new NotNull(), new Unique());
            Price = new Price(new NotNull(), new Default<int>(1));
            Date = new Date(new NotNull(), new Default<string>("(CURRENT_TIMESTAMP)"));
        }

        /// <summary> Creates the resource table in the database </summary>
        public override void Create() => Create(ResourceName, ResourceId, Price, Date);

        /// <summary> Load all resources from the database </summary>
        public override void LoadData() {
            DataTable table = GetAllData();
            foreach (DataRow row in table.Rows) {
                LoadResource(row);
            }
        }

        /// <summary> Get a recipe on a certain id </summary>
        /// <param name="resourceId">The id of the recipe to get</param>
        /// <returns>The recipe corresponding to the id</returns>
        public Resource GetResource(long resourceId) {
            DataTable table = GetDataRows((ResourceId, resourceId));
            if (table.Rows.Count == 0) {
                throw new ArgumentException("The requested resource does not exist in the database");
            }
            return LoadResource(table.Rows[0]);
        }

        /// <summary> Load a resource from a datarow from the table </summary>
        /// <param name="row">The datarow. Must be from this table</param>
        /// <returns>The resource corresponding to the datarow</returns>
        Resource LoadResource(DataRow row) {
            string name = ResourceName.Parse(row);
            int price = Price.Parse(row);
            return Resource.Factory.CreateResource(name, price);
        }

        /// <summary> Updates a name of a resource in the table </summary>
        /// <param name="resourceId">The id of the resource to update the name for</param>
        /// <param name="name">The new name of the resource</param>
        public void UpdateResourceName(long resourceId, string name) {
            UpdateDataRow((false, ResourceId, resourceId), (true, ResourceName, name));
        }

        /// <summary> Update the price of a resource in the table </summary>
        /// <param name="resourceId">The id of the resrouce to update the price of</param>
        /// <param name="price">The new price of the resource</param>
        public void UpdateResourcePrice(long resourceId, int price) {
            UpdateDataRow((false, ResourceId, resourceId), (true, Price, price));
            TableManager.ResourcePrice.InsertResourcePrice(resourceId, DateTime.Now, price);
        }

        /// <summary> Add a new resource to the table </summary>
        /// <param name="name">The name of the resource</param>
        /// <param name="cost">The cost of the resource in astral diamonds</param>
        public void InsertResource(string name, int cost = 1) => InsertDataRow((ResourceName, name), (Price, cost));

        /// <summary> Remove a resource from the table </summary>
        /// <param name="resourceId">The id of the resource to remove</param>
        public void RemoveResource(long resourceId) => RemoveDataRow((ResourceId, resourceId));

        /// <summary> Get the id of a resource </summary>
        /// <param name="resource">The name of the resource</param>
        /// <returns>The id of the resource</returns>
        public long GetResourceID(string resource) {
            DataTable result = GetDataRows((ResourceName, resource));
            if (result.Rows.Count == 0) {
                throw new ArgumentException("The resource does not exist in the database");
            } else if (result.Rows.Count > 1) {
                throw new ArgumentException("There are multiple entries of the resource in the database");
            }
            return ResourceId.Parse(result.Rows[0]);
        }
    }
}
