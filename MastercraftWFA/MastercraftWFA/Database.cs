using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace MastercraftWFA {
    static class Database {
        static SQLiteConnection dbConnection;

        #region Tables and Columns
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

        public enum Columns {
            profession_id,
            profession,
            recipe_id,
            recipe,
            resource_id,
            resource,
            grade,
            price,
            date,
            amount,
            tier
        }

        public static Dictionary<Columns, string> ColumnName = new Dictionary<Columns, string>() {
            { Columns.profession_id, "profession_id" },
            { Columns.profession, "profession" },
            { Columns.recipe_id, "recipe_id" },
            { Columns.recipe, "recipe" },
            { Columns.resource_id, "resource_id" },
            { Columns.resource, "resource" },
            { Columns.grade, "grade" },
            { Columns.price, "price" },
            { Columns.date, "date" },
            { Columns.amount, "amount" },
            { Columns.tier, "tier" }
        };

        public static Dictionary<Tables, string> TableColumns = new Dictionary<Tables, string>() {
            { Tables.Professions, $"({ColumnName[Columns.profession_id]}, {ColumnName[Columns.profession]}, {ColumnName[Columns.grade]})" },
            { Tables.Recipes, $"({ColumnName[Columns.recipe_id]}, {ColumnName[Columns.recipe]}, {ColumnName[Columns.grade]}, {ColumnName[Columns.profession_id]})" },
            { Tables.Resources, $"({ColumnName[Columns.resource_id]}, {ColumnName[Columns.resource]}, {ColumnName[Columns.price]}, {ColumnName[Columns.date]})" },
            { Tables.PriceHistory, $"({ColumnName[Columns.resource_id]}, {ColumnName[Columns.price]}, {ColumnName[Columns.date]})" },
            { Tables.RecipeCosts, $"({ColumnName[Columns.recipe_id]}, {ColumnName[Columns.resource_id]}, {ColumnName[Columns.amount]})" },
            { Tables.RecipeResults, $"({ColumnName[Columns.recipe_id]}, {ColumnName[Columns.tier]}, {ColumnName[Columns.resource_id]}, {ColumnName[Columns.amount]})" },
            { Tables.Upgrades, $"({ColumnName[Columns.profession_id]}, {ColumnName[Columns.grade]}, {ColumnName[Columns.resource_id]}, {ColumnName[Columns.amount]})" }
        };
        #endregion

        public static void StartDatabase(string source) {
            if (!File.Exists(source)) {
                CreateDatabase(source);
                OpenDatabase(source);
                AddTables();
                InsertDummyData();
            } else {
                OpenDatabase(source);
            }
        }


        #region Basic Methods
        static void CreateDatabase(string source) {
            SQLiteConnection.CreateFile(source);
        }

        static void OpenDatabase(string source) {
            dbConnection = new SQLiteConnection($"Data Source={source};Version=3;");
            dbConnection.Open();
        }

        public static void CloseDatabase() {
            dbConnection.Close();
        }

        public static void AddTable(string name, string columns) {
            string sql = $"CREATE TABLE " + name + " " + columns;
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        public static void AddRow(Tables table, string values, string columns = null) {
            if (columns == null)
                columns = TableColumns[table];
            string tableName = TableName[table];
            string sql = $"INSERT OR REPLACE INTO {tableName} {columns} values {values}";
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
            AddTable(TableName[Tables.Professions], $"({ColumnName[Columns.profession_id]} INTEGER, {ColumnName[Columns.profession]} STRING, {ColumnName[Columns.grade]} INT, " +
                $"PRIMARY KEY ({ColumnName[Columns.profession_id]}))");
            AddTable(TableName[Tables.Recipes], $"({ColumnName[Columns.recipe_id]} INTEGER, {ColumnName[Columns.recipe]} STRING, {ColumnName[Columns.grade]} INT, {ColumnName[Columns.profession_id]} INTEGER, " +
                $"FOREIGN KEY ({ColumnName[Columns.profession_id]}) REFERENCES {TableName[Tables.Professions]} ({ColumnName[Columns.profession_id]}), " +
                $"PRIMARY KEY ({ColumnName[Columns.recipe_id]}))");
            AddTable(TableName[Tables.Resources], $"({ColumnName[Columns.resource_id]} INTEGER, {ColumnName[Columns.resource]} STRING, {ColumnName[Columns.price]} INT, {ColumnName[Columns.date]} DATETIME, " +
                $"PRIMARY KEY ({ColumnName[Columns.resource_id]}))");
            AddTable(TableName[Tables.PriceHistory], $"({ColumnName[Columns.resource_id]} INTEGER, {ColumnName[Columns.price]} INT, {ColumnName[Columns.date]} DATETIME, " +
                $"FOREIGN KEY ({ColumnName[Columns.resource_id]}) REFERENCES {TableName[Tables.Professions]} ({ColumnName[Columns.resource_id]}), " +
                $"PRIMARY KEY ({ColumnName[Columns.resource_id]}, {ColumnName[Columns.date]}))");
            AddTable(TableName[Tables.RecipeCosts], $"({ColumnName[Columns.recipe_id]} INTEGER, {ColumnName[Columns.resource_id]} INTEGER, {ColumnName[Columns.amount]} INT, " +
                $"FOREIGN KEY ({ColumnName[Columns.recipe_id]}) REFERENCES {TableName[Tables.Recipes]} ({ColumnName[Columns.recipe_id]}), " +
                $"FOREIGN KEY ({ColumnName[Columns.resource_id]}) REFERENCES {TableName[Tables.Resources]} ({ColumnName[Columns.resource_id]}), " +
                $"PRIMARY KEY ({ColumnName[Columns.recipe_id]}, {ColumnName[Columns.resource_id]}))");
            AddTable(TableName[Tables.RecipeResults], $"({ColumnName[Columns.recipe_id]} INTEGER, {ColumnName[Columns.tier]} INT, {ColumnName[Columns.resource_id]} INTEGER, {ColumnName[Columns.amount]} INT, " +
                $"FOREIGN KEY ({ColumnName[Columns.recipe_id]}) REFERENCES {TableName[Tables.Recipes]} ({ColumnName[Columns.recipe_id]}), " +
                $"FOREIGN KEY ({ColumnName[Columns.resource_id]}) REFERENCES {TableName[Tables.Resources]} ({ColumnName[Columns.resource_id]}), " +
                $"PRIMARY KEY ({ColumnName[Columns.recipe_id]}, tier, {ColumnName[Columns.resource_id]}))");
            AddTable(TableName[Tables.Upgrades], $"({ColumnName[Columns.profession_id]} INTEGER, {ColumnName[Columns.grade]} INT, {ColumnName[Columns.resource_id]} INTEGER, {ColumnName[Columns.amount]} INT, " +
                $"FOREIGN KEY ({ColumnName[Columns.profession_id]}) REFERENCES {TableName[Tables.Professions]} ({ColumnName[Columns.profession_id]}), " +
                $"FOREIGN KEY ({ColumnName[Columns.resource_id]}) REFERENCES {TableName[Tables.Resources]} ({ColumnName[Columns.resource_id]}), " +
                $"PRIMARY KEY ({ColumnName[Columns.profession_id]}, {ColumnName[Columns.grade]}, {ColumnName[Columns.resource_id]}))");
        }

        static void InsertDummyData() {
            InsertProfession("Artificing", 3);
            InsertProfession("Leatherworking", 3);
            InsertProfession("Weaponsmithing", 3);
            InsertProfession("Tailoring", 3);
            InsertProfession("Platesmithing", 3);
            InsertProfession("Mailsmithing", 3);
            InsertProfession("Jewelcrafting", 3);
            InsertProfession("Alchemy", 3);
            InsertResource("Lacquer Branch", 9000);
            InsertResource("Charcoal", 10);
            InsertResource("Dark Lacquer", 45000);
            InsertResource("Ebony Wood", 25);
            InsertResource("Lacquered Ebony", 150000);
            InsertRecipeName("Extract Dark Lacquer", "Artificing", 1);
            InsertRecipeName("Lacquer Ebony", "Artificing", 1);
            InsertRecipeCost("Extract Dark Lacquer", "Lacquer Branch", 4);
            InsertRecipeCost("Extract Dark Lacquer", "Charcoal", 2);
            InsertRecipeCost("Lacquer Ebony", "Dark Lacquer", 4);
            InsertRecipeCost("Lacquer Ebony", "Ebony Wood", 2);
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
            DataTable result = Query($"SELECT {ColumnName[Columns.grade]} FROM {TableName[Tables.Professions]} WHERE {ColumnName[Columns.profession]} = '{profession}'");
            if (result.Rows[0].Field<int>("grade") >= 2)
                return true;
            return false;
        }

        public static long GetProfessionID(string profession) {
            DataTable result = Query($"SELECT {ColumnName[Columns.profession_id]} FROM {TableName[Tables.Professions]} WHERE {ColumnName[Columns.profession]} = '{profession}'");
            return result.Rows[0].Field<Int64>("profession_id");
        }

        public static long GetRecipeID(string recipe) {
            DataTable result = Query($"SELECT {ColumnName[Columns.recipe_id]} FROM {TableName[Tables.Recipes]} WHERE {ColumnName[Columns.recipe]} = '{recipe}'");
            return result.Rows[0].Field<Int64>("recipe_id");
        }

        public static long GetResourceID(string resource) {
            DataTable result = Query($"SELECT {ColumnName[Columns.resource_id]} FROM {TableName[Tables.Resources]} WHERE {ColumnName[Columns.resource]} = '{resource}'");
            return result.Rows[0].Field<Int64>("resource_id");
        }

        public static DataTable GetProfessions() {
            return Query($"SELECT {ColumnName[Columns.profession]}, {ColumnName[Columns.grade]} FROM {TableName[Tables.Professions]}");
        }

        public static DataTable GetResources() {
            return Query($"SELECT {ColumnName[Columns.resource]}, {ColumnName[Columns.price]}, date({ColumnName[Columns.date]}) AS updated FROM {TableName[Tables.Resources]}");
        }

        public static DataTable GetRecipes() {
            return Query($"SELECT * FROM {TableName[Tables.Recipes]}");
        }

        public static DataTable GetResources(string recipe) {
            long recipe_id = GetRecipeID(recipe);
            return Query(
                $"SELECT {ColumnName[Columns.resource]}, {ColumnName[Columns.price]}, date({ColumnName[Columns.date]}) AS updated " +
                $"FROM {TableName[Tables.Resources]} " +
                $"INNER JOIN (" +
                    $"SELECT {ColumnName[Columns.resource_id]} " +
                    $"FROM {TableName[Tables.RecipeResults]} " +
                    $"WHERE {ColumnName[Columns.recipe_id]} = {recipe_id} " +
                    $"UNION " +
                    $"SELECT {ColumnName[Columns.resource_id]} " +
                    $"FROM {TableName[Tables.RecipeCosts]} " +
                    $"WHERE {ColumnName[Columns.recipe_id]} = {recipe_id}" +
                $") ON {TableName[Tables.Resources]}.{ColumnName[Columns.resource_id]} = {ColumnName[Columns.resource_id]}"
            );
        }

        public static DataTable GetResources(List<string> recipes) {
            long recipe_id = GetRecipeID(recipes[0]);
            string recipesConstraint = $"{ColumnName[Columns.recipe_id]} = {recipe_id}";
            foreach (string recipe in recipes.Skip(1)) {
                recipe_id = GetRecipeID(recipe);
                recipesConstraint += $" OR {ColumnName[Columns.recipe_id]} = {recipe_id}";
            }
            return Query(
                $"SELECT {ColumnName[Columns.resource]}, {ColumnName[Columns.price]}, date({ColumnName[Columns.date]}) AS updated " +
                $"FROM {TableName[Tables.Resources]} " +
                $"INNER JOIN (" +
                    $"SELECT {ColumnName[Columns.resource_id]} " +
                    $"FROM {TableName[Tables.RecipeResults]} " +
                    $"WHERE {recipesConstraint} " +
                    $"UNION " +
                    $"SELECT {ColumnName[Columns.resource_id]} " +
                    $"FROM {TableName[Tables.RecipeCosts]} " +
                    $"WHERE {recipesConstraint}" +
                $") Sub ON {TableName[Tables.Resources]}.{ColumnName[Columns.resource_id]} = Sub.{ColumnName[Columns.resource_id]}"
            );
        }

        public static DataTable GetRecipesCosts(string recipe) {
            long recipe_id = GetRecipeID(recipe);
            return Query(
                $"SELECT {ColumnName[Columns.resource]}, {ColumnName[Columns.amount]} " +
                $"FROM {TableName[Tables.RecipeResults]} " +
                $"INNER JOIN {TableName[Tables.Resources]} " +
                $"WHERE {ColumnName[Columns.recipe_id]} = {recipe_id}"
            );
        }

        public static DataTable GetRecipesCosts(List<string> recipes) {
            throw new NotImplementedException();
        }

        public static DataTable GetRecipesResults(string recipe) {
            long recipe_id = GetRecipeID(recipe);
            return Query(
                $"SELECT {ColumnName[Columns.tier]}, {ColumnName[Columns.resource]}, {ColumnName[Columns.amount]} " +
                $"FROM {TableName[Tables.RecipeResults]} " +
                $"INNER JOIN {TableName[Tables.Resources]} " +
                $"WHERE {ColumnName[Columns.recipe_id]} = {recipe_id}"
            );
        }

        public static DataTable GetRecipesResults(List<string> recipes) {
            throw new NotImplementedException();
        }

        public static DataTable GetRecipesCost(string profession) {
            long profession_id = GetProfessionID(profession);
            return Query(
                $"SELECT {ColumnName[Columns.recipe]}, SUM({ColumnName[Columns.price]} * {ColumnName[Columns.amount]}) AS cost " +
                $"FROM (" +
                    $"SELECT {ColumnName[Columns.recipe]}, {ColumnName[Columns.resource]}, {ColumnName[Columns.price]}, {ColumnName[Columns.amount]} " +
                    $"FROM {TableName[Tables.Recipes]} " +
                    $"INNER JOIN {TableName[Tables.RecipeCosts]} " +
                    $"ON {TableName[Tables.Recipes]}.{ColumnName[Columns.recipe_id]} = {TableName[Tables.RecipeCosts]}.{ColumnName[Columns.recipe_id]} " +
                    $"INNER JOIN {TableName[Tables.Resources]} " +
                    $"ON {TableName[Tables.RecipeCosts]}.{ColumnName[Columns.resource_id]} = {TableName[Tables.Resources]}.{ColumnName[Columns.resource_id]} " +
                    $"WHERE {TableName[Tables.Recipes]}.{ColumnName[Columns.profession_id]} = {profession_id}" +
                $") GROUP BY {ColumnName[Columns.recipe]}"
            );
        }

        public static DataTable GetRecipesCost(List<string> professions) {
            long profession_id = GetProfessionID(professions[0]);
            string professionConstraint = $"{ColumnName[Columns.profession_id]} = {profession_id}";
            foreach (string profession in professions.Skip(1))
                profession_id = GetProfessionID(profession);
                professionConstraint += $" OR {ColumnName[Columns.profession_id]} = {profession_id}";
            return Query(
                $"SELECT {ColumnName[Columns.recipe]}, SUM({ColumnName[Columns.price]} * {ColumnName[Columns.amount]}) AS cost " +
                $"FROM (" +
                    $"SELECT {ColumnName[Columns.recipe]}, {ColumnName[Columns.resource]}, {ColumnName[Columns.price]}, {ColumnName[Columns.amount]} " +
                    $"FROM {TableName[Tables.Recipes]} " +
                    $"INNER JOIN {TableName[Tables.RecipeCosts]} " +
                    $"ON {TableName[Tables.Recipes]}.{ColumnName[Columns.recipe_id]} = {TableName[Tables.RecipeCosts]}.{ColumnName[Columns.recipe_id]} " +
                    $"INNER JOIN {TableName[Tables.Resources]} " +
                    $"ON {TableName[Tables.RecipeCosts]}.{ColumnName[Columns.resource_id]} = {TableName[Tables.Resources]}.{ColumnName[Columns.resource_id]} " +
                    $"WHERE {professionConstraint}" +
                $") GROUP BY {ColumnName[Columns.recipe]}"
            );
        }

        public static DataTable GetRecipesResult(string profession, int tier) {
            long profession_id = GetProfessionID(profession);
            return Query(
                $"SELECT {ColumnName[Columns.recipe]}, SUM({ColumnName[Columns.price]} * {ColumnName[Columns.amount]}) AS tier{tier}reward " +
                $"FROM (" +
                    $"SELECT {ColumnName[Columns.recipe]}, {ColumnName[Columns.resource]}, {ColumnName[Columns.price]}, {ColumnName[Columns.amount]} " +
                    $"FROM {TableName[Tables.Recipes]} " +
                    $"INNER JOIN {TableName[Tables.RecipeResults]} " +
                    $"ON {TableName[Tables.Recipes]}.{ColumnName[Columns.recipe_id]} = {TableName[Tables.RecipeResults]}.{ColumnName[Columns.recipe_id]} " +
                    $"INNER JOIN {TableName[Tables.Resources]} " +
                    $"ON {TableName[Tables.RecipeResults]}.{ColumnName[Columns.resource_id]} = {TableName[Tables.Resources]}.{ColumnName[Columns.resource_id]} " +
                    $"WHERE {TableName[Tables.Recipes]}.{ColumnName[Columns.profession_id]} = {profession_id} AND {ColumnName[Columns.tier]} = {tier}" +
                $") GROUP BY {ColumnName[Columns.recipe]}"
            );
        }
        #endregion


        #region Insert Methods
        public static void InsertProfession(string name, int grade = 0) {
            string values = $"(NULL, '{name}', {grade})";
            AddRow(Tables.Professions, values);
        }

        public static void InsertResource(string name, int cost) {
            // TODO: Add old row to PriceHistory
            string values = $"(NULL, '{name}', {cost}, '{DateTimeSQLite(DateTime.Now)}')";
            AddRow(Tables.Resources, values);
        }

        public static void InsertRecipe(string name, string profession, int grade, List<Tuple<string, int>> costs, List<Tuple<int, string, int>> results) {
            InsertRecipeName(name, profession, grade);
            foreach (Tuple<string, int> cost in costs) {
                InsertRecipeCost(name, cost.Item1, cost.Item2);
            }
            foreach (Tuple<int, string, int> result in results) {
                InsertRecipeResult(name, result.Item1, result.Item2, result.Item3);
            }
        }

        public static void InsertRecipeName(string name, string profession, int grade) {
            long profession_id = GetProfessionID(profession);
            string values = $"(NULL, '{name}', '{profession_id}', {grade})";
            AddRow(Tables.Recipes, values);
        }

        public static void InsertRecipeCost(string recipe, string resource, int amount) {
            long recipe_id = GetRecipeID(recipe);
            long resource_id = GetResourceID(resource);
            string values = $"('{recipe_id}', '{resource_id}', {amount})";
            AddRow(Tables.RecipeCosts, values);
        }

        public static void InsertRecipeResult(string recipe, int tier, string resource, int amount) {
            long recipe_id = GetRecipeID(recipe);
            long resource_id = GetResourceID(resource);
            string values = $"('{recipe_id}', '{resource_id}', {amount}, {tier})";
            AddRow(Tables.RecipeResults, values);
        }

        public static void InsertUpgradeRequirement(string profession, int grade, string resource, int amount) {
            long profession_id = GetProfessionID(profession);
            long resource_id = GetResourceID(resource);
            string values = $"('{profession_id}', {grade}, '{resource_id}', {amount})";
            AddRow(Tables.Upgrades, values);
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