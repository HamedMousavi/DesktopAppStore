using System;
using System.Collections.Generic;



namespace DomainModel.Entities
{
    public class ProductLanguageCollection : List<ProductLanguage>
    {
        public ProductLanguage this[string key]
        {
            get
            {
                foreach (ProductLanguage item in this)
                {
                    if (item.CultureId == key || item.Name == key)
                    {
                        return item;
                    }
                }

                return null;
            }
        }
    }
}
