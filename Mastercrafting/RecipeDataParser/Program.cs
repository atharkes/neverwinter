using DatabaseInterface;

namespace RecipeDataParser {
    class Program {
        static void Main(string[] args) {
            Database.InitializeDatabase("test.sqlite");
            Database.CloseDatabase();
        }
    }
}
