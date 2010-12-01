using System;
using System.Web;



namespace WebUi.Models
{
    public class Security
    {
        public static Int64? UserId
        {
            get
            {
                Int64? userId = null;

                try
                {
                    if (HttpContext.Current.Request.IsAuthenticated &&
                        !string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                    {
                        userId = Convert.ToInt64(HttpContext.Current.User.Identity.Name);
                    }
                }
                catch (Exception)
                {
                }

                return userId;
            }
        }
    }
}