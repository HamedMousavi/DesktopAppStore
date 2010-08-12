using System;
using System.Web;
using System.Collections.Generic;


namespace WebUi.Models
{
    public class Sessions
    {
        // 0: Session does not exists
        public static List<int> Errors = new List<int>();

        public static CultureItem Culture
        {
            get 
            {
                Errors.Clear();

                if (HttpContext.Current.Session[WebUi.Models.SessionKeys.Culture] != null)
                {
                    return (CultureItem)HttpContext.Current.Session[WebUi.Models.SessionKeys.Culture];
                }
                else
                {
                    Errors.Add(0);
                    return null;
                }
            }

            set
            {
                Errors.Clear();

                HttpContext.Current.Session[WebUi.Models.SessionKeys.Culture] = value;
            }
        }
    }
}