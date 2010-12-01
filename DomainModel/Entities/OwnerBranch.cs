using System;




namespace DomainModel.Entities
{
    public class OwnerBranch
    {
        public ProductLanguage Language { get; set; }
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public bool IsMainBranch { get; set; }
        public Address Address { get; set; }


        public OwnerBranch()
        {
            this.Address = new Address();
        }
    }
}
