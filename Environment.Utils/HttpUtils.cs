using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace BIM_Leaders_Utils
{
    public class HttpUtils
    {
        private static readonly string botToken = "5887143574:AAFR7jmh6HrUk6n5Cq65MTHTDXW0qzMBvSU";

        public static async Task sendMsg(string chatId, string message)
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = $"https://api.telegram.org/bot{botToken}/sendMessage";

            //"+2OdsfvC2Bh5hZDI6"

            var parameters2 = new Dictionary<string, string>
            {
                { "chat_id", "@revitAPITest" },
                { "text", message }
            };
            var content2 = new FormUrlEncodedContent(parameters2);

            try
            {

                var response1 = await httpClient.PostAsync(apiUrl, content2);
                response1.EnsureSuccessStatusCode();
            }
            catch
            {
                //TaskDialog.Show("Error", ex.Message);
            }
        }
        public static string GetCrimeData(Document doc, string transName, string versionName)
        {
            string res;
            string nameofFile = doc.Title;
            string autodeskUsername = doc.Application.Username;

            DateTime dateTime = DateTime.Now;
            string formattedTime = dateTime.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            string crime = (transName == "Ungroup") ? "🔔GROUP HAS BEEN UNGROUPED🔔" :
                           (transName == "Linework") ? "🔔LINEWORK WAS USED🔔" :
                           (transName == "Filled Region") ? "🔔FILLED REGION WAS CREATED🔔" :
                           (transName == "Edit Text") ? "🔔TEXT WAS CREATED🔔" :
                           (transName == "Detail Lines") ? "🔔DETAIL LINE WAS CREATED🔔" :
                           (transName == "Delete Selection") ? "🔔ELEMENT WAS EXCLUDED FROM GROUP🔔" :
                           (transName == "Purge unused") ? "🔔PURGE UNUSED WAS DONE🔔" :
                           (transName == "Hide/Isolate") ? "🔔ELEMENT WAS HIDDEN🔔" :
                           (transName == "Restore All Excluded") ? "🔔RESTORE ALL EXCLUDED WAS DONE🔔" :
                                                              "🔔CRIME WAS COMMITED🔔";

            res = string.Format("{0}" + Environment.NewLine + "Offender: {1}"
                                      + Environment.NewLine + "Offense date: {2}"
                                      + Environment.NewLine + "Version: {3}"
                                      + Environment.NewLine + "Name of file: {4}"
                                      + Environment.NewLine + "Autodesk username: {5}",
                                      crime, username, formattedTime, versionName, nameofFile, autodeskUsername);

            return res;
        }
    }
}
