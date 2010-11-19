using System;
using System.Collections.Generic;


namespace DomainModel.Entities
{
    public class WeblogEntryCollection : List<WeblogEntry>
    {
        public string CultureId { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? LastLoad { get; set; }

        public WeblogEntryCollection()
        {
            this.LastLoad = null;
            this.ExpirationDate = null;
        }
    }
}
