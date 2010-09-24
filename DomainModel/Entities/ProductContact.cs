using System;


namespace DomainModel.Entities
{
    public class ProductContact
    {
        public Int64? Id { get; set; }
        public ContactUnit Unit { get; set; }
        public ContactMediaType MediaType { get; set; }
        public string ContactValue { get; set; }
        public string ContactPerson { get; set; }


        public ProductContact()
        {
            this.Id = null;
            this.Unit = new ContactUnit();
            this.MediaType = new ContactMediaType();
        }


        public void Copy(ProductContact productContact)
        {
            this.Id = productContact.Id;
            this.Unit.Id = productContact.Unit.Id;
            this.Unit.Name = productContact.Unit.Name;
            this.MediaType.Id = productContact.MediaType.Id;
            this.MediaType.Name = productContact.MediaType.Name;
            this.ContactPerson = productContact.ContactPerson;
            this.ContactValue = productContact.ContactValue;
        }
    }
}
