using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUi.Controllers
{
    public class BaseController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            string cuture = WebUi.Models.AppCulture.CurrentCulture.Culture;

            if (System.Threading.Thread.CurrentThread.CurrentCulture.Name != cuture)
            {
                // Update thread culture
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cuture);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cuture);
            }

            base.Initialize(requestContext);
        }
    }
}