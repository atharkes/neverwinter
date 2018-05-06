using System;
using System.Collections.Generic;
using System.Data;

namespace DatabaseInterface.Structure.Tables {
    /// <summary> A table managing resources and their costs </summary>
    class ResourceTable : Table {
        public Column ResourceID { get; }
        public Column Resource { get; }
        public Column Price { get; }
        public Column Date { get; }

        /// <summary> Create a new resource table object </summary>
        public ResourceTable() : base("Resources") {
            ResourceID = new Column(Column.Columns.ResourceId, "NOT NULL UNIQUE PRIMARY KEY AUTOINCREMENT");
            Resource = new Column(Column.Columns.Resource, "NOT NULL UNIQUE");
            Price = new Column(Column.Columns.Price, "NOT NULL DEFAULT (1)");
            Date = new Column(Column.Columns.Date, "NOT NULL DEFAULT (CURRENT_TIMESTAMP)");
        }

        /// <summary> Creates the resource table in the database </summary>
        public override void Create() => Create(new List<Column>() { Resource, ResourceID, Price, Date });

        /// <summary> Add a new resource to the table </summary>
        /// <param name="name">The name of the resource</param>
        /// <param name="cost">The cost of the resource in astral diamonds</param>
        public void InsertResource(string name, int cost = 1) => InsertDataRow(new List<(Column, object)>() { (Resource, name), (Price, cost) });

        /// <summary> Remove a resource from the table </summary>
        /// <param name="resourceId">The id of the resource to remove</param>
        public void RemoveResource(int resourceId) => RemoveDataRow(new List<(Column, object)>() { (ResourceID, resourceId) });

        /// <summary> Get the id of a resource </summary>
        /// <param name="resource">The name of the resource</param>
        /// <returns>The id of the resource</returns>
        public int GetResourceID(string resource) {
            DataTable result = GetDataRows(new List<(Column, object)>() { (Resource, resource) });
            if (result.Rows.Count == 1) {
                return result.Rows[0].Field<int>(ResourceID.Name);
            } else if (result.Rows.Count == 0) {
                throw new ArgumentException("The recipe does not exist in the database");
            } else {
                throw new ArgumentException("There are multiple entries of the recipe in the database");
            }
        }
    }
}
