using System;



namespace DomainModel.Entities
{
    public class Category
    {
        public Int32 CategoryId { get; set; }
        public string CategoryName { get; set; }
        public CategoryCollection SubCategories { get; set; }


        public Category()
        {
            this.SubCategories = new CategoryCollection();
        }


        public Category(Int32 categoryId, string categoryName)
            : this()
        {
            this.CategoryId = categoryId;
            this.CategoryName = categoryName;
        }
    }
}
