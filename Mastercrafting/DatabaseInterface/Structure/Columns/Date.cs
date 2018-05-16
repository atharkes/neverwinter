using System;

namespace DatabaseInterface.Structure.Columns {
    class Date : Column<DateTime> {
        public override string Name => "date";

        public Date(string constraints = "") : base(constraints) { }
    }
}
