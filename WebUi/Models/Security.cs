using System;
using System.Web;



namespace WebUi.Models
{
    public class Security
    {
        public static DomainModel.Abstract.IUser CurrentUser
        {
            get
            {
                return HttpContext.Current.User as DomainModel.Abstract.IUser;
            }
        }

        public static Int64? UserId
        {
            get
            {
                Int64? userId = null;

                try
                {
                    if (HttpContext.Current.Request.IsAuthenticated)
                    {
                        DomainModel.Abstract.IUser user =
                            ((DomainModel.Membership.SarvsoftPrincipal)HttpContext.Current.User).Owner;

                        if (user != null && user.Id > 0) userId = user.Id;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Exception:{0}", ex));
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
                    catch (Exception ex) 
                    {
                        System.Diagnostics.Debug.WriteLine(string.Format("Exception:{0}", ex));
                    }

                    // If there is no proxy, get the standard remote address
                    try
                    {
                        if (string.IsNullOrWhiteSpace(_ip) || 
                        _ip.ToLower() == "unknown")
                        _ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(string.Format("Exception:{0}", ex));
                    }

                    // Ask .net depareately
                    if (string.IsNullOrWhiteSpace(_ip) || 
                        _ip.ToLower() == "unknown")
                        _ip = HttpContext.Current.Request.UserHostAddress;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Exception:{0}", ex));
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