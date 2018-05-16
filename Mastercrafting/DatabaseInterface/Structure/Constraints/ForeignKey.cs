using System;

namespace DatabaseInterface.Structure.Constraints {
    /// <summary> A constraint that enforces a reference to a foreign column </summary>
    class ForeignKey : Constraint {
        /// <summary> The table of the foreign key </summary>
        public Table ForeignTable { get; }
        /// <summary> The column of the foreign key </summary>
        public IColumn ForeignColumn { get; }
        /// <summary> What to do when the foreign key is updated </summary>
        public Reaction OnUpdate { get; }
        /// <summary> What to do when the foreign key is deleted </summary>
        public Reaction OnDelete { get; }

        /// <summary> Create a new foreign key constraint object </summary>
        /// <param name="foreignTable">The table of the foreign key</param>
        /// <param name="foreignColumn">The column of the foreign key</param>
        /// <param name="onUpdate">What to do when the foreign key is updated</param>
        /// <param name="onDelete">What to do when the foreign key is deleted</param>
        /// <param name="name">The name of the constraint</param>
        public ForeignKey(Table foreignTable, IColumn foreignColumn, Reaction onUpdate = Reaction.Cascade, Reaction onDelete = Reaction.Restrict, string name = "") : base(name) {
            ForeignTable = foreignTable;
            ForeignColumn = foreignColumn;
            OnUpdate = onUpdate;
            OnDelete = onDelete;
        }

        /// <summary> Get the sqlite string of this constraint </summary>
        /// <returns>The sqlite string corresponding to this constraint</returns>
        public override string GetString() {
            return $"REFERENCES {ForeignTable.Name} ({ForeignColumn.Name}) ON DELETE {GetReactionString(OnDelete)} ON UPDATE {GetReactionString(OnUpdate)}";
        }

        /// <summary> The different type of reactions </summary>
        public enum Reaction {
            NoAction,
            SetNull,
            SetDefault,
            Cascade,
            Restrict
        }

        /// <summary> Get the sqlite strings for the reactions </summary>
        /// <param name="reaction">The type of reaction</param>
        /// <returns>The sqlite string for the reaction</returns>
        static string GetReactionString(Reaction reaction) {
            switch (reaction) {
                case Reaction.NoAction:
                    return "NO ACTION";
                case Reaction.SetNull:
                    return "SET NULL";
                case Reaction.SetDefault:
                    return "SET DEFAULT";
                case Reaction.Cascade:
                    return "CASCADE";
                case Reaction.Restrict:
                    return "RESTRICT";
                default:
                    throw new NotImplementedException($"String of reaction {reaction} not found");
            }
        }
    }
}
