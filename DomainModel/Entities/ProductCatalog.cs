using System;



namespace DomainModel.Entities
{
    public class ProductCatalog
    {
        public int? SearchPriority { get; set; }
        public decimal? UserRating { get; set; }
        public decimal? EditorRating { get; set; }
        public string UrlName { get; set; }
        public string ResourceDir { get; set; }
    }
}
