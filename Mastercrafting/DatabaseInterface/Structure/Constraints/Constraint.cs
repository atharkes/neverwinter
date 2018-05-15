using System;

namespace DatabaseInterface.Structure.Constraints {
    /// <summary> abstract co </summary>
    abstract class Constraint {
        /// <summary> Types of constraints possible </summary>
        public enum Type {
            PrimaryKey,
            ForeignKey,
            Unique,
            Check,
            NotNull,
            Collate,
            Default
        }

        /// <summary> Get a string representing the constraint </summary>
        /// <param name="type">The type of the constraint</param>
        /// <returns>String of the constraint</returns>
        public static string GetString(Type type) {
            switch (type) {
                case Type.PrimaryKey:
                    return "PRIMARY KEY";
                case Type.ForeignKey:
                    return "FOREIGN KEY";
                case Type.Unique:
                    return "UNIQUE";
                case Type.Check:
                    return "";
                case Type.NotNull:
                    return "NOT NULL";
                case Type.Collate:
                    return "";
                case Type.Default:
                    return "DEFAULT";
                default:
                    throw new NotImplementedException($"Constraint {type} not found");
            }
        }
    }
}
