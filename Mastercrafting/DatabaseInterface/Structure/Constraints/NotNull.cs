namespace DatabaseInterface.Structure.Constraints {
    /// <summary> A constraint that enforces a column to not be null </summary>
    class NotNull : Constraint {
        /// <summary> Create a new not null constraint object </summary>
        /// <param name="name">The name of the constraint</param>
        public NotNull(string name = "") : base(name) { }

        /// <summary> Get the sqlite string of this constraint </summary>
        /// <returns>The sqlite string corresponding to this constraint</returns>
        public override string GetString() {
            return "NOT NULL";
        }
    }
}
