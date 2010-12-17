using System;
using System.Globalization;



namespace DomainModel.Tools
{
    public class NativeNumbers
    {
        public static string Format(string ordinary, string culture)
        {
            CultureInfo cult = new CultureInfo(culture);
            return Format(ordinary, cult);
        }

        // cult.NumberFormat.DigitSubstitution = DigitShapes.NativeNational;
        // System.Drawing.StringFormat.GenericDefault.SetDigitSubstitution(
        public static string Format(string ordinary, CultureInfo culture)
        {
            System.Text.StringBuilder res = new System.Text.StringBuilder();
            if (culture.NumberFormat.NativeDigits.Length == 10)
            {
                for (int i = 0; i < ordinary.Length; i++)
                {
                    if (char.IsDigit(ordinary[i]))
                    {
                        res.Append(culture.NumberFormat.NativeDigits[Int16.Parse(ordinary[i].ToString())]);
                    }
                    else
                    {
                        res.Append(ordinary[i]);
                    }
                }
            }

            return res.ToString();
        }
    }
}
