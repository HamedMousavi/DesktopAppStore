using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUi.Controllers
{
    public class BaseController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            string culture = WebUi.Models.AppCulture.CurrentCulture.CultureId;

            if (System.Threading.Thread.CurrentThread.CurrentCulture.Name != culture)
            {
                // Update thread culture
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
            }

            base.Initialize(requestContext);
        }
    }
}