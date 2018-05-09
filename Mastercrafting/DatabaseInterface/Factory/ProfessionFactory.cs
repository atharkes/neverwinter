using DatabaseInterface.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseInterface.Factory {
    /// <summary> Creates professions, making sure there are no multiple objects of the same profession </summary>
    public class ProfessionFactory {
        /// <summary> The set of all profession objects </summary>
        internal HashSet<Profession> Professions = new HashSet<Profession>();
        /// <summary> The function to create profession with </summary>
        Func<string, int, Profession> createProfession;

        /// <summary> Create a new profession factory </summary>
        /// <param name="createProfession">The function to create professions with</param>
        internal ProfessionFactory(Func<string, int, Profession> createProfession) {
            this.createProfession = createProfession;
        }

        /// <summary> Loads all profession from the profession table </summary>
        /// <returns>A list of all the professions</returns>
        public List<Profession> LoadProfessions() {
            return TableManager.Profession.LoadProfessions();
        }

        /// <summary> Create a new profession, or get a reference to the already existing object </summary>
        /// <param name="name">The name of the profession</param>
        /// <returns>The profession object corresponding to the name</returns>
        public Profession CreateProfession(string name, int grade = 0) {
            Profession profession = Professions.FirstOrDefault(p => p.Name == name);
            if (Equals(profession, default(Profession))) {
                profession = createProfession.Invoke(name, grade);
                Professions.Add(profession);
            }
            return profession;
        }

        /// <summary> Remove a profession </summary>
        /// <param name="profession">The profession to remove</param>
        public void RemoveProfession(Profession profession) {
            if (Recipe.Factory.Recipes.Count > 0) {
                throw new ArgumentException("There are still recipes in this profession");
            }
            Professions.Remove(profession);
            TableManager.Profession.RemoveProfession(profession.ID);
            (profession as IDisposable).Dispose();
        }
    }
}
