using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BIM_Leaders_Utils
{
    public class AssemblyUtils
    {
        public static string GetAssemblyVersion()
        { 
            Assembly assembly = Assembly.GetExecutingAssembly();

            AssemblyName aseemblyName = assembly.GetName();

            string assemblyVersion = aseemblyName.Version.ToString();
            
            return assemblyVersion;
        }

        public static bool AssemblyVersionIsLatest(string versionCurrent, string versionLast)
        {
            string[] versionCurrentSplitted = versionCurrent.Split('.');
            string[] versionLastSplitted = versionLast.Split('.');

            for (int i = 0; i < versionCurrentSplitted.Length; i++)
            {
                int comparable;
                Int32.TryParse(versionCurrentSplitted[i], out comparable);

                int compared;
                Int32.TryParse(versionLastSplitted[i], out compared);

                if (comparable < compared)
                { 
                    return false;
                }
            }

            return true;
        }
    }
}
