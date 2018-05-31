using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Utility
{
    public static class UIUtility
    {
        public static DateTime ToDateTime(string value)
        {
            DateTime realdate = DateTime.Parse(value, CultureInfo.GetCultureInfo("en-gb"));
            return realdate;
        }
        public static String NumberInBangla(Int32 num)
        {
            string retDate = num.ToString();

            retDate = retDate.Replace("0", "০")
                .Replace("1", "১")
                .Replace("2", "২")
                .Replace("3", "৩")
                .Replace("4", "৪")
                .Replace("5", "৫")
                .Replace("6", "৬")
                .Replace("7", "৭")
                .Replace("8", "৮")
                .Replace("9", "৯");

            return retDate;
        }
        public static string GetPreviousYear(string presentYear)
        {
            Int32 year1 = Convert.ToInt32(presentYear.Substring(0, presentYear.IndexOf("-")));
            Int32 year2 = year1 - 1;

            return (year2 + "-" + year1).ToString();
        }

        public static string GetNextYear(string presentYear)
        {
            Int32 year1 = Convert.ToInt32(presentYear.Substring(presentYear.IndexOf("-") + 1, (presentYear.Length - presentYear.IndexOf("-") - 1)));
            Int32 year2 = year1 + 1;

            return (year1 + "-" + year2);
        }

        public static string GetPreviousAssessmentYear(string presentAssessmentYear)
        {
            Int32 year2 = Convert.ToInt32(presentAssessmentYear.Substring(0, 4));
            Int32 year1 = year2 - 1;

            return (year1 + "-" + year2);
        }

        public static string GetNextAssessmentYear(string presentAssessmentYear)
        {
            Int32 year1 = Convert.ToInt32(presentAssessmentYear.Substring(presentAssessmentYear.IndexOf('-') + 1, 4));
            Int32 year2 = year1 + 1;

            return (year1 + "-" + year2);
        }

        public static string GetFirstYear(string year)
        {
            return (year.Substring(0, year.IndexOf("-")));
        }

        public static string GetSecondYear(string year)
        {
            return (year.Substring(year.IndexOf("-") + 1));
        }

        public static Int32 GetFiscalMonthIndex(int month)
        {
            Int32 monthIndex = month;
            Int32 fiscalMonthIndex;

            if (monthIndex > 6)
            {
                fiscalMonthIndex = monthIndex - 6;
            }
            else
            {
                fiscalMonthIndex = monthIndex + 6;
            }

            return fiscalMonthIndex;
        }
    }
}
