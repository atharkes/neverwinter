using DatabaseInterface.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace DatabaseInterface.Structure.TableStructure {
    /// <summary> A table managing resources and their costs </summary>
    class ResourceTable : Table {
        public override string Name => "Resources";
        public override string Constraints => "";
        public Column ResourceID { get; }
        public Column ResourceName { get; }
        public Column Price { get; }
        public Column Date { get; }

        /// <summary> Create a new resource table object </summary>
        public ResourceTable() {
            ResourceID = new Column(Column.Columns.ResourceId, "NOT NULL UNIQUE PRIMARY KEY AUTOINCREMENT");
            ResourceName = new Column(Column.Columns.ResourceName, "NOT NULL UNIQUE");
            Price = new Column(Column.Columns.Price, "NOT NULL DEFAULT (1)");
            Date = new Column(Column.Columns.Date, "NOT NULL DEFAULT (CURRENT_TIMESTAMP)");
        }

        /// <summary> Creates the resource table in the database </summary>
        public override void Create() => Create(new List<Column>() { ResourceName, ResourceID, Price, Date });

        /// <summary> Load all resources from the database </summary>
        /// <returns>The resources loaded from the database</returns>
        public List<Resource> LoadResources() {
            List<Resource> resources = new List<Resource>();
            DataTable table = GetAllData();
            foreach (DataRow row in table.Rows) {
                resources.Add(LoadResource(row));
            }
            return resources;
        }

        /// <summary> Load a resource from a datarow from the table </summary>
        /// <param name="row">The datarow. Must be from this table</param>
        /// <returns>The resource corresponding to the datarow</returns>
        Resource LoadResource(DataRow row) {
            string name = row.Field<string>(ResourceName.Name);
            int price = row.Field<int>(Price.Name);
            return Resource.Factory.CreateResource(name, price);
        }

        /// <summary> Add a new resource to the table </summary>
        /// <param name="name">The name of the resource</param>
        /// <param name="cost">The cost of the resource in astral diamonds</param>
        public void InsertResource(string name, int cost = 1) => InsertDataRow(new List<(Column, object)>() { (ResourceName, name), (Price, cost) });

        /// <summary> Remove a resource from the table </summary>
        /// <param name="resourceId">The id of the resource to remove</param>
        public void RemoveResource(int resourceId) => RemoveDataRow(new List<(Column, object)>() { (ResourceID, resourceId) });

        /// <summary> Get the id of a resource </summary>
        /// <param name="resource">The name of the resource</param>
        /// <returns>The id of the resource</returns>
        public int GetResourceID(string resource) {
            DataTable result = GetDataRows(new List<(Column, object)>() { (ResourceName, resource) });
            if (result.Rows.Count == 0) {
                throw new ArgumentException("The resource does not exist in the database");
            } else if (result.Rows.Count > 1) {
                throw new ArgumentException("There are multiple entries of the resource in the database");
            }
            return result.Rows[0].Field<int>(ResourceID.Name);
        }
    }
}
