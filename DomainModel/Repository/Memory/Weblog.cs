using System;
using DomainModel.Entities;
using System.Collections.Generic;




namespace DomainModel.Repository.Memory
{
    public class Weblog
    {
        protected static Weblog instance;
        protected static object instLock = new object();

        protected WeblogEntryCollectionList items;
        protected WeblogEntryCollectionList featured;
        protected WeblogEntryCollectionList announcements;



        protected readonly int MinDatabaseFetchInterval = 
            Convert.ToInt32(Configurations.MinMessageFetchInterval);
        

        public static Weblog Instance
        {
            get
            {
                lock (instLock)
                {
                    if (instance == null)
                    {
                        instance = new Weblog();
                    }
                }

                return instance;
            }
        }


        public Weblog()
        {
            this.items = new WeblogEntryCollectionList();
            this.items.LoadEntriesAction = Repository.Sql.Weblog.Load;

            this.featured = new WeblogEntryCollectionList();
            this.featured.LoadEntriesAction = Repository.Sql.Weblog.LoadFeatured;

            this.announcements = new WeblogEntryCollectionList();
            this.announcements.LoadEntriesAction = Repository.Sql.Weblog.LoadAnnouncements;
        }


        public WeblogEntryCollection GetEntries(WeblogEntryCollectionList list, string cultureId)
        {
            WeblogEntryCollection messages = list[cultureId];

            if (messages == null)
            {
                list.ReloadEntries(cultureId);
                messages = list[cultureId];
            }
            else if (
                messages.ExpirationDate > DateTime.UtcNow ||
                messages.Count <= 0)
            {
                if (messages.LastLoad != null)
                {
                    if ((DateTime.UtcNow - messages.LastLoad.Value).Minutes <
                        MinDatabaseFetchInterval)
                    {
                        return messages;
                    }
                }

                list.ReloadEntries(cultureId);
                messages = list[cultureId];
            }

            return messages;
        }


        public void Reload(string cultureId)
        {
            // Remove old message
            this.items.ReloadEntries(cultureId);
        }


        public WeblogEntryCollection GetMessages(string cultureId)
        {
            return GetEntries(this.items, cultureId);
        }


        public WeblogEntryCollection GetMessages(string cultureId, string url)
        {
            WeblogEntryCollection messages = this.items[cultureId, url];

            if (messages == null)
            {
                messages = new WeblogEntryCollection();
                Repository.Sql.Weblog.GetMessages(cultureId, url, messages);
                this.items.Add(messages);
            }

            return messages;
        }


        public WeblogEntryCollection GetFeatured(string cultureId)
        {
            return GetEntries(this.featured, cultureId);
        }


        public WeblogEntryCollection GetAnnouncements(string cultureId)
        {
            return GetEntries(this.announcements, cultureId);
        }
    }
}
