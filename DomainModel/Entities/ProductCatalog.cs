using System;



namespace DomainModel.Entities
{
    public class ProductCatalog
    {
        public bool IsEnabled { get; set; }
        public bool IsFeatured { get; set; }
        public int? SearchPriority { get; set; }
        public decimal? UserRating { get; set; }
        public decimal? EditorRating { get; set; }
        public string UrlName { get; set; }
        public int? ViewsCount { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? InsertDate { get; set; }
    }

}
