namespace DatabaseInterface.Structure.Columns {
    class Price : Column<int> {
        public override string Name => "price";

        public Price(string constraints = "") : base(constraints) { }
    }
}
