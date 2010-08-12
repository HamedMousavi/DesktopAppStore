using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUi.Models
{
    public class Profiles
    {
        // 0: User not authenticated
        // 1: Such a profile does not exist
        public static List<int> Errors = new List<int>();


        public static CultureItem Culture
        {
            get
            {
                Errors.Clear();

                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.Profile[WebUi.Models.SessionKeys.Culture] != null)
                    {
                        return (CultureItem)HttpContext.Current.Profile[WebUi.Models.SessionKeys.Culture];
                    }
                    else
                    {
                        Errors.Add(1);
                    }
                }
                else
                {
                    Errors.Add(0);
                }

                return null;
            }

            set
            {
                Errors.Clear();

                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.Profile[WebUi.Models.SessionKeys.Culture] != null)
                    {
                        HttpContext.Current.Profile[WebUi.Models.SessionKeys.Culture] = value;
                    }
                    else
                    {
                        Errors.Add(1);
                    }
                }
                else
                {
                    Errors.Add(0);
                }
            }
        }
    }
}