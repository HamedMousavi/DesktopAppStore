using System;



namespace DomainModel.Entities
{
    public class CategoryParent : CategoryCollection
    {
        public ProductLanguage Language { get; set; }

        public CategoryParent()
            : base()
        {
            this.Language = new ProductLanguage();
        }
    }
}
