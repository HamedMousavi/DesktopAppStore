using System;
using System.Collections.Generic;

namespace DomainModel.Entities
{
    public class ProductBase
    {
        public int?         ProductId           { get; set; }   // Unique Id of the product
        public string       ProductName         { get; set; }   // Name of the product
        public string       ProductUri          { get; set; }   // Link to the product page online
        public string       Description         { get; set; }   // A brief description of the product
        public string       ArticleUri          { get; set; }   // Article URI in this website
        public string       ResourceDir         { get; set; }   // Directory containing resources for the article
        public string       ProductVersion      { get; set; }   // Version of this product
        public DateTime?    ProductReleaseDate  { get; set; }   // Release date of the product
        
        public List<SoftwarePlatform>   SupportedPlatforms  { get; protected set; }
        public List<ProductOwner>       ProductOwners       { get; protected set; }
        public List<ProductTechnology>  ProductTechnologies { get; protected set; }

    }
}
