using System.Web.Routing;
using System.Web;


namespace WebUi
{
    public class ChromeAgentConst : IRouteConstraint
    {
        protected string requiredSubstring;
        public ChromeAgentConst(string requiredSubstring)
        {
            this.requiredSubstring = requiredSubstring;
        }


        #region IRouteConstraint Members

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (httpContext.Request.UserAgent == null) return false;
            
            return httpContext.Request.UserAgent.Contains(this.requiredSubstring);
        }

        #endregion
    }
}