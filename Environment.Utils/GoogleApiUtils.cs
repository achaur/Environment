using System;
using System.Collections.Generic;
using System.Linq;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace BIM_Leaders_Utils
{
    public class GoogleApiUtils
    {
        #region properties

        private protected static string spreadsheetId = "1hgRmh12459roWSC4s7Rp6mE4MT_99VgCX9ktUb7Zs4c";

        //google sheet names and ranges for VERSION 2020
        public const string internalUsersListRange2020 = "InternalUsers2020!A:B";
        public const string internalUsersListName2020 =  "InternalUsers2020";

        public const string externalUsersListRange2020 = "ExternalUsers2020!C:D";
        public const string externalUsersListName2020 =  "ExternalUsers2020";

        //google sheet names and ranges for VERSION 2021
        public const string internalUsersListRange2021 = "InternalUsers2021!A:B";
        public const string internalUsersListName2021 =  "InternalUsers2021";

        public const string externalUsersListRange2021 = "ExternalUsers2021!C:D";
        public const string externalUsersListName2021 =  "ExternalUsers2021";


        //google sheet names and ranges for VERSION 2022
        public const string internalUsersListRange2022 = "InternalUsers2022!A:B";
        public const string internalUsersListName2022 =  "InternalUsers2022";

        public const string externalUsersListRange2022 = "ExternalUsers2022!C:D";
        public const string externalUsersListName2022 =  "ExternalUsers2022";

        //google sheet names and ranges for VERSION 2023
        public const string internalUsersListRange2023 = "InternalUsers2023!A:B";
        public const string internalUsersListName2023 =  "InternalUsers2023";

        public const string externalUsersListRange2023 = "ExternalUsers2023!C:D";
        public const string externalUsersListName2023 =  "ExternalUsers2023";

        //google sheet names and ranges for VERSION 2024
        public const string internalUsersListRange2024 = "InternalUsers2024!A:B";
        public const string internalUsersListName2024 = "InternalUsers2024";

        public const string externalUsersListRange2024 = "ExternalUsers2024!C:D";
        public const string externalUsersListName2024 = "ExternalUsers2024";

        #endregion

        public static bool UserIsInternal()
        {
            string sheetRange = "";

#if VERSION2020
            sheetRange = internalUsersListRange2020;
#elif VERSION2021
            sheetRange = internalUsersListRange2021;
#elif VERSION2022
            sheetRange = internalUsersListRange2022;
#elif VERSION2023
            sheetRange = internalUsersListRange2023;
#elif VERSION2024
            sheetRange = internalUsersListRange2024;
#endif
            int internalUserInex = CheckUsername(sheetRange, Environment.UserName);

            if (internalUserInex != -1)
                return true;

            return false;
        }

        public static int CheckUsername(string range, string username)
        {
            IList<IList<object>> values = GetGoogleSheetValues(range);

            //make checking if google api contains this username
            if (values != null && values.Count > 0)
            {
                for (int k = 0; k < values.Count(); k++)
                {
                    if (values[k]?.Count() > 0)
                    {
                        if (values[k][0].ToString() == username)
                        {
                            return k;
                        }
                    }
                }
            }

            return -1;
        }

        public static string GetInstallationInfo(int infoType)
        {
            string retrievedInfo = "";

            switch (infoType)
            {
                case 2:
                    retrievedInfo = Environment.UserName;
                    break;
                case 4:
                    retrievedInfo = TimeUtils.GetCurrentFormattedTime();
                    break;
                case 7:
                    retrievedInfo = AssemblyUtils.GetAssemblyVersion();
                    break;
                default:
                    break;
            }

            return retrievedInfo;
        }

        public static SheetsService GetSheetsService()
        {
            string pathToCredentials = JsonUtils.GetJsonString();

            var credential = GoogleCredential.FromJson(pathToCredentials)
                .CreateScoped(SheetsService.Scope.Spreadsheets);

            // Create the Sheets API service
            var sheetsService = new SheetsService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential
            });

            return sheetsService;
        }

        public static void SetCellInfo(string nameOfSheet, int row, int column)
        {
            string range = nameOfSheet + "!" + (char)(column + 65) + (row + 1).ToString();

            var service = GetSheetsService();

            // Specify the value you want to set in the cell
            var valueRange = new ValueRange();
            valueRange.Values = new List<IList<object>> { new List<object> { GetInstallationInfo(column) } };

            // Request the data from the spreadsheet
            var request = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, range);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
            request.Execute();
        }

        public static string GetCellInfo(string nameOfSheet, int row, int column)
        {
            string range = nameOfSheet + "!" + (char)(column + 65) + (row + 1).ToString();

            IList<IList<object>> values = GetGoogleSheetValues(range);

            IList<object> firstRow = values?.First();
            string firstColumnOfFirstRow = firstRow?.First()?.ToString();
            
            return firstColumnOfFirstRow;
        }

        public static void ClearCellInfo(string nameOfSheet, int row, int column)
        {
            string range = nameOfSheet + "!" + (char)(column + 65) + (row + 1).ToString();

            var service = GetSheetsService();

            // Specify the value you want to set in the cell
            var valueRange = new ValueRange();
            valueRange.Values = new List<IList<object>> { new List<object> { string.Empty } };

            // Request the data from the spreadsheet
            var request = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, range);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
            request.Execute();
        }

        public static int GetIndexOfUser(IList<IList<object>> values, string username)
        {
            //found the matching pair of email and password
            int indexOfUser = -1;

            //make checking if google api contains this username
            if (values != null && values.Count > 0)
            {
                for (int k = 0; k < values.Count(); k++)
                {
                    if (values[k]?.Count() > 0)
                    {
                        if (values[k][0].ToString() == username)
                        {
                            return k;
                        }
                    }
                }
            }

            return indexOfUser;
        }

        public static bool CheckUsernameAndPassword(IList<IList<object>> values, string username, string password)
        {
            //make checking if google api contains this pair of username and password
            if (values != null && values.Count > 0)
            {
                for (int k = 0; k < values.Count(); k++)
                {
                    if (values[k]?.Count() > 1)
                    {
                        if (values[k][0].ToString() == username &&
                                values[k][1].ToString() == password)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static IList<IList<object>> GetGoogleSheetValues(string range)
        {
            if (string.IsNullOrEmpty(range))
                return null;

            // Create the Sheets API service
            var sheetsService = GetSheetsService();

            // Request the data from the spreadsheet
            SpreadsheetsResource.ValuesResource.GetRequest request =
                sheetsService.Spreadsheets.Values.Get(spreadsheetId, range);
            ValueRange response = request.Execute();

            // Process the data
            IList<IList<object>> values = response.Values;

            return values;
        }
    }
}
