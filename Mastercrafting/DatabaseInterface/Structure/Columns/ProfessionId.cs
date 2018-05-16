namespace DatabaseInterface.Structure.Columns {
    class ProfessionId : Column<long> {
        public override string Name => "profession_id";

        public ProfessionId(params Constraint[] constraints) : base(constraints) { }
    }
}
