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
        }


        public WeblogEntryCollection GetMessages(string cultureId)
        {
            WeblogEntryCollection messages = this.items[cultureId];

            if (messages == null)
            {
                Reload(cultureId);
                messages = this.items[cultureId];
            }
            else if (
                messages.ExpirationDate > DateTime.Now ||
                messages.Count <= 0)
            {
                if (messages.LastLoad != null)
                {
                    if ((DateTime.Now - messages.LastLoad.Value).Minutes < 
                        MinDatabaseFetchInterval)
                    {
                        return messages;
                    }
                }

                Reload(cultureId);
                messages = this.items[cultureId];
            }

            return messages;
        }


        public void Reload(string cultureId)
        {
            WeblogEntryCollection messages = CreateMessageList(cultureId);

            // Reload new item
            lock (messages)
            {
                Repository.Sql.Weblog.Load(messages, DateTime.Now, cultureId);
            }

            // Add newly created messages to item list
            lock (this.items)
            {
                this.items.Add(messages);
            }
        }


        private WeblogEntryCollection CreateMessageList(string cultureId)
        {
            WeblogEntryCollection messages;

            // Remove old message
            if (this.items.Count > 0)
            {
                messages = this.items[cultureId];
                if (messages != null)
                {
                    lock (this.items)
                    {
                        this.items.Remove(messages);
                    }
                }
            }            

            // Create a new message collection
            messages = new WeblogEntryCollection();
            messages.CultureId = cultureId;

            return messages;
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
    }
}
