namespace DatabaseInterface.Structure.Columns {
    class Tier : Column<int> {
        public override string Name => "tier";

        public Tier(params Constraint[] constraints) : base(constraints) { }
    }
}
