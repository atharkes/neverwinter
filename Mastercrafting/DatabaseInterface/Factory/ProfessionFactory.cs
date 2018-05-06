using DatabaseInterface.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseInterface.Factory {
    /// <summary> Creates professions, making sure there are no multiple objects of the same profession </summary>
    public static class ProfessionFactory {
        /// <summary> The set of all profession objects </summary>
        static HashSet<Profession> professions = new HashSet<Profession>();

        /// <summary> Create a new profession, or get a reference to the already existing object </summary>
        /// <param name="name">The name of the profession</param>
        /// <returns>The profession object corresponding to the name</returns>
        public static Profession CreateProfession(string name) {
            Profession prof = professions.FirstOrDefault(p => p.Name == name);
            if (Equals(prof, default(Profession))) {
                prof = new Profession(name);
                professions.Add(prof);
            }
            return prof;
        }

        /// <summary> Remove a profession </summary>
        /// <param name="profession">The profession to remove</param>
        public static void RemoveProfession(Profession profession) {
            if (profession.Recipes.Count > 0) {
                throw new ArgumentException("There are still recipes in this profession");
            }
            professions.Remove(profession);
            Database.ProfessionTable.RemoveProfession(profession.ID);
            (profession as IDisposable).Dispose();
        }
    }
}
