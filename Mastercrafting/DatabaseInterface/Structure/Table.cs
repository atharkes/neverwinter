using System.Collections.Generic;
using System.Data;

namespace DatabaseInterface.Structure {
    /// <summary> Abstract table class that has a name, column definitions, and datarows </summary>
    abstract class Table {
        /// <summary> The name of the table </summary>
        public abstract string Name { get; }
        /// <summary> The primary key constraints of the table </summary>
        public abstract string Constraints { get; }

        /// <summary> Whether this table exists in the database </summary>
        public bool Exists => Database.Query($"SELECT name FROM sqlite_master WHERE type = 'table' AND name = '{Name}'").Rows.Count > 0;

        /// <summary> Creates the table in the database </summary>
        public abstract void Create();
        /// <summary> Load the data in the table </summary>
        public abstract void LoadData();

        /// <summary> Creates the table in the database </summary>
        /// <param name="columns">The columns of the table to create</param>
        protected void Create(params IColumn[] columns) {
            // Create Columns string
            string cols = "";
            foreach (IColumn column in columns) {
                cols += column.CreationString + ", ";
            }
            if (Constraints == "") {
                cols = cols.Remove(cols.Length - 2);
            } else {
                cols += Constraints;
            }
            // Execute Command
            Database.NonQuery($"CREATE TABLE {Name} ({cols})");
        }

        /// <summary> Gets all data from this table </summary>
        /// <returns>All data wrapped in a datatable</returns>
        protected DataTable GetAllData() {
            return Database.Query($"SELECT * FROM {Name}");
        }

        /// <summary> Get data from this table based on some equality constraints </summary>
        /// <param name="constraints">The constraints</param>
        protected DataTable GetDataRows(params (IColumn, object)[] constraints) {
            // Create Constraint string
            string where = "";
            foreach ((IColumn column, object constraint) in constraints) {
                where += $"{column.Name} = {column.ToString(constraint)} AND ";
            }
            where = where.Remove(where.Length - 5);
            // Execute Command
            return Database.Query($"SELECT * FROM {Name} WHERE {where}");
        }

        /// <summary> Inserts a row of data into the table </summary>
        /// <param name="row">The list with column and values pairs</param>
        protected void InsertDataRow(params (IColumn, object)[] row) {
            // Create Columns and Values string
            string columns = "";
            string values = "";
            foreach ((IColumn column, object value) in row) {
                columns += column.Name + ", ";
                values += column.ToString(value) + ", ";
            }
            columns = columns.Remove(columns.Length - 2);
            values = values.Remove(values.Length - 2);
            // Execute Command if row doesn't already exist
            if (GetDataRows(row).Rows.Count == 0) {
                Database.NonQuery($"INSERT INTO {Name} ({columns}) VALUES ({values})");
            }
        }
        
        /// <summary> Update a row of data in the table </summary>
        /// <param name="row">The row to update. True indicates the value in the column should be updated. False indicates a constraint</param>
        protected void UpdateDataRow(params (bool, IColumn, object)[] row) {
            // Create Set and Where string
            string where = "";
            string set = "";
            foreach ((bool update, IColumn column, object value) in row) {
                if (update) {
                    set += $"{column.Name} = {column.ToString(value)}, ";
                } else {
                    where += $"{column.Name} = {column.ToString(value)} AND ";
                }
            }
            where = where.Remove(where.Length - 5);
            set = set.Remove(set.Length - 2);
            // Execute Command
            Database.NonQuery($"UPDATE {Name} SET {set} WHERE {where}");
        }

        /// <summary> Remove a data row with certain constraints. Currently only works with equality checking </summary>
        /// <param name="constraints">The constraints the row has to satisfy</param>
        protected void RemoveDataRow(params (IColumn, object)[] constraints) {
            // Create Constraint string
            string where = "";
            foreach ((IColumn column, object constraint) in constraints) {
                where += $"{column.Name} = {column.ToString(constraint)} AND ";
            }
            where = where.Remove(where.Length - 5);
            // Execute Command
            Database.NonQuery($"DELETE FROM {Name} WHERE {where}");
        }
    }
}
