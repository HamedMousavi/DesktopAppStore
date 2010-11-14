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
                new 
                {
                    controller = WebUi.ViewModels.NavigationKeys.CultureController,
                    action = WebUi.ViewModels.NavigationKeys.IndexAction,
                }
            );

            // /Products/Yaas
            routes.MapRoute(null,
                "Products/{productName}",
                new
                {
                    controller = WebUi.ViewModels.NavigationKeys.ProductController,
                    action = WebUi.ViewModels.NavigationKeys.ProductCatalogAction,
                    productName = (string)null
                }
            );

            // /Products/Yaas/Screenshots
            routes.MapRoute(null,
                "Products/{productName}/Screenshots/{imageIndex}",
                new
                {
                    controller = WebUi.ViewModels.NavigationKeys.ProductController,
                    action = WebUi.ViewModels.NavigationKeys.ProductScreenshotsAction,
                    productName = (string)null,
                    imageIndex = 1
                }
            );

            // /Products/Yaas/Screenshots
            routes.MapRoute(null,
                "Products/{productName}/Awards",
                new
                {
                    controller = WebUi.ViewModels.NavigationKeys.ProductController,
                    action = WebUi.ViewModels.NavigationKeys.ProductAwardsAction,
                    productName = (string)null
                }
            );


            // /Products/Medical/EMR
            // /Products/Medical
            // /Products
            routes.MapRoute(null,
                "Products/List/{category}/{subcategory}", // Matches ~/Football or ~/AnythingWithNoSlash
                new 
                {
                    controller = WebUi.ViewModels.NavigationKeys.ProductController,
                    action = WebUi.ViewModels.NavigationKeys.ProductListAction,
                    category = (string)null, subcategory = (string)null, page=1 }
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
                DomainModel.Errors.Handler.HandleException(ex);
            }
        }

    }
}