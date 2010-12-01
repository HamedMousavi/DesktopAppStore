using System;
using System.Collections.Generic;



namespace DomainModel.Entities
{
    public class ProductOwner
    {
        public int OwnerId { get; set; }
        public DomainModel.Repository.Memory.Owners.Types OwnerType { get; set; }

        public List<OwnerBranch> Branches { get; set; }


        public ProductOwner()
        {
            this.Branches = new List<OwnerBranch>();
            this.OwnerType = Repository.Memory.Owners.Types.Unknown;
        }
    }
}
