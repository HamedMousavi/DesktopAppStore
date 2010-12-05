using System;
using System.Collections.Generic;



namespace DomainModel.Repository.Memory
{
    public class ProductList
    {
        public Dictionary<int, string> SortOptions { get; private set; }


        protected static ProductList instance;
        protected static object instLock = new object();
        public static ProductList Instance
        {
            get
            {
                lock (instLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductList();
                    }
                }

                return instance;
            }
        }


        public ProductList()
        {
            this.SortOptions = new Dictionary<int, string>();

            this.SortOptions.Add(1, "product_list_sort_price");
            this.SortOptions.Add(2, "product_list_sort_price_desc");
            this.SortOptions.Add(3, "product_list_sort_release");
            this.SortOptions.Add(4, "product_list_sort_release_desc");
            this.SortOptions.Add(5, "product_list_sort_popularity");
            //this.SortOptions.Add(6, "product_list_sort_features");
            //this.SortOptions.Add(7, "product_list_editor_rating");
            this.SortOptions.Add(8, "product_list_user_rating");
        }
    }
}
