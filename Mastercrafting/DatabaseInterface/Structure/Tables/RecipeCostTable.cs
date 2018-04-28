using System.Collections.Generic;

namespace DatabaseInterface.Structure.Tables {
    class RecipeCostTable : Table {
        public Column RecipeID { get; }
        public Column ResourceID { get; }
        public Column Amount { get; }

        public RecipeCostTable() : base("RecipeCosts", " PRIMARY KEY (recipe_id, resource_id)") {
            RecipeID = new Column(Column.Columns.recipe_id, "NOT NULL REFERENCES Recipes (recipe_id) ON DELETE RESTRICT ON UPDATE CASCADE");
            ResourceID = new Column(Column.Columns.resource_id, "NOT NULL REFERENCES Resources (resource_id) ON DELETE RESTRICT ON UPDATE CASCADE");
            Amount = new Column(Column.Columns.amount, "NOT NULL DEFAULT (1)");
        }

        public override void Create() => Create(new List<Column>() { RecipeID, ResourceID, Amount });
    }
}
