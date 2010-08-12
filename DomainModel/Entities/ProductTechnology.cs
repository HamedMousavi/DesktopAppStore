using System;

namespace DomainModel.Entities
{
    public class ProductTechnology
    {
        public int      TechnologyId    { get; set; }   // Unique Id of the technology
        public string   TechnologyName  { get; set; }   // Technology like .Net, Asp, Php, etc.
    }
}
