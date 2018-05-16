namespace DatabaseInterface.Structure.Columns {
    class ResourceName : Column<string> {
        public override string Name => "resource";

        public ResourceName(params Constraint[] constraints) : base(constraints) { }
    }
}
