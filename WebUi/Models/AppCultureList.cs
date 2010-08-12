using System;
using System.Collections.Generic;


// UNDONE: USE CACHE TO INCREASE PERFORMANCE.
// Only 1 instance is needed for all application


namespace WebUi.Models
{
    public class AppCultureList : List<CultureItem>
    {

        public CultureItem DefaultCulture
        {
            get
            {
                return this["Persian"];
            }
        }


        public AppCultureList()
        {
            Add(new WebUi.Models.CultureItem { Text = "Persian", Culture = "fa-IR" });
            Add(new WebUi.Models.CultureItem { Text = "English", Culture = "en-US" });
        }



        public CultureItem this[string key]
        {
            get
            {
                foreach(CultureItem item in this)
                {
                    if (item.Culture == key || item.Text == key)
                    {
                        return item;
                    }
                }

                return null;
            }
        }

    }
}