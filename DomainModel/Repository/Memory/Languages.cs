using System;
using System.Collections.Generic;
using DomainModel.Entities;



namespace DomainModel.Repository.Memory
{
    public class Languages
    {
        public ProductLanguageCollection Items { get; set; }

        protected static Languages instance;
        protected static object instLock = new object();


        public static Languages Instance
        {
            get
            {
                lock (instLock)
                {
                    if (instance == null)
                    {
                        instance = new Languages();
                    }
                }

                return instance;
            }
        }


        public Languages()
        {
            this.Items = new ProductLanguageCollection();
        }


        public bool Load()
        {
            bool ret = false;

            try
            {
                Repository.Sql.Languages.Load(this.Items);

                ret = true;
            }
            catch (Exception ex)
            {
                // UNDONE:
            }

            return ret;
        }


        public ProductLanguage Default
        {
            get
            {
                return this.Items["Persian"];
            }
        }
    }
}
