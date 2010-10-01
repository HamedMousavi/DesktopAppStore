using System;
using System.Collections.Generic;

namespace DomainModel.Entities
{
    public class CategoryParentCollection : List<CategoryParent>
    {


        public CategoryParent this[string culture]
        {
            get
            {
                return FindCathegoryParentByCulture(culture);
            }
        }


        private CategoryParent FindCathegoryParentByCulture(string culture)
        {
            foreach (CategoryParent cat in this)
            {
                if (cat.Language.CultureId == culture)
                {
                    return cat;
                }
            }

            return null;
        }
    }
}
