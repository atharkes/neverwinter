using System;

namespace DatabaseInterface.Structure {
    /// <summary> A column managing the type, name, and constraints </summary>
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
            ProfessionId,
            Profession,
            RecipeId,
            Recipe,
            ResourceId,
            Resource,
            Amount,
            Price,
            Date,
            Grade,
            Tier
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
                case Columns.Profession:
                    return "profession";
                case Columns.Recipe:
                    return "recipe";
                case Columns.Resource:
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
                    throw new NotImplementedException("Column Name not found");
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
                case Columns.Profession:
                case Columns.Recipe:
                case Columns.Resource:
                    return "STRING";
                case Columns.Amount:
                case Columns.Price:
                case Columns.Grade:
                case Columns.Tier:
                    return "INT";
                case Columns.Date:
                    return "DATETIME";
                default:
                    throw new NotImplementedException("Column Type not found");
            }
        }
    }
}
