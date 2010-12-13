using System;
using System.Web;
using System.Web.Mvc;
using DomainModel.Entities;



namespace WebUi.Models
{
    public class AppCulture
    {

        public static ProductLanguage CurrentCulture
        {
            get
            {
                ProductLanguage culture = null;
                if (Security.CurrentUser != null && 
                    Security.CurrentUser.Profile != null)
                {
                    culture = Security.CurrentUser.Profile.Culture;
                }

                if (culture == null)
                {
                    culture = WebUi.Models.Sessions.Culture;

                    if (culture == null)
                    {
                        culture = DomainModel.Repository.Memory.Languages.Instance.Default;
                    }
                }

                return culture;
            }

            set
            {
                if (Security.CurrentUser != null && 
                    Security.CurrentUser.Profile != null)
                {
                    Security.CurrentUser.Profile.Culture = value;
                    DomainModel.Repository.Sql.Profiles.Update(Security.CurrentUser);
                }
                else
                {
                    WebUi.Models.Sessions.Culture = value;
                    if (WebUi.Models.Sessions.Errors.Count > 0)
                    {
                        DomainModel.Errors.Handler.HandleError("UNABLE TO SAVE CULTURE");
                    }
                }
            }
        }
    
    
    }
}