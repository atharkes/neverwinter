using DatabaseInterface.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseInterface.Factory {
    /// <summary> Creates resources, making sure there are no multiple objects of the same resource </summary>
    public static class ResourceFactory {
        /// <summary> The set of all resource objects </summary>
        static HashSet<Resource> resources = new HashSet<Resource>();

        /// <summary> Create a new resource, or get a reference to the already existing object </summary>
        /// <param name="name">The name of the resource</param>
        /// <param name="price">The price of the resource</param>
        /// <returns>The resource object corresponding to the name</returns>
        public static Resource CreateResource(string name, int price = 1) {
            Resource resource = resources.FirstOrDefault(r => r.Name == name);
            if (Equals(resource, default(Profession))) {
                resource = new Resource(name, price);
                resources.Add(resource);
            }
            return resource;
        }

        /// <summary> Remove a resource </summary>
        /// <param name="resource">The resource to remove</param>
        public static void RemoveResource(Resource resource) {
            resources.Remove(resource);
            Database.ResourceTable.RemoveResource(resource.ID);
            (resource as IDisposable).Dispose();
        }
    }
}
