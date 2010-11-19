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

        // UNDONE:
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
                        if (string.Compare(entry.Url, url) == 0)
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
                if (msgs.CultureId == culture)
                {
                    return msgs;
                }
            }

            return null;
        }
    }
}
