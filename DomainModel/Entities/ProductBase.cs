using System;
using System.Collections.Generic;

namespace DomainModel.Entities
{
    public class ProductBase
    {
        public ProductBase()
        {
            this.ProductId = null;
            this.ProductReleaseDate = null;
            
            this.SupportedPlatforms = new List<SoftwarePlatform>();
            this.ProductOwners = new List<ProductOwner>();
            this.ProductTechnologies = new List<ProductTechnology>();
        }


        public Int64?                  ProductId           { get; set; }   // Unique Id of the product
        public string                   ProductName         { get; set; }   // Name of the product
        public string                   ProductWebsite      { get; set; }   // Link to the product page online
        public string                   BriefDescription    { get; set; }   // A brief description of the product
        public string                   ResourceDir         { get; set; }   // Directory containing resources for the article
        public string                   ProductVersion      { get; set; }   // Version of this product
        public DateTime?                ProductReleaseDate  { get; set; }   // Release date of the product
        
        public List<SoftwarePlatform>   SupportedPlatforms  { get; protected set; }
        public List<ProductOwner>       ProductOwners       { get; protected set; }
        public List<ProductTechnology>  ProductTechnologies { get; protected set; }

    }
}
