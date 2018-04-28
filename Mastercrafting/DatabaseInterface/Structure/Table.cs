using System.Collections.Generic;
using System.Data.SQLite;

namespace DatabaseInterface.Structure {
    /// <summary> Abstract table class that has a name, column definitions, and datarows </summary>
    abstract class Table {
        /// <summary> Name of the table </summary>
        public string Name { get; }
        /// <summary> The primary and foreign key constraints of the table </summary>
        public string Constraints { get; }

        /// <summary> Create a new table object </summary>
        /// <param name="name">The name of the table</param>
        public Table(string name, string constraints = "") {
            Name = name;
            Constraints = constraints;
        }

        /// <summary> Creates the table in the database </summary>
        public abstract void Create();

        /// <summary> Creates the table in the database </summary>
        /// <param name="columns">The columns of the table to create</param>
        protected void Create(List<Column> columns) {
            // Create Columns string
            string cols = "(";
            foreach (Column column in columns) {
                cols += column.CreationString + ", ";
            }
            cols = cols.Remove(cols.Length - 2) + ")";
            // Execute Command
            string sql = $"CREATE TABLE {Name} {cols}" ;
            SQLiteCommand command = new SQLiteCommand(sql, Database.Connection);
            command.ExecuteNonQuery();
        }

        /// <summary> Inserts a row of data into the table </summary>
        /// <param name="row">The list with column and values pairs</param>
        protected void InsertDataRow(List<(Column, string)> row) {
            // Create Columns and Values string
            string columns = "(";
            string values = "(";
            foreach ((Column column, string value) in row) {
                columns += column.Name + ", ";
                values += value + ", ";
            }
            columns = columns.Remove(columns.Length - 2) + ")";
            values = values.Remove(columns.Length - 2) + ")";
            
            // Execute Command
            string sql = $"INSERT OR REPLACE INTO {Name} {columns} VALUES {values}";
            SQLiteCommand command = new SQLiteCommand(sql, Database.Connection);
            command.ExecuteNonQuery();
        }
    }
}
