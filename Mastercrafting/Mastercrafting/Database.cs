using System;
using System.Data.SQLite;
using System.IO;

namespace Mastercrafting {
    class Database {
        static SQLiteConnection dbConnection;

        public Database(string source) {
            if (!File.Exists(source)) {
                CreateDatabase(source);
                OpenDatabase(source);
                AddTables();
            } else {
                OpenDatabase(source);
            }
        }

        void AddTables() {
            AddTable("professions", "(name STRING, tool INTEGER, " +
                "PRIMARY KEY (name))");
            AddTable("recipes", "(name STRING, profession STRING, " +
                "FOREIGN KEY (profession) REFERENCES professions (name), " +
                "PRIMARY KEY (name))");
            AddTable("resources", "(name STRING, price INTEGER, updated DATETIME, " +
                "PRIMARY KEY (name))");
            AddTable("priceHistory", "(resource STRING, price INTEGER, date DATETIME, " +
                "FOREIGN KEY (resource) REFERENCES resources (name), " +
                "PRIMARY KEY (resource, date))");
            AddTable("consumedResources", "(recipe STRING, resource STRING, amount INTEGER, " +
                "FOREIGN KEY (recipe) REFERENCES recipes (name), " +
                "FOREIGN KEY (resource) REFERENCES resources (name), " +
                "PRIMARY KEY (recipe, resource))");
            AddTable("results", "(recipe STRING, tier INTEGER, resource STRING, amount INTEGER, " +
                "FOREIGN KEY (recipe) REFERENCES recipes (name), " +
                "FOREIGN KEY (resource) REFERENCES resources (name), " +
                "PRIMARY KEY (recipe, tier, resource))");
        }

        public void AddTable(string name, string columns) {
            string sql = "CREATE TABLE " + name + " " + columns;
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        public void AddValue(string table, string values, string columns = null) {
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
                default:
                    throw new NotImplementedException();
            }
            string sql = "INSERT INTO " + table + " " + columns + " values " + values;
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        public void Query(string query) {
            SQLiteCommand command = new SQLiteCommand(query, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
        }

        void CreateDatabase(string source) {
            SQLiteConnection.CreateFile(source);
        }

        void OpenDatabase(string source) {
            dbConnection = new SQLiteConnection("Data Source=" + source + ";Version=3;");
            dbConnection.Open();
        }

        public void CloseDatabase() {
            dbConnection.Close();
        }
    }
}
