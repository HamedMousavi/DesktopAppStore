using System;
using System.Collections.Generic;

namespace DomainModel.Entities
{
    public class ProductBase
    {
        public ProductBase()
        {
            this.MultiLanguage = false;

            this.Price = null;
            this.ProductId = null;
            this.ProductReleaseDate = null;
            
            this.SupportedPlatforms = new List<SoftwarePlatform>();
            this.ProductOwners = new List<ProductOwner>();
            this.ProductTechnologies = new List<ProductTechnology>();
            this.Catalog = new ProductCatalog();
            this.Article = new ProductArticle();
        }


        public Int16                    Status              { get; set; }
        public Int64?                   ProductId           { get; set; }   // Unique Id of the product
        public string                   ProductName         { get; set; }   // Name of the product
        public string                   ProductWebsite      { get; set; }   // Link to the product page online
        public string                   BriefDescription    { get; set; }   // A brief description of the product
        public string                   ProductVersion      { get; set; }   // Version of this product
        public DateTime?                ProductReleaseDate  { get; set; }   // Release date of the product
        public decimal?                 Price { get; set; }
        public string                   PriceDetails { get; set; }
        public bool                     MultiLanguage { get; set; }
        
        public List<SoftwarePlatform>   SupportedPlatforms  { get; protected set; }
        public List<ProductOwner>       ProductOwners       { get; protected set; }
        public List<ProductTechnology>  ProductTechnologies { get; protected set; }
        public ProductCatalog           Catalog { get; private set; }
        public int                      ArticleLanguage { get; set; }
        public ProductArticle           Article { get; set; }
    }
}
