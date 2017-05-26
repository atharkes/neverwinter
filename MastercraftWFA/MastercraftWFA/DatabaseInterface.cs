using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MastercraftWFA {
    class DatabaseInterface {

        public DataTable GetProfessionsTable() {
            return Database.GetProfessions();
        }

        public DataTable GetRecipesTable(string profession) {
            DataTable costTable = Database.GetRecipesCost(profession);
            DataTable tier1Table = Database.GetRecipesReward(profession, 1);
            DataTable tier2Table = Database.GetRecipesReward(profession, 2);
            DataTable tier3Table = Database.GetRecipesReward(profession, 3);
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

        public DataTable GetResourcesTable(List<string> recipes) {
            return new DataTable();
        }

        public DataTable GetResultsTable(List<string> recipes) {
            return new DataTable();
        }

        public DataTable GetConsumedResourcesTable(List<string> recipes) {
            return new DataTable();
        }
    }
}
