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

            // /Culture?SelectedCulture=...&ReturnUrl=...
            routes.MapRoute(
                null,
                "Culture",
                new { controller = "Culture", action = "Index" }
            );

            // /Products/Yaas/Home
            routes.MapRoute(null,
                "Products/{productName}/Home", // Matches ~/Football or ~/AnythingWithNoSlash
                new { controller = "Products", action = "Details", productName = (string)null }
            );

            // /Products/Yaas/Catalog
            routes.MapRoute(null,
                "Products/{productName}/Catalog", // Matches ~/Football or ~/AnythingWithNoSlash
                new { controller = "Products", action = "Details", productName = (string)null }
            );


            // /Products/Medical/EMR
            // /Products/Medical
            // /Products
            routes.MapRoute(null,
                "Products/{category}/{subcategory}", // Matches ~/Football or ~/AnythingWithNoSlash
                new { controller = "Products", action = "List", category = (string)null, subcategory = (string)null, page=1 }
            );

            // /Homde
            routes.MapRoute(
                null,
                "",
                new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                null,
                "{controller}/{action}",
                new { controller = "Home", action = "Index" }
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
            try
            {
                AreaRegistration.RegisterAllAreas();

                RegisterRoutes(RouteTable.Routes);
                // RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);

                // Load application languages
                DomainModel.Repository.Memory.Languages.Instance.Load();

                // Load application product categories
                // DomainModel.Repository.Memory.Categories.Instance.Load(WebUi.Models.AppCulture.CurrentCulture.CultureId);
                foreach (DomainModel.Entities.ProductLanguage lang in DomainModel.Repository.Memory.Languages.Instance.Items)
                {
                    DomainModel.Repository.Memory.Categories.Instance.Load(lang.CultureId);
                }
            }
            catch (Exception ex)
            {
                // UNDONE: DAMN EXCEPTION IN HERE? NOW WHAT?!
            }
        }

    }
}