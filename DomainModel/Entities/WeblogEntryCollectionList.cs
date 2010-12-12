using System;
using System.Collections.Generic;



namespace DomainModel.Entities
{
    public class WeblogEntryCollectionList : List<WeblogEntryCollection>
    {
        public WeblogEntryCollection this[string culture]
        {
            get
            {
                return FindByCulture(culture);
            }
        }

        public WeblogEntryCollection this[string culture, string url]
        {
            get
            {
                WeblogEntryCollection res = null;

                WeblogEntryCollection all = FindByCulture(culture);

                if (all != null)
                {
                    res = new WeblogEntryCollection();

                    foreach(WeblogEntry entry in all)
                    {
                        if (entry.Url.Equals(url, StringComparison.Ordinal))
                        {
                            res.Add(entry);
                        }
                    }
                }

                return res;
            }
        }


        private WeblogEntryCollection FindByCulture(string culture)
        {
            foreach (WeblogEntryCollection msgs in this)
            {
                if (msgs.CultureId.Equals(culture, StringComparison.Ordinal))
                {
                    return msgs;
                }
            }

            return null;
        }

        public delegate bool LoadEntries(WeblogEntryCollection messages, DateTime time, string culture);
        public LoadEntries LoadEntriesAction { get; set; }


        public void Remove(string culture)
        {
            WeblogEntryCollection messages;

            if (this.Count > 0)
            {
                messages = this[culture];
                if (messages != null)
                {
                    lock (this)
                    {
                        this.Remove(messages);
                    }
                }
            }
        }


        public void ReloadEntries(string culture)
        {
            // Remove old message
            Remove(culture);

            WeblogEntryCollection messages = new WeblogEntryCollection();
            messages.CultureId = culture;

            // Reload new item
            LoadEntriesAction(messages, DateTime.UtcNow, culture);

            // Add newly created messages to item list
            lock (this)
            {
                Add(messages);
            }
        }

    }
}
