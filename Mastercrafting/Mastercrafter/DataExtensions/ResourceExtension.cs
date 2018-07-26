using DatabaseInterface.Data;

namespace Mastercrafter.DataExtensions {
    /// <summary> Extension methods for the Resource data class </summary>
    public static class ResourceExtension {
        public int CraftCost(this Resource resource) {
            foreach (Recipe recipe in resource.ResultOf()) {

            }
        }
    }
}
