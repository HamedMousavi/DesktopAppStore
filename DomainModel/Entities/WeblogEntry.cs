using System;




namespace DomainModel.Entities
{
    public class WeblogEntry
    {
        public string CultureId { get; set; }
        public string Title { get; set; }
        public string Brief { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public DateTime? UploadDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public Decimal? Score { get; set; }
        public bool? IsAnnouncement { get; set; }
        public Int64? EntryId { get; set; }
    }
}
