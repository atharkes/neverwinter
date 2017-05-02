using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace MastercraftWFA {
    static class Database {
        static SQLiteConnection dbConnection;

        public static void StartDatabase(string source) {
            if (!File.Exists(source)) {
                CreateDatabase(source);
                OpenDatabase(source);
                AddTables();
            } else {
                OpenDatabase(source);
            }
        }

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

        public static void AddTable(string name, string columns) {
            string sql = "CREATE TABLE " + name + " " + columns;
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        public static void AddRow(string table, string values, string columns = null) {
            switch (table) {
                case "professions":
                    columns = "(name, tool)";
                    break;
                case "recipes":
                    columns = "(name, profession)";
                    break;
                case "resources":
                    columns = "(name, price, updated)";
                    break;
                case "priceHistory":
                    columns = "(resource, price, date)";
                    break;
                case "consumedResources":
                    columns = "(recipe, resource, amount)";
                    break;
                case "results":
                    columns = "(recipe, tier, resource, amount)";
                    break;
                case "getTool":
                    columns = "(profession, resource, amount)";
                    break;
                default:
                    throw new NotImplementedException();
            }
            string sql = "INSERT OR REPLACE INTO " + table + " " + columns + " values " + values;
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

        static void CreateDatabase(string source) {
            SQLiteConnection.CreateFile(source);
        }

        static void OpenDatabase(string source) {
            dbConnection = new SQLiteConnection("Data Source=" + source + ";Version=3;");
            dbConnection.Open();
        }

        static public void CloseDatabase() {
            dbConnection.Close();
        }
    }
}