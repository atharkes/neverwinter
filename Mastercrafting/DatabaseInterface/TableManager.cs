using DatabaseInterface.Structure;
using DatabaseInterface.Structure.TableStructure;
using System.Collections.Generic;

namespace DatabaseInterface {
    enum Tables {
        Profession,
        Recipe,
        RecipeCost,
        RecipeResult,
        Resource,
        ResourcePrice,
        Upgrade
    }

    static class TableManager {
        /// <summary> The tables in the database </summary>
        internal readonly static Dictionary<Tables, Table> Table = new Dictionary<Tables, Table> {
            { Tables.Profession, new ProfessionTable() },
            { Tables.Recipe, new RecipeTable() },
            { Tables.RecipeCost, new RecipeCostTable() },
            { Tables.RecipeResult, new RecipeResultTable() },
            { Tables.Resource, new ResourceTable() },
            { Tables.ResourcePrice, new ResourcePriceTable() },
            { Tables.Upgrade, new UpgradeTable() }
        };

        internal static ProfessionTable Profession => Table[Tables.Profession] as ProfessionTable;
        internal static RecipeTable Recipe => Table[Tables.Recipe] as RecipeTable;
        internal static RecipeCostTable RecipeCost => Table[Tables.RecipeCost] as RecipeCostTable;
        internal static RecipeResultTable RecipeResult => Table[Tables.RecipeResult] as RecipeResultTable;
        internal static ResourceTable Resource => Table[Tables.Resource] as ResourceTable;
        internal static ResourcePriceTable ResourcePrice => Table[Tables.Resource] as ResourcePriceTable;
        internal static UpgradeTable Upgrade => Table[Tables.Upgrade] as UpgradeTable;
    }
}
