using System;
using System.Web;
using System.Collections.Generic;
using DomainModel.Entities;


namespace WebUi.Models
{
    public class Sessions
    {
        // 0: Session does not exists
        public static List<int> Errors = new List<int>();

        public static ProductLanguage Culture
        {
            get 
            {
                Errors.Clear();

                if (HttpContext.Current.Session != null &&
                    HttpContext.Current.Session[WebUi.Models.SessionKeys.Culture] != null)
                {
                    return (ProductLanguage)HttpContext.Current.Session[WebUi.Models.SessionKeys.Culture];
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