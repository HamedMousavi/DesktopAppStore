using System;



namespace DomainModel.Entities
{
    public class ProductBrand
    {
        public Int64 BrandId { get; set; }
        public string BrandName { get; set; }

        public ProductBrand(Int64 BrandId, string BrandName, string ResourceUrl)
        {
            this.BrandId = BrandId;
            this.BrandName = BrandName;
        }


        public ProductBrand()
        {
        }
    }
}
