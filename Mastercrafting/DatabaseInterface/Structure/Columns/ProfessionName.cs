namespace DatabaseInterface.Structure.Columns {
    class ProfessionName : Column<string> {
        public override string Name => "profession";

        public ProfessionName(params Constraint[] constraints) : base(constraints) { }
    }
}
