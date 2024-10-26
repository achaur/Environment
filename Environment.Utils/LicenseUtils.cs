using System;
using System.Collections.Generic;

namespace BIM_Leaders_Utils
{
    public class LicenseUtils
    {
        public class License
        {
            public int remainingDaysOfTrialVersion { get; set; }
            public bool lastVersionInstalled { get; set; }
            public LicenseStatus licenseStatusNumber { get; set; }
            public List<int> panelsAvailable { get; set; }
            //add info about available panels for user
        }

        public enum LicenseInfo
        {
            Username = 0,
            Password = 1,
            WindowsUsername = 2,
            TrialVersionType = 3,
            DateOfInstallation = 4,
            PanelsAvailable = 5,
            NumberOfUsersAllowed = 6,
            VersionInstalled = 7
        }

        public enum LicenseStatus
        { 
            LicenseIsNotRequired = 0,
            TrialVersionIsAvailable  = 1,
            TrialVersionExpired = 2,
            //need to add this checking
            LicenseAlreadyUsedByOtherUser = 3,
            LicenseIsNotValid = 4,
            LicenseIsValid = 5,
            LicenseCheckerFailed = 6
        }

        public static string[] licenseStatusMsgs = new string[7]
        {
            "",
            "",
            "Trial version has expired. Please, contant admin.",
            //need to add this checking
            "License is already used by other user.",
            "License is not valid. Please, contact admin.",
            "",
            "Could not check the license. Please, check your internet connection and try again."
        };

        public static List<int> GetAvailablePanelsForUser(int userIndex)
        {
            string externalUsersListName = "";

#if VERSION2020
            externalUsersListName = GoogleApiUtils.externalUsersListName2020;
#elif VERSION2021
            externalUsersListName = GoogleApiUtils.externalUsersListName2021;
#elif VERSION2022
            externalUsersListName = GoogleApiUtils.externalUsersListName2022;
#elif VERSION2023
            externalUsersListName = GoogleApiUtils.externalUsersListName2023;
#elif VERSION2024
            externalUsersListName = GoogleApiUtils.externalUsersListName2024;
#endif

            string licenseType = GoogleApiUtils.GetCellInfo
                        (externalUsersListName, userIndex, (int)LicenseInfo.PanelsAvailable);

            string[] splittedResult = licenseType.Split (',');

            List<int> indexes = new List<int>();

            foreach (string res in splittedResult)
            {
                int temp;
                int.TryParse(res, out temp);
                indexes.Add(temp);
            }

            return indexes;
        }

        public static License CheckLicenseStatus()
        {
            //return true;

            License license = new License();

            string lastPluginVersion = GoogleApiUtils.GetCellInfo("LastPluginVersion", 0, 0);

            license.lastVersionInstalled = AssemblyUtils.GetAssemblyVersion() == lastPluginVersion;

            license.remainingDaysOfTrialVersion = -1;
            license.licenseStatusNumber = LicenseStatus.LicenseCheckerFailed;
            license.panelsAvailable = new List<int> { 1,2,3,4,5,6 };

            string curUser = Environment.UserName;

            string externalUsersListRange = "";
            string externalUsersListName = "";
            string internalUsersListRange = "";

#if VERSION2020
            internalUsersListRange = GoogleApiUtils.internalUsersListRange2020;
            externalUsersListRange = GoogleApiUtils.externalUsersListRange2020;
            externalUsersListName = GoogleApiUtils.externalUsersListName2020;
#elif VERSION2021
            internalUsersListRange = GoogleApiUtils.internalUsersListRange2021;
            externalUsersListRange = GoogleApiUtils.externalUsersListRange2021;
            externalUsersListName = GoogleApiUtils.externalUsersListName2021;
#elif VERSION2022
            internalUsersListRange = GoogleApiUtils.internalUsersListRange2022;
            externalUsersListRange = GoogleApiUtils.externalUsersListRange2022;
            externalUsersListName = GoogleApiUtils.externalUsersListName2022;
#elif VERSION2023
            internalUsersListRange = GoogleApiUtils.internalUsersListRange2023;
            externalUsersListRange = GoogleApiUtils.externalUsersListRange2023;
            externalUsersListName = GoogleApiUtils.externalUsersListName2023;
#elif VERSION2024
            internalUsersListRange = GoogleApiUtils.internalUsersListRange2024;
            externalUsersListRange = GoogleApiUtils.externalUsersListRange2024;
            externalUsersListName = GoogleApiUtils.externalUsersListName2024;
#endif

            int internalUserIndex = GoogleApiUtils.CheckUsername(internalUsersListRange, curUser);

            if (internalUserIndex != -1)
            {
                license.licenseStatusNumber = LicenseStatus.LicenseIsNotRequired;
                license.remainingDaysOfTrialVersion = -1;

                return license;
            }
            else
            {
                // check if external user is in the list
                int externalUserIndex = GoogleApiUtils.CheckUsername(externalUsersListRange, curUser);

                if (externalUserIndex != -1)
                {
                    /*
                    //check which panels of plugin are available for user
                    string panelsInfo = GoogleApiUtils.GetCellInfo
                        (GoogleApiUtils.externalUsersListName, externalUserIndex, (int)LicenseInfo.PanelsAvailable);

                    if (panelsInfo != null)
                    {
                        string[] panelsInfoSplitted = panelsInfo.Split(',');

                        List<int> panelsNumbers = new List<int>();

                        foreach (string s in panelsInfoSplitted)
                        {
                            int panelNumber;

                            int.TryParse(s, out panelNumber);

                            panelsNumbers.Add(panelNumber);
                        }
                        license.panelsAvailable = panelsNumbers;
                    }
                    */

                    string licenseType = GoogleApiUtils.GetCellInfo
                        (externalUsersListName, externalUserIndex, (int)LicenseInfo.TrialVersionType);
                    //check whether license is trial or infinite
                    if (licenseType != null)
                    {
                        // 0 means that license is infinite and should not be checked for trial version expiration
                        if (licenseType == "0")
                        {
                            license.licenseStatusNumber = LicenseStatus.LicenseIsValid;
                            return license;
                        }
                        // 1 means that license is a trial version and expiration period should be checked
                        else if (licenseType == "1")
                        {
                            // check if license is not expired
                            string licenseDateInstallation = GoogleApiUtils.GetCellInfo
                                (externalUsersListName, 
                                externalUserIndex, 
                                (int)LicenseInfo.DateOfInstallation);
                            
                            if (licenseDateInstallation != null)
                            { 
                                int daysOfUsage = TimeUtils.SubstractTime(licenseDateInstallation);

                                if (daysOfUsage < 30)
                                {
                                    license.remainingDaysOfTrialVersion = daysOfUsage;

                                    licenseStatusMsgs[(int)LicenseStatus.TrialVersionIsAvailable] = 
                                        $"You have a {30 - daysOfUsage} days left to test the plugin.";

                                    license.licenseStatusNumber = LicenseStatus.TrialVersionIsAvailable;

                                    return license;
                                }
                                else
                                {
                                    license.licenseStatusNumber = LicenseStatus.TrialVersionExpired;
                                    return license;
                                }
                            }
                        }
                    }

                }
                else
                {
                    license.licenseStatusNumber = LicenseStatus.LicenseAlreadyUsedByOtherUser;

                    return license;
                }
            }

            return license;
        }

    }
}
