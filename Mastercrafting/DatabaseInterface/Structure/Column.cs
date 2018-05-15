using System;
using System.Data;

namespace DatabaseInterface.Structure {
    /// <summary> The columns in the database </summary>
    public enum Columns {
        ProfessionId,
        ProfessionName,
        RecipeId,
        RecipeName,
        ResourceId,
        ResourceName,
        Amount,
        Price,
        Date,
        Grade,
        Tier
    }

    /// <summary> A column managing the type, name, and constraints </summary>
    class Column<T> : IColumn {
        /// <summary> The name of this column </summary>
        public string Name { get; }
        /// <summary> The data type of this column </summary>
        public string Type { get; }
        /// <summary> The constraints on this column </summary>
        public string Constraints { get; }
        /// <summary> The string used for table creation </summary>
        public string CreationString => $"{Name} {Type} {Constraints}";

        /// <summary> Creates a new column object </summary>
        /// <param name="column">The type of column</param>
        /// <param name="constraints">The constraints of the column</param>
        public Column(Columns column, string constraints = "") {
            Name = GetName(column);
            Type = GetType(column);
            Constraints = constraints;
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

        /// <summary> Gets the name for a column </summary>
        /// <param name="column">The column to get the name for</param>
        /// <returns>The name of the column</returns>
        public static string GetName(Columns column) {
            switch (column) {
                case Columns.ProfessionId:
                    return "profession_id";
                case Columns.RecipeId:
                    return "recipe_id";
                case Columns.ResourceId:
                    return "resource_id";
                case Columns.ProfessionName:
                    return "profession";
                case Columns.RecipeName:
                    return "recipe";
                case Columns.ResourceName:
                    return "resource";
                case Columns.Amount:
                    return "amount";
                case Columns.Price:
                    return "price";
                case Columns.Date:
                    return "date";
                case Columns.Grade:
                    return "grade";
                case Columns.Tier:
                    return "tier";
                
                default:
                    throw new NotImplementedException($"Name of column {column} not found");
            }
        }

        /// <summary> Gets the type for a column </summary>
        /// <param name="column">The column to get the type for</param>
        /// <returns>The type of the column</returns>
        public static string GetType(Columns column) {
            switch (column) {
                case Columns.ProfessionId:
                case Columns.RecipeId:
                case Columns.ResourceId:
                    return "INTEGER";
                case Columns.ProfessionName:
                case Columns.RecipeName:
                case Columns.ResourceName:
                    return "STRING";
                case Columns.Amount:
                case Columns.Price:
                case Columns.Grade:
                case Columns.Tier:
                    return "INT";
                case Columns.Date:
                    return "DATETIME";
                default:
                    throw new NotImplementedException($"Type of column {column} not found");
            }
        }
    }
}
