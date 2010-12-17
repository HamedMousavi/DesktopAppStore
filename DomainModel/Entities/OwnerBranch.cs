using System;
using System.Collections.Generic;




namespace DomainModel.Entities
{
    public class OwnerBranch
    {
        public ProductOwnerDetails Owner { get; set; }
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public bool IsMainBranch { get; set; }
        public Address Address { get; set; }
        public List<ProductContact> Contacts { get; set; }


        public OwnerBranch()
        {
            this.Address = new Address();
            this.Contacts = new List<ProductContact>();
        }


    }
}
