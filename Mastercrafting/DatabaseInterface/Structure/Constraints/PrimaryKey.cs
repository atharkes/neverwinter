namespace DatabaseInterface.Structure.Constraints {
    /// <summary> A constraint that enforces a  primary key </summary>
    class PrimaryKey : Constraint {
        /// <summary> Whether to auto increment the primary key </summary>
        public bool AutoIncrement { get; }

        /// <summary> Create a new primary key constraint object </summary>
        /// <param name="autoIncrement">Whether to auto increment the primary key</param>
        /// <param name="name">The name of the constraint</param>
        public PrimaryKey(bool autoIncrement, string name = "") : base(name) {
            AutoIncrement = autoIncrement;
        }

        /// <summary> Get the sqlite string of this constraint </summary>
        /// <returns>The sqlite string corresponding to this constraint</returns>
        public override string GetString() {
            return "PRIMARY KEY" + (AutoIncrement ? " AUTOINCREMENT" : "");
        }
    }
}
