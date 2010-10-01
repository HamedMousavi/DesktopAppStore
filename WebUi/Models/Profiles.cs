using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainModel.Entities;

namespace WebUi.Models
{
    public class Profiles
    {
        // 0: User not authenticated
        // 1: Such a profile does not exist
        public static List<int> Errors = new List<int>();


        public static ProductLanguage Culture
        {
            get
            {
                Errors.Clear();

                if (HttpContext.Current.User == null)
                {
                    Errors.Add(0);
                }
                else if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    try
                    {
                        if (HttpContext.Current.Profile[WebUi.Models.SessionKeys.Culture] != null)
                        {
                            return (ProductLanguage)HttpContext.Current.Profile[WebUi.Models.SessionKeys.Culture];
                        }
                        else
                        {
                            Errors.Add(1);
                        }
                    }
                    catch (Exception)
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
                    try
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
                    catch (Exception)
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