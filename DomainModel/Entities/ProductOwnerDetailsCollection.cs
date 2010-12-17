using System;
using System.Collections.Generic;



namespace DomainModel.Entities
{
    public class ProductOwnerDetailsCollection : List<ProductOwnerDetails>
    {


        public ProductOwnerDetails this[string culture]
        {
            get
            {
                foreach (ProductOwnerDetails item in this)
                {
                    if (item.Language.CultureId.Equals(culture, StringComparison.Ordinal) ||
                        item.Language.Name.Equals(culture, StringComparison.Ordinal))
                    {
                        return item;
                    }
                }

                return null;
            }
        }
    }
}
