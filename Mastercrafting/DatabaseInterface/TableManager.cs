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
        /// <summary> The tables in the database. The order of initialization matters </summary>
        internal readonly static Dictionary<Tables, Table> Table = new Dictionary<Tables, Table>();

        internal static void InitializeTableStructure() {
            Table.Add(Tables.Profession, new ProfessionTable());
            Table.Add(Tables.Recipe, new RecipeTable());
            Table.Add(Tables.Resource, new ResourceTable());
            Table.Add(Tables.RecipeCost, new RecipeCostTable());
            Table.Add(Tables.RecipeResult, new RecipeResultTable());
            Table.Add(Tables.ResourcePrice, new ResourcePriceTable());
            Table.Add(Tables.Upgrade, new UpgradeTable());
        }

        internal static ProfessionTable Profession => Table[Tables.Profession] as ProfessionTable;
        internal static RecipeTable Recipe => Table[Tables.Recipe] as RecipeTable;
        internal static RecipeCostTable RecipeCost => Table[Tables.RecipeCost] as RecipeCostTable;
        internal static RecipeResultTable RecipeResult => Table[Tables.RecipeResult] as RecipeResultTable;
        internal static ResourceTable Resource => Table[Tables.Resource] as ResourceTable;
        internal static ResourcePriceTable ResourcePrice => Table[Tables.Resource] as ResourcePriceTable;
        internal static UpgradeTable Upgrade => Table[Tables.Upgrade] as UpgradeTable;
    }
}
