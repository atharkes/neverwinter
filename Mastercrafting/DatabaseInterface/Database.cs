using DatabaseInterface.Structure;
using DatabaseInterface.Structure.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace DatabaseInterface {
    public static class Database {
        /// <summary> The sqlite connection to the database. Available after the initialization </summary>
        static SQLiteConnection connection { get; set; }
        /// <summary> The tables in the database </summary>
        static List<Table> tables => new List<Table>() { ProfessionTable, RecipeTable, ResourceTable, RecipeCostTable, RecipeResultTable, ResourcePriceTable, UpgradeTable };

        internal static ProfessionTable ProfessionTable;
        internal static RecipeTable RecipeTable;
        internal static ResourceTable ResourceTable;

        internal static RecipeCostTable RecipeCostTable;
        internal static RecipeResultTable RecipeResultTable;
        internal static PriceHistoryTable ResourcePriceTable;
        internal static UpgradeTable UpgradeTable;

        /// <summary> Initializes the database. Either connecting to an existing one, or creating it new </summary>
        /// <param name="path">The location of the database (also expects name.sqlite)</param>
        public static void InitializeDatabase(string path) {
            if (connection != null) {
                throw new Exception("There is already a connection to a database");
            }

            if (!File.Exists(path)) {
                CreateDatabase(path);
                OpenDatabase(path);
                foreach (Table table in tables) {
                    table.Create();
                }
            } else {
                OpenDatabase(path);
            }
        }

        /// <summary> Close the connection to the database </summary>
        public static void CloseDatabase() {
            connection?.Close();
        }

        /// <summary> Create an empty database </summary>
        /// <param name="name">The filename of the database</param>
        static void CreateDatabase(string name) {
            SQLiteConnection.CreateFile(name);
        }

        /// <summary> Open an existing database </summary>
        /// <param name="source">The path to the database</param>
        static void OpenDatabase(string source) {
            connection = new SQLiteConnection($"Data Source={source};Version=3;");
            connection.Open();
        }

        /// <summary> Execute a command that is not a query </summary>
        /// <param name="command">The command to execute</param>
        /// <returns>The number of rows affected by the command</returns>
        internal static int NonQuery(string command) {
            SQLiteCommand sqlCommand = new SQLiteCommand(command, connection);
            return sqlCommand.ExecuteNonQuery();
        }

        /// <summary> Query the database </summary>
        /// <param name="command">The command to query with</param>
        /// <returns>The data returned by the query</returns>
        internal static DataTable Query(string command) {
            SQLiteCommand sqlCommand = new SQLiteCommand(command, connection);
            SQLiteDataReader reader = sqlCommand.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            return table;
        }

        /// <summary> Create a sqlite string from a datetime </summary>
        /// <param name="dateTime">The datetime to create the string from</param>
        /// <returns>The created string</returns>
        public static string DateTimeSQLite(DateTime dateTime) {
            const string dateTimeFormat = "{0}-{1}-{2} {3}:{4}:{5}.{6}";
            return string.Format(dateTimeFormat,
            dateTime.Year.ToString().PadLeft(4, '0'),
            dateTime.Month.ToString().PadLeft(2, '0'),
            dateTime.Day.ToString().PadLeft(2, '0'),
            dateTime.Hour.ToString().PadLeft(2, '0'),
            dateTime.Minute.ToString().PadLeft(2, '0'),
            dateTime.Second.ToString().PadLeft(2, '0'),
            dateTime.Millisecond.ToString().PadLeft(4, '0'));
        }
    }
}