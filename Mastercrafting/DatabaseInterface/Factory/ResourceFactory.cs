using DatabaseInterface.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseInterface.Factory {
    /// <summary> Creates resources, making sure there are no multiple objects of the same resource </summary>
    public class ResourceFactory {
        /// <summary> The set of all resource objects </summary>
        internal HashSet<Resource> Resources = new HashSet<Resource>();
        /// <summary> The function used to create resources </summary>
        Func<string, int, Resource> createResource;

        /// <summary> Create a new resource factory </summary>
        /// <param name="createResource">The function used to create resources with</param>
        internal ResourceFactory(Func<string, int, Resource> createResource) {
            this.createResource = createResource;
        }

        /// <summary> Gets the resources currently in memory </summary>
        /// <returns>A list of the resources in memory</returns>
        public List<Resource> GetResources() {
            return Resources.ToList();
        }

        /// <summary> Create a new resource, or get a reference to the already existing object </summary>
        /// <param name="name">The name of the resource</param>
        /// <param name="price">The price of the resource</param>
        /// <returns>The resource object corresponding to the name</returns>
        public Resource CreateResource(string name, int price = 1) {
            Resource resource = Resources.FirstOrDefault(r => r.Name == name);
            if (Equals(resource, default(Profession))) {
                resource = createResource.Invoke(name, price);
                Resources.Add(resource);
            }
            return resource;
        }

        /// <summary> Remove a resource </summary>
        /// <param name="resource">The resource to remove</param>
        public void RemoveResource(Resource resource) {
            if (Recipe.Factory.Recipes.Any(r => r.Resources.Contains(resource))) {
                throw new ArgumentException("There are still recipes using this resource");
            }
            Resources.Remove(resource);
            TableManager.Resource.RemoveResource(resource.ID);
            (resource as IDisposable).Dispose();
        }
    }
}
