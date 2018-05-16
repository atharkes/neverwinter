namespace DatabaseInterface.Structure.Columns {
    class ResourceName : Column<string> {
        public override string Name => "resource";

        public ResourceName(string constraints = "") : base(constraints) { }
    }
}
