namespace DatabaseInterface.Structure.Columns {
    class Amount : Column<int> {
        public override string Name => "amount";

        public Amount(params Constraint[] constraints) : base(constraints) { }
    }
}
