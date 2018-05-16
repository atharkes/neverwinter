using System;

namespace DatabaseInterface.Structure.Constraints {
    /// <summary> A constraint that enforces a default value </summary>
    /// <typeparam name="T">The type of the default value</typeparam>
    class Default<T> : Constraint {
        /// <summary> The default value </summary>
        public T Value { get; }

        /// <summary> Create a new default value constraint object </summary>
        /// <param name="value">The default value</param>
        /// <param name="name">The name of the constraint</param>
        public Default(T value, string name = "") : base(name) {
            Value = value;
        }

        /// <summary> Get the sqlite string of this constraint </summary>
        /// <returns>The sqlite string corresponding to this constraint</returns>
        public override string GetString() {
            return $"DEFAULT {GetValueString()}";
        }

        /// <summary> Get the sqlite string of the value </summary>
        /// <returns>The sqlite string of the value</returns>
        string GetValueString() {
            switch (typeof(T).Name) {
                case nameof(Int64):
                case nameof(Int32):
                    return $"({Value})";
                case nameof(String):
                    return Value.ToString();
                default:
                    throw new NotImplementedException($"Default value string of type {typeof(T).Name} not found");
            }
        }
    }
}
