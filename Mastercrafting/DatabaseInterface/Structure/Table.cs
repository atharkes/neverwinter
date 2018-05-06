using System.Collections.Generic;
using System.Data;

namespace DatabaseInterface.Structure {
    /// <summary> Abstract table class that has a name, column definitions, and datarows </summary>
    abstract class Table {
        /// <summary> Name of the table </summary>
        public abstract string Name { get; }
        /// <summary> The primary and foreign key constraints of the table </summary>
        public abstract string Constraints { get; }

        /// <summary> Whether this table exists in the database </summary>
        public bool Exists => Database.Query($"SELECT name FROM sqlite_master WHERE type = 'table' AND name = '{Name}'").Rows.Count > 0;

        /// <summary> Creates the table in the database </summary>
        public abstract void Create();

        /// <summary> Creates the table in the database </summary>
        /// <param name="columns">The columns of the table to create</param>
        protected void Create(List<Column> columns) {
            // Create Columns string
            string cols = "";
            foreach (Column column in columns) {
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
        protected DataTable GetDataRows(List<(Column, object)> constraints) {
            // Create Constraint string
            string where = "";
            foreach ((Column column, object constraint) in constraints) {
                where += $"{column.Name} = {constraint.ToString()} AND ";
            }
            where.Remove(where.Length - 5);
            // Execute Command
            return Database.Query($"SELECT * FROM {Name} WHERE {where}");
        }

        /// <summary> Inserts a row of data into the table </summary>
        /// <param name="row">The list with column and values pairs</param>
        protected void InsertDataRow(List<(Column, object)> row) {
            // Create Columns and Values string
            string columns = "";
            string values = "";
            foreach ((Column column, object value) in row) {
                columns += column.Name + ", ";
                values += value.ToString() + ", ";
            }
            columns = columns.Remove(columns.Length - 2);
            values = values.Remove(columns.Length - 2);
            // Execute Command
            Database.NonQuery($"INSERT OR REPLACE INTO {Name} ({columns}) VALUES ({values})");
        }

        /// <summary> Remove a data row with certain constraints. Currently only works with equality checking </summary>
        /// <param name="constraints">The constraints</param>
        protected void RemoveDataRow(List<(Column, object)> constraints) {
            // Create Constraint string
            string where = "";
            foreach ((Column column, object constraint) in constraints) {
                where += $"{column.Name} = {constraint.ToString()} AND ";
            }
            where.Remove(where.Length - 5);
            // Execute Command
            Database.NonQuery($"DELETE FROM {Name} WHERE {where}");
        }
    }
}
