using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Entities
{
    public class ProductOwner
    {
        public enum OwnerTypes
        {
            Individual, 
            Company
        }


        public int OwnerId { get; set; }
        public OwnerTypes OwnerType { get; set; }
        public string OwnermName { get; set; }   // Name of the owner
    }
}
