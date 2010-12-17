using System;
using System.Collections.Generic;



namespace DomainModel.Entities
{
    public class ProductOwnerDetails
    {
        public ProductLanguage Language { get; set; }
        public string DisplayName { get; set; }
        public List<OwnerBranch> Branches { get; set; }
        public DateTime? LastLoaded { get; set; }
    }
}
