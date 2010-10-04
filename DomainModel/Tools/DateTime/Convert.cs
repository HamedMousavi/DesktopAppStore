using System;
using System.Collections.Generic;
using DomainModel.Entities;



namespace DomainModel.Tools.DateTime
{
    public class Convert
    {
        public static string ToCulture(System.DateTime? time, ProductLanguage destinationCulture)
        {
            return string.Format("{0}", time.Value);
        }
    }
}
