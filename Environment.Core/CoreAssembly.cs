using System.Reflection;

namespace Environment.Core
{
    // The core assembly helper methods
    public static class CoreAssembly
    {
        public static string GetAssemblyLocation()
        {
            return Assembly.GetExecutingAssembly().Location;
        }
    }
}