using System;
using System.Web;
using System.Web.Mvc;



namespace WebUi.Models
{
    public class AppCulture
    {

        public static AppCultureList CultureList = new AppCultureList();


        public static CultureItem CurrentCulture
        {
            get
            {
                CultureItem culture = WebUi.Models.Profiles.Culture;

                if (culture == null)
                {
                    culture = WebUi.Models.Sessions.Culture;

                    if (culture == null)
                    {
                        culture = CultureList.DefaultCulture;
                    }
                }

                return culture;
            }

            set
            {
                WebUi.Models.Profiles.Culture = value;
                if (WebUi.Models.Profiles.Errors.Count > 0)
                {
                    WebUi.Models.Sessions.Culture = value;
                    if (WebUi.Models.Sessions.Errors.Count > 0)
                    {
                        // UNDONE: UNABLE TO SAVE CULTURE
                    }
                }
            }
        }
    
    
    }
}