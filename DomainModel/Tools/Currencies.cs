using System;
using System.Collections.Generic;
using DomainModel.Entities;



namespace DomainModel.Tools
{
    public class Currencies
    {
        public static string Format(decimal? money, ProductLanguage culture)
        {
            // UNDONE:
            return string.Format("{0}", money.Value);
        }
    }
}
