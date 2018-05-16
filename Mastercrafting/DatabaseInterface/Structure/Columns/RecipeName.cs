namespace DatabaseInterface.Structure.Columns {
    class RecipeName : Column<string> {
        public override string Name => "recipe";

        public RecipeName(string constraints = "") : base(constraints) { }
    }
}
