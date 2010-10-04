using System;
using System.Collections.Generic;



namespace DomainModel.Entities
{
    public class CategoryCollection : List<Category>
    {
        public Category this[string key]
        {
            get
            {
                foreach (Category item in this)
                {
                    if (item.CategoryName == key || item.UrlName == key)
                    {
                        return item;
                    }
                }

                return null;
            }
        }
    }
}
