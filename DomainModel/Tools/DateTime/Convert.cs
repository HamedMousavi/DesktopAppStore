using System;
using System.Collections.Generic;
using DomainModel.Entities;
using System.Globalization;



namespace DomainModel.Tools.DateTime
{
    public class Convert
    {


        public static string ToCulture(System.DateTime? time, ProductLanguage destinationCulture)
        {
            return ToCulture(time, destinationCulture.CultureId);
        }


        public static string ToCulture(System.DateTime? time, string destinationCultureId)
        {
            if (time == null) return "Unknown";
            else if (!time.HasValue) return "Unknown";

            if (destinationCultureId.CompareTo("fa-IR") == 0)
            {
                JalaliCalendar calendar = new JalaliCalendar();
                calendar.Current = time.Value;
                return calendar.PersianDayOfWeek +
                    " " +
                    calendar.PersianDay +
                    " " +
                    calendar.PersianMonth +
                    " " +
                    calendar.PersianYear;
            }

            return time.Value.ToString("D", new CultureInfo(destinationCultureId));
        }
    }
}
