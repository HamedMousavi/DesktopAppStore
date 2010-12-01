using System;
using System.Collections.Generic;
using DomainModel.Entities;



namespace DomainModel.Repository.Memory
{
    public class Categories
    {
        protected CategoryParentCollection items;
        public CategoryParentCollection Items 
        { 
            get
            {
                if (this.items != null && this.items.LastLoad != null)
                {
                    if ((DateTime.UtcNow - this.items.LastLoad.Value).Minutes >=
                        Configurations.MinCategoryFetchInterval)
                    {
                        ReloadAll();
                    }
                }

                return this.items;
            }
        }


        public void ReloadAll()
        {
            this.items.Clear();
            foreach (Entities.ProductLanguage lang in Languages.Instance.Items)
            {
                Load(lang.CultureId);
            }
        }
        
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
            this.items = new CategoryParentCollection();
        }


        public bool Load(string culture)
        {
            bool ret = false;

            CategoryParent cat = new CategoryParent();
            cat.Language.CultureId = culture;

            Repository.Sql.Categories.Load(culture, cat);

            this.Items.Add(cat);
            this.items.LastLoad = DateTime.UtcNow;

            ret = true;

            return ret;
        }
    }
}
