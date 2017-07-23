using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace MastercraftWFA {
    static class Database {
        static SQLiteConnection dbConnection;

        public enum Tables {
            Professions,
            Recipes,
            Resources,
            PriceHistory,
            RecipeCosts,
            RecipeResults,
            Upgrades
        };

        public static Dictionary<Tables, string> TableName = new Dictionary<Tables, string>() {
            { Tables.Professions, "Professions" },
            { Tables.Recipes, "Recipes" },
            { Tables.Resources, "Resources" },
            { Tables.PriceHistory, "PriceHistory" },
            { Tables.RecipeCosts, "RecipeCosts" },
            { Tables.RecipeResults, "RecipeResults" },
            { Tables.Upgrades, "Upgrades" }
        };

        public static Dictionary<Tables, string> TableColumns = new Dictionary<Tables, string>() {
            { Tables.Professions, "(profession_id, profession, grade)" },
            { Tables.Recipes, "(recipe_id, recipe, profession_id)" },
            { Tables.Resources, "(resource_id, resource, price, updated)" },
            { Tables.PriceHistory, "(resource_id, price, date)" },
            { Tables.RecipeCosts, "(recipe_id, resource_id, amount)" },
            { Tables.RecipeResults, "(recipe_id, tier, resource_id, amount)" },
            { Tables.Upgrades, "(profession_id, grade, resource_id, amount)" }
        };


        public static void StartDatabase(string source) {
            if (!File.Exists(source)) {
                CreateDatabase(source);
                OpenDatabase(source);
                AddTables();
                AddData();
            } else {
                OpenDatabase(source);
            }
        }


        #region Basic Methods
        static void CreateDatabase(string source) {
            SQLiteConnection.CreateFile(source);
        }

        static void OpenDatabase(string source) {
            dbConnection = new SQLiteConnection("Data Source=" + source + ";Version=3;");
            dbConnection.Open();
        }

        public static void CloseDatabase() {
            dbConnection.Close();
        }

        public static void AddTable(string name, string columns) {
            string sql = "CREATE TABLE " + name + " " + columns;
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        public static void AddRow(Tables table, string values, string columns = null) {
            if (columns == null)
                columns = TableColumns[table];
            string tableName = TableName[table];
            string sql = "INSERT OR REPLACE INTO " + tableName + " " + columns + " values " + values;
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        public static DataTable Query(string query) {
            SQLiteCommand command = new SQLiteCommand(query, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            return table;
        }
        #endregion


        #region Populate Methods
        static void AddTables() {
            AddTable("Professions", "(profession_id INTEGER, profession STRING, grade INT, " +
                "PRIMARY KEY (profession_id))");
            AddTable("Recipes", "(recipe_id INTEGER, recipe STRING, profession_id INTEGER, " +
                "FOREIGN KEY (profession_id) REFERENCES Professions (profession_id), " +
                "PRIMARY KEY (recipe_id))");
            AddTable("Resources", "(resource_id INTEGER, resource STRING, price INT, updated DATETIME, " +
                "PRIMARY KEY (resource_id))");
            AddTable("PriceHistory", "(resource_id INTEGER, price INT, date DATETIME, " +
                "FOREIGN KEY (resource_id) REFERENCES Resources (resource_id), " +
                "PRIMARY KEY (resource_id, date))");
            AddTable("RecipeCosts", "(recipe_id INTEGER, resource_id INTEGER, amount INT, " +
                "FOREIGN KEY (recipe_id) REFERENCES Recipes (recipe_id), " +
                "FOREIGN KEY (resource_id) REFERENCES Resources (resource_id), " +
                "PRIMARY KEY (recipe_id, resource_id))");
            AddTable("RecipeResults", "(recipe_id INTEGER, tier INT, resource_id INTEGER, amount INT, " +
                "FOREIGN KEY (recipe_id) REFERENCES Recipes (recipe_id), " +
                "FOREIGN KEY (resource_id) REFERENCES Resources (resource_id), " +
                "PRIMARY KEY (recipe_id, tier, resource_id))");
            AddTable("Upgrades", "(profession_id INTEGER, grade INT, resource_id INTEGER, amount INT, " +
                "FOREIGN KEY (profession_id) REFERENCES Professions (profession_id), " +
                "FOREIGN KEY (resource_id) REFERENCES Resources (resource_id), " +
                "PRIMARY KEY (profession_id, grade, resource_id))");
        }

        static void AddData() {
            InsertProfession("Artificing", 3);
            InsertProfession("Leatherworking", 3);
            InsertProfession("Weaponsmithing", 2);
            InsertProfession("Tailoring", 2);
            InsertProfession("Platesmithing", 2);
            InsertProfession("Mailsmithing", 2);
            InsertProfession("Jewelcrafting", 2);
            InsertProfession("Alchemy", 3);
            InsertResource("Lacquer Branch", 9000);
            InsertResource("Charcoal", 10);
            InsertResource("Dark Lacquer", 45000);
            InsertResource("Ebony Wood", 25);
            InsertResource("Lacquered Ebony", 150000);
            InsertRecipeName("Extract Dark Lacquer", "Artificing");
            InsertRecipeName("Lacquer Ebony", "Artificing");
            InsertRecipeConsumedResource("Extract Dark Lacquer", "Lacquer Branch", 4);
            InsertRecipeConsumedResource("Extract Dark Lacquer", "Charcoal", 2);
            InsertRecipeConsumedResource("Lacquer Ebony", "Dark Lacquer", 4);
            InsertRecipeConsumedResource("Lacquer Ebony", "Ebony Wood", 2);
            InsertRecipeResult("Extract Dark Lacquer", 1, "Charcoal", 1);
            InsertRecipeResult("Extract Dark Lacquer", 2, "Lacquer Branch", 2);
            InsertRecipeResult("Extract Dark Lacquer", 3, "Dark Lacquer", 1);
            InsertRecipeResult("Lacquer Ebony", 1, "Ebony Wood", 1);
            InsertRecipeResult("Lacquer Ebony", 2, "Ebony Wood", 1);
            InsertRecipeResult("Lacquer Ebony", 2, "Dark Lacquer", 1);
            InsertRecipeResult("Lacquer Ebony", 3, "Lacquered Ebony", 1);
        }
        #endregion


        #region Queries
        public static bool HasTool(string profession) {
            DataTable result = Query("SELECT grade FROM professions WHERE name = '" + profession + "'");
            if (result.Rows[0].Field<int>("grade") >= 2)
                return true;
            return false;
        }

        public static DataTable GetProfessions() {
            return Query("SELECT * FROM professions");
        }

        public static DataTable GetResources() {
            return Query(
                "SELECT name, price, date(updated) AS updated " +
                "FROM resources"
            );
        }

        public static DataTable GetResources(string recipe) {
            return Query(
                "SELECT name, price, date(updated) AS updated " +
                "FROM resources " +
                "INNER JOIN (" +
                    "SELECT resource " +
                    "FROM consumedResources " +
                    "WHERE recipe = '" + recipe + "'" +
                    "UNION " +
                    "SELECT resource " +
                    "FROM results " +
                    "WHERE recipe = '" + recipe + "'" +
                ") ON resources.name = resource"
            );
        }

        public static DataTable GetResources(List<string> recipes) {
            string recipesConstraint = "recipe = '" + recipes[0] + "'";
            foreach (string recipe in recipes.Skip(1))
                recipesConstraint += " OR recipe = '" + recipe + "'";
            return Query(
                "SELECT name, price, date(updated) AS updated " +
                "FROM resources " +
                "INNER JOIN (" +
                    "SELECT resource " +
                    "FROM consumedResources " +
                    "WHERE " + recipesConstraint +
                    "UNION " +
                    "SELECT resource " +
                    "FROM results " +
                    "WHERE " + recipesConstraint +
                ") ON resources.name = resource"
            );
        }

        public static DataTable GetRecipesConsumedResources(string recipe) {
            return Query(
                "SELECT resource, amount " +
                "FROM consumedResources " +
                "WHERE recipe = '" + recipe + "'"
            );
        }

        public static DataTable GetRecipesConsumedResources(List<string> recipes) {
            return new DataTable();
        }

        public static DataTable GetRecipesResults(string recipe) {
            return Query(
                "SELECT tier, resource, amount " +
                "FROM results " +
                "WHERE recipe = '" + recipe + "'"
            );
        }

        public static DataTable GetRecipesResults(List<string> recipes) {
            return new DataTable();
        }

        public static DataTable GetRecipesCost(string profession) {
            return Query(
                "SELECT recipe, SUM(price * amount) AS cost " +
                "FROM (" +
                    "SELECT recipe, resource, price, amount " +
                    "FROM recipes " +
                    "INNER JOIN consumedResources " +
                    "ON recipes.name = consumedResources.recipe " +
                    "INNER JOIN resources " +
                    "ON consumedResources.resource = resources.name " +
                    "WHERE recipes.profession = '" + profession + "'" +
                ") GROUP BY recipe"
            );
        }

        public static DataTable GetRecipesCost(List<string> professions) {
            string professionConstraint = "profession = '" + professions[0] + "'";
            foreach (string profession in professions.Skip(1))
                professionConstraint += " OR profession = '" + profession + "'";
            return Query(
                "SELECT recipe, SUM(price * amount) AS cost " +
                "FROM (" +
                    "SELECT recipe, resource, price, amount " +
                    "FROM recipes " +
                    "INNER JOIN consumedResources " +
                    "ON recipes.name = consumedResources.recipe " +
                    "INNER JOIN resources " +
                    "ON consumedResources.resource = resources.name " +
                    "WHERE " + professionConstraint +
                ") GROUP BY recipe"
            );
        }

        public static DataTable GetRecipesReward(string profession, int tier) {
            return Query(
                "SELECT recipe, SUM(price * amount) AS tier" + tier + "reward " +
                "FROM (" +
                    "SELECT recipe, resource, price, amount " +
                    "FROM recipes " +
                    "INNER JOIN results " +
                    "ON recipes.name = results.recipe " +
                    "INNER JOIN resources " +
                    "ON results.resource = resources.name " +
                    "WHERE recipes.profession = '" + profession + "' AND tier = " + tier +
                ") GROUP BY recipe"
            );
        }
        #endregion


        #region Insert Methods
        public static void InsertProfession(string profession, int grade = 0) {
            string values = "('" + profession + "', " + grade + ")";
            AddRow(Tables.professions, values);
        }

        public static void InsertResource(string resource, int cost) {
            // ToDo: Add old row to PriceHistory
            string values = "('" + resource + "', " + cost + ", '" + DateTimeSQLite(DateTime.Now) + "')";
            AddRow(Tables.resources, values);
        }

        public static void InsertRecipe(string name, string profession, List<Tuple<string, int>> consumedResources = null, List<Tuple<int, string, int>> results = null) {
            InsertRecipeName(name, profession);
            foreach (Tuple<string, int> consumedResource in consumedResources) {
                InsertRecipeConsumedResource(name, consumedResource.Item1, consumedResource.Item2);
            }
            foreach (Tuple<int, string, int> result in results) {
                InsertRecipeResult(name, result.Item1, result.Item2, result.Item3);
            }
        }

        public static void InsertRecipeName(string name, string profession) {
            string values = "('" + name + "', '" + profession + "')";
            AddRow(Tables.recipes, values);
        }

        public static void InsertRecipeConsumedResource(string recipe, string resource, int amount) {
            string values = "('" + recipe + "', '" + resource + "', " + amount + ")";
            AddRow(Tables.consumedResources, values);
        }

        public static void InsertRecipeResult(string recipe, int tier, string resource, int amount) {
            string values = "('" + recipe + "', '" + resource + "', " + amount + ", " + tier + ")";
            AddRow(Tables.results, values);
        }

        public static void InsertUpgradeRequirement(string profession, int grade, string resource, int amount) {
            string values = "('" + profession + "', " + grade + ", '" + resource + "', " + amount + ")";
            AddRow(Tables.upgrades, values);
        }
        #endregion


        #region Utils
        public static string DateTimeSQLite(DateTime datetime) {
            string dateTimeFormat = "{0}-{1}-{2} {3}:{4}:{5}.{6}";
            return string.Format(dateTimeFormat,
            datetime.Year.ToString().PadLeft(4, '0'),
            datetime.Month.ToString().PadLeft(2, '0'),
            datetime.Day.ToString().PadLeft(2, '0'),
            datetime.Hour.ToString().PadLeft(2, '0'),
            datetime.Minute.ToString().PadLeft(2, '0'),
            datetime.Second.ToString().PadLeft(2, '0'),
            datetime.Millisecond.ToString().PadLeft(4, '0'));
        }
        #endregion

    }
}