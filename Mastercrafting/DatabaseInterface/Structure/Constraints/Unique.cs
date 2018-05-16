namespace DatabaseInterface.Structure.Constraints {
    /// <summary> A constraint that enforces unique values in a column </summary>
    class Unique : Constraint {
        /// <summary> Create a new unique value constraint object </summary>
        /// <param name="name">The name of the constraint</param>
        public Unique(string name = "") : base(name) { }

        /// <summary> Get the sqlite string of this constraint </summary>
        /// <returns>The sqlite string corresponding to this constraint</returns>
        public override string GetString() {
            return "UNIQUE";
        }
    }
}
