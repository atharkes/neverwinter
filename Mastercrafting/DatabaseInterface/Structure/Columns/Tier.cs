namespace DatabaseInterface.Structure.Columns {
    class Tier : Column<int> {
        public override string Name => "tier";

        public Tier(string constraints = "") : base(constraints) { }
    }
}
