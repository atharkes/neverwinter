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
            getTool
        };

        public static Dictionary<Tables, string> TableName = new Dictionary<Tables, string>() {
            { Tables.professions, "professions" },
            { Tables.recipes, "recipes" },
            { Tables.resources, "resources" },
            { Tables.priceHistory, "priceHistory" },
            { Tables.consumedResources, "consumedResources" },
            { Tables.results, "results" },
            { Tables.getTool, "getTool" }
        };

        public static Dictionary<Tables, string> TableColumns = new Dictionary<Tables, string>() {
            { Tables.professions, "(name, tool)" },
            { Tables.recipes, "(name, profession)" },
            { Tables.resources, "(name, price, updated)" },
            { Tables.priceHistory, "(resource, price, date)" },
            { Tables.consumedResources, "(recipe, resource, amount)" },
            { Tables.results, "(recipe, tier, resource, amount)" },
            { Tables.getTool, "(profession, resource, amount)" }
        };


        public static void StartDatabase(string source) {
            if (!File.Exists(source)) {
                CreateDatabase(source);
                OpenDatabase(source);
                AddTables();
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
            AddTable("professions", "(name STRING, tool INT, " +
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
            AddTable("getTool", "(profession STRING, resource STRING, amount INT, " +
                "FOREIGN KEY (profession) REFERENCES professions (name), " +
                "FOREIGN KEY (resource) REFERENCES resources (name), " +
                "PRIMARY KEY (profession, resource))");
        }
        #endregion


        #region Queries
        public static bool HasTool(string profession) {
            DataTable result = Query("SELECT tool FROM professions WHERE name = '" + profession + "'");
            if (result.Rows[0].Field<int>("tool") == 1)
                return true;
            return false;
        }

        public static string GetResultsQuery(string profession, int tier) {
            return
                "SELECT recipe, SUM(price * amount) AS tier" + tier + " " +
                "FROM (" +
                    "SELECT recipe, resource, price, amount " +
                    "FROM recipes " +
                    "INNER JOIN results " +
                    "ON recipes.name = results.recipe " +
                    "INNER JOIN resources " +
                    "ON results.resource = resources.name " +
                    "WHERE profession = '" + profession + "' AND tier = " + tier +
                ") GROUP BY recipe";
        }
        #endregion


        #region Insert Methods
        public static void InsertProfession(string profession, int tool = 0) {
            string values = "('" + profession + "', " + tool + ")";
            AddRow(Tables.professions, values);
        }

        public static void InsertRecipe(string name, string profesion) {
            string values = "('" + name + "', '" + profesion + "')";
            AddRow(Tables.recipes, values);
        }

        public static void InsertResource(string resource, int cost) {
            // ToDo: Add old row to PriceHistory
            string values = "('" + resource + "', " + cost + ", '" + DateTimeSQLite(DateTime.Now) + "')";
            AddRow(Tables.resources, values);
        }

        public static void InsertConsumedResource(string recipe, string resource, int amount) {
            string values = "('" + recipe + "', '" + resource + "', " + amount + ")";
            AddRow(Tables.consumedResources, values);
        }

        public static void InsertResult(string recipe, string resource, int amount, int tier) {
            string values = "('" + recipe + "', '" + resource + "', " + amount + ", " + tier + ")";
            AddRow(Tables.results, values);
        }
        #endregion


        #region Extra Methods
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