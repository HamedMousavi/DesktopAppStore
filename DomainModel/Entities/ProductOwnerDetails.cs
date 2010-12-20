using System;
using System.Collections.Generic;



namespace DomainModel.Entities
{
    public class ProductOwnerDetails
    {
        public ProductLanguage Language { get; set; }
        public string DisplayName { get; set; }
        public BranchCollection Branches { get; set; }
        public DateTime? LastLoaded { get; set; }
        public List<ProductBase> Products { get; set; }


        public ProductOwnerDetails()
        {
            this.Branches = new BranchCollection();
            this.Products = new List<ProductBase>();
        }
    }
}
