using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MastercraftWFA {
    class DatabaseInterface {

        public DataTable GetProfessionsTable() {
            return Database.GetProfessions();
        }

        public DataTable GetRecipesTable(string profession) {
            DataTable costTable = Database.GetRecipesCost(profession);
            DataTable tier1Table = Database.GetRecipesResult(profession, 1);
            DataTable tier2Table = Database.GetRecipesResult(profession, 2);
            DataTable tier3Table = Database.GetRecipesResult(profession, 3);
            costTable.Merge(tier1Table);
            costTable.Merge(tier2Table);
            costTable.Merge(tier3Table);
            costTable.Columns.Add("tier1profit", typeof(int), "tier1reward - cost");
            costTable.Columns.Add("tier2profit", typeof(int), "tier2reward - cost");
            costTable.Columns.Add("tier3profit", typeof(int), "tier3reward - cost");
            costTable.Columns.Add("profit", typeof(int));
            // Compute profit value
            for (int i = 0; i < costTable.Rows.Count; i++) {
                bool tool = Database.HasTool(profession);
                Int64 cost = costTable.Rows[i].Field<Int64>("cost");
                Int64 tier1Reward = costTable.Rows[i].Field<Int64>("tier1reward");
                Int64 tier2Reward = costTable.Rows[i].Field<Int64>("tier2reward");
                Int64 tier3Reward = costTable.Rows[i].Field<Int64>("tier3reward");
                Int64 tier3ChanceReward = (int)(tool ? 0.75 * tier3Reward + 0.25 * tier2Reward : 0.35 * tier3Reward + 0.65 * tier2Reward);
                Int64 profit = Math.Max(tier1Reward, tier2Reward);
                profit = Math.Max(profit, tier3ChanceReward);
                profit -= cost;
                costTable.Rows[i].SetField("profit", profit);
            }
            return costTable;
        }

        public DataTable GetRecipesTable(List<string> professions) {
            DataTable recipesTable = GetRecipesTable(professions[0]);
            foreach (string profession in professions.Skip(1)) {
                DataTable professionTable = GetRecipesTable(profession);
                if (professionTable.Rows.Count == 0)
                    continue;
                recipesTable = recipesTable.AsEnumerable().Union(professionTable.AsEnumerable()).CopyToDataTable();
            }
            return recipesTable;
        }

        public DataTable GetResourcesTable(string recipe) {
            return Database.GetResources(recipe);
        }

        public DataTable GetResourcesTable(List<string> recipes) {
            return Database.GetResources(recipes);
        }

        public DataTable GetResultsTable(string recipe) {
            return Database.GetRecipesResults(recipe);
        }

        public DataTable GetConsumedResourcesTable(string recipe) {
            return Database.GetRecipesCosts(recipe);
        }

        public List<object> GetResourceList() {
            DataTable resources = Database.Query("SELECT name FROM resources");
            return resources.AsEnumerable().Select(x => x["name"]).ToList();
        }

        public List<int> GetTiers() {
            return new List<int>() { 1, 2, 3 };
        }

        public List<int> GetGrades() {
            return new List<int>() { 0, 1, 2, 3 };
        }
    }
}
