using System;
using System.Data;

namespace DatabaseInterface.Structure {
    /// <summary> A column managing the type, name, and constraints </summary>
    abstract class Column<T> : IColumn {
        /// <summary> The name of this column </summary>
        public abstract string Name { get; }
        /// <summary> The data type of this column </summary>
        public string Type { get; }
        /// <summary> The constraints on this column </summary>
        public string Constraints { get; }
        /// <summary> The string used for table creation </summary>
        public string CreationString => $"{Name} {Type} {Constraints}";

        /// <summary> Creates a new column object </summary>
        /// <param name="column">The type of column</param>
        /// <param name="constraints">The constraints of the column</param>
        public Column(params Constraint[] constraints) {
            Type = GetTypeString();
            Constraints = "";
            foreach (Constraint constraint in constraints) {
                Constraints += constraint.GetString() + " ";
            }
            Constraints.Trim();
        }

        /// <summary> Converts a value from this column to a string </summary>
        /// <param name="value">The value in this column</param>
        /// <returns>The string created from the value</returns>
        public string ToString(object value) {
            if (value is string) {
                return $"'{value}'";
            } else {
                return value.ToString();
            }
        }

        /// <summary> Parses a value from a datarow </summary>
        /// <param name="dataRow">The datarow to get the value from</param>
        /// <returns>The value in the datarow from this column</returns>
        public T Parse(DataRow dataRow) {
            return dataRow.Field<T>(Name);
        }

        /// <summary> Gets the sqlite string for a type </summary>
        /// <returns>The sqlite string for the type of this column</returns>
        public string GetTypeString() {
            switch (typeof(T).Name) {
                case nameof(Int64):
                    return "INTEGER";
                case nameof(String):
                    return "STRING";
                case nameof(Int32):
                    return "INT";
                case nameof(DateTime):
                    return "DATETIME";
                default:
                    throw new NotImplementedException($"String of type {typeof(T).Name} not found");
            }
        }
    }
}
