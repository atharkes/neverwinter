using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace MastercraftWFA {
    static class Database {
        static SQLiteConnection dbConnection;

        public enum Tables {
            professions,
            recipes,
            resources,
            priceHistory,
            consumedResources,
            results,
            upgrades
        };

        public static Dictionary<Tables, string> TableName = new Dictionary<Tables, string>() {
            { Tables.professions, "professions" },
            { Tables.recipes, "recipes" },
            { Tables.resources, "resources" },
            { Tables.priceHistory, "priceHistory" },
            { Tables.consumedResources, "consumedResources" },
            { Tables.results, "results" },
            { Tables.upgrades, "upgrades" }
        };

        public static Dictionary<Tables, string> TableColumns = new Dictionary<Tables, string>() {
            { Tables.professions, "(name, grade)" },
            { Tables.recipes, "(name, profession)" },
            { Tables.resources, "(name, price, updated)" },
            { Tables.priceHistory, "(resource, price, date)" },
            { Tables.consumedResources, "(recipe, resource, amount)" },
            { Tables.results, "(recipe, tier, resource, amount)" },
            { Tables.upgrades, "(profession, grade, resource, amount)" }
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
            AddTable("professions", "(name STRING, grade INT, " +
                "PRIMARY KEY (name))");
            AddTable("recipes", "(name STRING, profession STRING, " +
                "FOREIGN KEY (profession) REFERENCES professions (name), " +
                "PRIMARY KEY (name))");
            AddTable("resources", "(name STRING, price INT, updated DATETIME, " +
                "PRIMARY KEY (name))");
            AddTable("priceHistory", "(resource STRING, price INT, date DATETIME, " +
                "FOREIGN KEY (resource) REFERENCES resources (name), " +
                "PRIMARY KEY (resource, date))");
            AddTable("consumedResources", "(recipe STRING, resource STRING, amount INT, " +
                "FOREIGN KEY (recipe) REFERENCES recipes (name), " +
                "FOREIGN KEY (resource) REFERENCES resources (name), " +
                "PRIMARY KEY (recipe, resource))");
            AddTable("results", "(recipe STRING, tier INT, resource STRING, amount INT, " +
                "FOREIGN KEY (recipe) REFERENCES recipes (name), " +
                "FOREIGN KEY (resource) REFERENCES resources (name), " +
                "PRIMARY KEY (recipe, tier, resource))");
            AddTable("upgrades", "(profession STRING, grade INT, resource STRING, amount INT, " +
                "FOREIGN KEY (profession) REFERENCES professions (name), " +
                "FOREIGN KEY (resource) REFERENCES resources (name), " +
                "PRIMARY KEY (profession, grade, resource))");
        }

        static void AddData() {
            InsertProfession("Artificing", 2);
            InsertProfession("Leatherworking", 2);
            InsertProfession("Weaponsmithing", 3);
            InsertProfession("Tailoring", 2);
            InsertProfession("Platesmithing", 2);
            InsertProfession("Mailsmithing", 2);
            InsertProfession("Jewelcrafting", 2);
            InsertProfession("Alchemy", 2);
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

        public static DataTable GetAllResources() {
            return Query(
                "SELECT name, price, date(updated) AS updated " +
                "FROM resources"
            );
        }

        public static DataTable GetResources(List<string> recipes) {
            return new DataTable();
        }

        public static DataTable GetRecipesWithCost(string profession) {
            return Query(
                "SELECT recipe, SUM(price * amount) AS cost " +
                "FROM (" +
                    "SELECT recipe, resource, price, amount " +
                    "FROM recipes " +
                    "INNER JOIN consumedResources " +
                    "ON recipes.name = consumedResources.recipe " +
                    "INNER JOIN resources " +
                    "ON consumedResources.resource = resources.name " +
                    "WHERE profession = '" + profession + "'" +
                ") GROUP BY recipe"
            );
        }

        public static DataTable GetRecipesWithCost(List<string> professions) {
            return new DataTable();
        }

        public static DataTable GetRecipeConsumedResources(string recipe) {
            return Query(
                "SELECT resource " +
                "FROM consumedResources " +
                "WHERE recipes = '" + recipe + "'"
            );
        }

        public static DataTable GetRecipeConsumedResources(List<string> recipes) {
            return new DataTable();
        }

        public static DataTable GetRecipeResults(string recipe) {
            return Query(
                "SELECT resource " +
                "FROM results " +
                "WHERE recipes = '" + recipe + "'"
            );
        }

        public static DataTable GetRecipeResults(List<string> recipes) {
            return new DataTable();
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