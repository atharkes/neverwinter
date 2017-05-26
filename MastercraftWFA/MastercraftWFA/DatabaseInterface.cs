using System.Collections.Generic;
using System.Data;

namespace MastercraftWFA {
    static class DatabaseInterface {

        static public DataTable GetProfessionsTable() {
            return new DataTable();
        }

        static public DataTable GetRecipesTable(List<string> professions) {
            return new DataTable();
        }

        static public DataTable GetResourcesTable(List<string> recipes) {
            return new DataTable();
        }

        static public DataTable GetResultsTable(List<string> recipes) {
            return new DataTable();
        }

        static public DataTable GetConsumedResourcesTable(List<string> recipes) {
            return new DataTable();
        }
    }
}
