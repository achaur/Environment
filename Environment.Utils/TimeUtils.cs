using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM_Leaders_Utils
{
    public class TimeUtils
    {
        public static string GetCurrentFormattedTime()
        {
            DateTime dateTime = DateTime.Now;

            //string timeString = dateTime.ToShortTimeString();
            string datestring = dateTime.ToShortDateString();

            return datestring;
        }

        public static int SubstractTime(string dateOfInstallation)
        {
            string currentDate = GetCurrentFormattedTime();

            string format = "dd.MM.yyyy";

            // Parse the date strings into DateTime objects
            DateTime dateOfInstallationFormatted = DateTime.ParseExact(dateOfInstallation, format, null);
            DateTime currentDateFormatted = DateTime.ParseExact(currentDate, format, null);

            // Calculate the difference in days
            TimeSpan difference = currentDateFormatted - dateOfInstallationFormatted;

            // Get the number of days
            int daysDifference = (int)difference.TotalDays;

            return daysDifference;
        }
    }
}
