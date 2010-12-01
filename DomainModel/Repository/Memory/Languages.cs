using System;
using System.Collections.Generic;
using DomainModel.Entities;



namespace DomainModel.Repository.Memory
{
    public class Languages
    {
        public ProductLanguageCollection Items { get; set; }

        private static Languages instance;
        private static object instLock = new object();


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

            Repository.Sql.Languages.Load(this.Items);

            ret = true;

            return ret;
        }


        public ProductLanguage Default
        {
            get
            {
                string defaultLang =
                    System.Web.Configuration.WebConfigurationManager.AppSettings["DefaultWebsiteLanguage"];
                return this.Items[defaultLang];
            }
        }
    }
}
