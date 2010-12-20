using System;
using System.Collections.Generic;



namespace DomainModel.Entities
{
    public class ProductOwner
    {
        public Int64 UserId { get; set; }
        public ProductOwnerDetailsCollection Details { get; set; }

        public ProductOwner()
        {
            this.Details = new ProductOwnerDetailsCollection();
        }
    }
}
