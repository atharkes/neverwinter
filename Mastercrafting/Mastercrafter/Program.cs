using DatabaseInterface;
using DatabaseInterface.Data;
using Mastercrafter.DataExtensions;
using System;
using System.Collections.Generic;

namespace Mastercrafter {
    /// <summary> Top level class of the application </summary>
    class Program {
        /// <summary> Main call point of the project </summary>
        /// <param name="args">The arguments given on execution</param>
        static void Main(string[] args) {
            Console.WriteLine("Initializing Database...");
            Database.InitializeDatabase("test.sqlite");
            List<Resource> resources = Resource.Factory.GetResources();
            Console.WriteLine("Database is loaded");
            while (true) {
                string input = Console.ReadLine();
                Resource resource;
                if (int.TryParse(input, out int n)) {
                    resource = resources[n];
                } else {
                    resource = resources.Find(r => r.Name == input);
                }
                if (resource == null) {
                    Console.WriteLine($"Couldn't find resource: \"{input}\"");
                } else {
                    Console.WriteLine("{0}\t{1}\t{2}", resource.Name, resource.Price, resource.CraftCost());
                }
                
            }
        }
    }
}
