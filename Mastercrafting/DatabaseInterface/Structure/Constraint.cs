using System;

namespace DatabaseInterface.Structure {
    /// <summary> abstract co </summary>
    abstract class Constraint {
        /// <summary> The name of the constraint </summary>
        public string Name { get; }
        
        /// <summary> Create a new constraint with a name </summary>
        /// <param name="name">The name of the constraint</param>
        protected Constraint(string name = "") {
            Name = name;
        }

        /// <summary> Get the string corresponding to this constraint </summary>
        /// <returns>The string in sqlite format</returns>
        public abstract string GetString();

        [Flags]
        /// <summary> Types of constraints possible </summary>
        public enum Type {
            PrimaryKey = 1,
            ForeignKey = 2,
            Unique = 4,
            Check = 8,
            NotNull = 16,
            Collate = 32,
            Default = 64
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
