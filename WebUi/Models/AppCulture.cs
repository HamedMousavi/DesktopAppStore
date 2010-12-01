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
                ProductLanguage culture = WebUi.Models.Profiles.Culture;

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
                WebUi.Models.Profiles.Culture = value;
                if (WebUi.Models.Profiles.Errors.Count > 0)
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