namespace DatabaseInterface.Structure.Columns {
    class ResourceId : Column<long> {
        public override string Name => "resource_id";

        public ResourceId(params Constraint[] constraints) : base(constraints) { }
    }
}
