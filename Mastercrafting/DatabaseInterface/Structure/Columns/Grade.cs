namespace DatabaseInterface.Structure.Columns {
    class Grade : Column<int> {
        public override string Name => "grade";

        public Grade(string constraints = "") : base(constraints) { }
    }
}
