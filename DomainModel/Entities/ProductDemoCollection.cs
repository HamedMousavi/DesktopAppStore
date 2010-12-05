using System;
using System.Collections.Generic;



namespace DomainModel.Entities
{
    public class ProductDemoCollection : List<ProductDemo>
    {
        public ProductDemo CommonVersion { get; set; }


        public ProductDemo this[string culture]
        {
            get
            {
                return FindDemoByCulture(culture);
            }
        }


        private ProductDemo FindDemoByCulture(string culture)
        {
            foreach (ProductDemo demo in this)
            {
                if (demo.Language.CultureId == culture)
                {
                    return demo;
                }
            }

            return null;
        }
    }
}
