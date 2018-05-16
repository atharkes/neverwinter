namespace DatabaseInterface.Structure.Columns {
    class ProfessionName : Column<string> {
        public override string Name => "profession";

        public ProfessionName(string constraints = "") : base(constraints) { }
    }
}
