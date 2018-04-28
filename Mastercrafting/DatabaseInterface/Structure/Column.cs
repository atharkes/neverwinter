using System;

namespace DatabaseInterface.Structure {
    class Column {
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

        /// <summary> The columns in the database </summary>
        public enum Columns {
            profession_id,
            profession,
            recipe_id,
            recipe,
            resource_id,
            resource,
            grade,
            price,
            date,
            amount,
            tier
        }

        /// <summary> Gets the name for a column </summary>
        /// <param name="column">The column to get the name for</param>
        /// <returns>The name of the column</returns>
        public static string GetName(Columns column) {
            switch (column) {
                case Columns.profession_id:
                    return "profession_id";
                case Columns.recipe_id:
                    return "recipe_id";
                case Columns.resource_id:
                    return "resource_id";
                case Columns.profession:
                    return "profession";
                case Columns.recipe:
                    return "recipe";
                case Columns.resource:
                    return "resource";
                case Columns.amount:
                    return "amount";
                case Columns.grade:
                    return "grade";
                case Columns.price:
                    return "price";
                case Columns.tier:
                    return "tier";
                case Columns.date:
                    return "date";
                default:
                    throw new NotImplementedException("Column Name not found");
            }
        }

        /// <summary> Gets the type for a column </summary>
        /// <param name="column">The column to get the type for</param>
        /// <returns>The type of the column</returns>
        public static string GetType(Columns column) {
            switch (column) {
                case Columns.profession_id:
                case Columns.recipe_id:
                case Columns.resource_id:
                    return "INTEGER";
                case Columns.profession:
                case Columns.recipe:
                case Columns.resource:
                    return "STRING";
                case Columns.amount:
                case Columns.grade:
                case Columns.price:
                case Columns.tier:
                    return "INT";
                case Columns.date:
                    return "DATETIME";
                default:
                    throw new NotImplementedException("Column Type not found");
            }
        }
    }
}
