using System;
using System.Collections.Generic;
using DomainModel.Entities;
using System.Globalization;



namespace DomainModel.Tools
{
    public class Currencies
    {
        public static string Format(decimal? money, ProductLanguage culture)
        {
            return Format(money, culture.CultureId);
        }


        public static string Format(decimal? money, string cultureId)
        {
            if (money == null) return "0";
            else if (!money.HasValue) return "0";

            CultureInfo cult = new CultureInfo(cultureId);

            string currencySymbol;

            if (cultureId.Contains("fa-IR"))
            {
                currencySymbol = "تومان";
            }
            else
            {
                currencySymbol = "Toomans";
            }


            // Can't use "c" format string. Prices are entered by Iran REAL currency i.e. Toomans
            return Tools.NativeNumbers.Format(
                string.Format("{0} {1}",
                money.Value.ToString("#,#", cult),
                currencySymbol), cult);
        }
    }
}
