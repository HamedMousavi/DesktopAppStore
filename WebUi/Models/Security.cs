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


        public static string UserIp
        {
            get
            {
                String _ip = string.Empty;

                try
                {
                    //System.Collections.Specialized.NameValueCollection proxies =
                    //    HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                    // Look for a proxy address first
                    try
                    {
                        _ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    }
                    catch (Exception) { }

                    // If there is no proxy, get the standard remote address
                    try
                    {
                        if (string.IsNullOrWhiteSpace(_ip) || 
                        _ip.ToLower() == "unknown")
                        _ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    }
                    catch (Exception) { }

                    // Ask .net depareately
                    if (string.IsNullOrWhiteSpace(_ip) || 
                        _ip.ToLower() == "unknown")
                        _ip = HttpContext.Current.Request.UserHostAddress;
                }
                catch (Exception)
                {
                }

                if (_ip.Length > 255)
                {
                    _ip = _ip.Substring(_ip.Length - 255, 255);
                }

                return _ip;
            }
        }
    }
}