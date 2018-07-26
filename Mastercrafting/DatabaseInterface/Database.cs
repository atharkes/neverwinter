using System.Data;
using System.Data.SQLite;
using System.IO;

namespace DatabaseInterface {
    /// <summary> Database manages the communication to the sqlite database </summary>
    public static class Database {
        /// <summary> The sqlite connection to the database. Available after the initialization </summary>
        static SQLiteConnection connection { get; set; }

        /// <summary> Initializes the database. Either connecting to an existing one, or creating it new </summary>
        /// <param name="path">The location of the database (also expects name.sqlite)</param>
        public static void InitializeDatabase(string path) {
            TableManager.InitializeTableStructure();
            if (!File.Exists(path)) {
                CreateDatabase(path);
            }
            OpenDatabase(path);
            TableManager.AddTablesToDatabase();
            TableManager.LoadTableData();
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
    }
}