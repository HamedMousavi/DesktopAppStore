using System;



namespace DomainModel.Entities
{
    public class ProductLanguage : ProductOptionBase
    {
        public string CultureId { get; set; }


        public ProductLanguage()
        {
        }


        public ProductLanguage(string culture)
        {
            this.CultureId = culture;
        }
    }
}
