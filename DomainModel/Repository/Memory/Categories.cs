using System;
using System.Collections.Generic;
using DomainModel.Entities;



namespace DomainModel.Repository.Memory
{
    public class Categories
    {
        public CategoryParentCollection Items { get; set; }
        
        protected static Categories instance;
        protected static object instLock = new object();



        public static Categories Instance
        {
            get
            {
                lock (instLock)
                {
                    if (instance == null)
                    {
                        instance = new Categories();
                    }
                }

                return instance;
            }
        }



        public Categories()
        {
            this.Items = new CategoryParentCollection();
        }


        public bool Load(string culture)
        {
            bool ret = false;

            CategoryParent cat = new CategoryParent();
            cat.Language.CultureId = culture;

            Repository.Sql.Categories.Load(culture, cat);

            this.Items.Add(cat);

            ret = true;

            return ret;
        }




    }
}
