namespace DatabaseInterface.Structure.Columns {
    class Price : Column<int> {
        public override string Name => "price";

        public Price(params Constraint[] constraints) : base(constraints) { }
    }
}
