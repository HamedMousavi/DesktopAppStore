using System;


namespace DomainModel.Entities
{
    public class ProductContact
    {
        public int Id { get; set; }
        public ContactUnit Unit { get; set; }
        public ContactMediaType MediaType { get; set; }
        public string ContactValue { get; set; }
    }
}
