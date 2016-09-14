using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSUKariyer.COMMON
{
    public class DateHelper
    {
        public static bool IsInWeekend(DateTime dateValue)
        {
            if (dateValue.DayOfWeek == DayOfWeek.Saturday || dateValue.DayOfWeek == DayOfWeek.Sunday)
                return true;
            return false;
        }

        public static int GetMonthDifference(DateTime date1, DateTime date2)
        {
            int monthDifference = 0;
            bool datesChanged = false;

            if (date1 < date2)
            {
                DateTime tempDate = date2;

                date2 = date1;
                date1 = tempDate;

                datesChanged = true;
            }

            monthDifference = ((date1.Year * 12) + date1.Month) - ((date2.Year * 12) + date2.Month);

            if (date1.Day < date2.Day)
                monthDifference = monthDifference - 1;

            if (datesChanged)
                monthDifference = monthDifference * -1;

            return monthDifference;
        }
    }
}
