using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM_Leaders_Utils
{
    public class FileUtils
    {
        public static string[] illegalFileSymbols = { "#", "%", "&", "{", "}", "\\", "<", ">", "*", "?", "/", "$", "\'", "\"", ":", "@", "+", "`", "|", "=", "." };
        public static string CheckFileNameCorrectness(string s)
        {
            string res = s;

            foreach (string illegalSymbol in illegalFileSymbols)
            {
                if (res.Contains(illegalSymbol))
                {
                    res = res.Replace(illegalSymbol, "_");
                }
            }

            return res;
        }

        public static string CreateFileName()
        {
            DateTime dateTime = DateTime.Now;
            string timeString = dateTime.ToShortTimeString();
            string datestring = dateTime.ToShortDateString();
            string res = CheckFileNameCorrectness(datestring + "_" + timeString);

            return res;
        }
    }
}
