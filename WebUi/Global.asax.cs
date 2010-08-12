using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUi
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null,
                "Culture",
                new { controller = "Culture", action = "Index" }
            );

            routes.MapRoute(
                null,
                "",
                new { controller = "Home", action = "Index"}
            );

            routes.MapRoute(
                null,
                "{controller}/{action}",
                new { controller = "Home", action = "Index"}
            );

/*
            routes.MapRoute(
                null,
                "Articles/{*articlePath}",
                new { controller = "Home", action = "Article" }
                );

            routes.MapRoute(
                null,
                "",
                new { controller = "Home", action = "Index"},
                new { userAgent = new WebUi.ChromeAgentConst("Chrome") }
                );

            routes.MapRoute(
                null,
                "r",
                new { controller = "Home", action = "Redirect" }
                );
            */
        }



        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }

    }
}