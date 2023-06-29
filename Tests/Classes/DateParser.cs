using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkTest.Classes
{
    public class DateParser
    {

        public string GetYearMonthDay(DateTime dateTime) 
        {
            string date = "";

            for (int i = 0; i < 100; i++) 
            {
                date = dateTime.ToShortDateString();
            }

            return date;
        }

        public string GetYearMonthDayConcat(DateTime dateTime)
        {
            int year = 0;
            string month = "";
            string day = "";

            for (int i = 0; i < 100; i++)
            {
                 year = dateTime.Year;
                 month = dateTime.ToString("MM");
                 day = dateTime.ToString("dd");

            }

            return $"{year}. {month}. {day}.";
        }

        public string GetYearMonthDayWunschBasic(DateTime dateTime) 
        {
            string date = "";

            for (int i = 0; i < 100; i++)
            {
                date = dateTime.ToString().Split(' ')[0];
            }

            return date;

        }
        public string GetYearMonthDayWunschFullPower(DateTime dateTime)
        {
            DateTime helperDateTime = dateTime.AddDays(-1);
            string date = "";

            for (int i = 0; i < 100; i++)
            {
                date = dateTime.ToString().Split(' ')[0].Substring(0, helperDateTime.ToString().Split(' ')[0].Length - 1);
            }

            return date;

        }
    }
}
