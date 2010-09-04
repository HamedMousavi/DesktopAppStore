using System;



namespace DomainModel.Entities
{
    // None, Daily unlimited features, Limited features unlimited time
    public class ProductDemoOption : ProductOptionBase
    {
        public int Limitation { get; set; }
    }
}
