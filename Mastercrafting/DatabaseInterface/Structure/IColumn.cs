namespace DatabaseInterface.Structure {
    /// <summary> Interface for column objects </summary>
    interface IColumn {
        /// <summary> The name of this column </summary>
        string Name { get; }
        /// <summary> The data type of this column </summary>
        string Type { get; }
        /// <summary> The constraints on this column </summary>
        string Constraints { get; }
        /// <summary> The string used for table creation </summary>
        string CreationString { get; }

        /// <summary> Converts a value from this column to a string </summary>
        /// <param name="value">The value in this column</param>
        /// <returns>The string created from the value</returns>
        string ToString(object value);
    }
}
