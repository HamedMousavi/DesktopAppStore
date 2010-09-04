using System;



namespace DomainModel.Entities
{
    public class ProductBrand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string ResourceUrl { get; set; } // Images, Intro videos, etc.
    }
}
