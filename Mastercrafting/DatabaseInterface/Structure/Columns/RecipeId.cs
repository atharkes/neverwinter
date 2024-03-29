﻿namespace DatabaseInterface.Structure.Columns {
    class RecipeId : Column<long> {
        public override string Name => "recipe_id";

        public RecipeId(params Constraint[] constraints) : base(constraints) { }
    }
}
