using System;




namespace DomainModel.Entities
{
    // None, Years, Monts, Days, On demand(Contract), other
    public class ProductGuarantyOption : ProductOptionBase
    {
        public int Limitation { get; set; }
    }
}
