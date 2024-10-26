using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BIM_Leaders_Utils
{
    public static class RegexUtils
    {
        #region REGEX UTILS

        public enum RegexType
        {
            ONLY_DIGITS = 1,
            STRING_DIGITS = 2,
            STRING_DOUBLE = 3,
            STRING_DIGIT_STRING = 4,
            STRING_DIGIT_HYP_DIGIT = 5
        }

        public static bool Only_digit(string num_d)
        {
            Regex pattern = new Regex(@"^\d+$");
            MatchCollection matches = pattern.Matches(num_d);
            if (matches.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool String_digit(string num_d)
        {
            Regex pattern = new Regex(@"^\D+\d+$");
            MatchCollection matches = pattern.Matches(num_d);
            if (matches.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool String_double_value(string num_d)
        {
            Regex pattern = new Regex(@"^\D+\d+.{1}\d+$");
            MatchCollection matches = pattern.Matches(num_d);
            if (matches.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool Str_dig_hyp_digit(string num_d)
        {
            Regex pattern = new Regex(@"^\D+\s*\d+(-*|_*)\d+\s*$");
            MatchCollection matches = pattern.Matches(num_d);
            if (matches.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool Only_string(string num_d)
        {
            Regex pattern = new Regex(@"^\D+$");
            MatchCollection matches = pattern.Matches(num_d);
            if (matches.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool Str_dig_str(string num_d)
        {
            Regex pattern = new Regex(@"^\D+\d+\D+$");
            MatchCollection matches = pattern.Matches(num_d);
            if (matches.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string GetStringFromRegex(Regex pattern, string str)
        {
            MatchCollection letter_sheets = pattern.Matches(str);
            string letterString = null;
            foreach (Match a in letter_sheets)
            {
                letterString += a.ToString();
            }
            return letterString;
        }
        #endregion
    }
}
