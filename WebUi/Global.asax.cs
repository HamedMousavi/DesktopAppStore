using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

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

            // /Products/Sarv/Discussions/1/1
            routes.MapRoute(null,
                "Discussions/{action}/{group}/{forum}/{discussion}/{message}",
                new
                {
                    controller = WebUi.ViewModels.NavigationKeys.DiscussionsController,
                    action = WebUi.ViewModels.NavigationKeys.IndexAction,
                    group = (Int16?)null,
                    forum = (Int64?)null,
                    discussion = (Int32?)null,
                    message = (Int32?)null
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


            // /Products/Medical/EMR/page1/sort1
            routes.MapRoute(null,
                "Products/List/{category}/{subcategory}/Page{page}/Sort{sort}",
                new
                {
                    controller = WebUi.ViewModels.NavigationKeys.ProductController,
                    action = WebUi.ViewModels.NavigationKeys.ProductListAction,
                    category = (string)null,
                    subcategory = (string)null,
                    page = 1,
                    sort = 1
                }
            );


            // /Products/Medical/EMR
            // /Products/Medical
            // /Products
            routes.MapRoute(null,
                "Products/List/{category}/Page{page}/Sort{sort}",
                new
                {
                    controller = WebUi.ViewModels.NavigationKeys.ProductController,
                    action = WebUi.ViewModels.NavigationKeys.ProductListAction,
                    section = (string)null,
                    category = (string)null,
                    subcategory = (string)null,
                    page = 1,
                    sort = 1
                }
            );


            routes.MapRoute(null,
                "Products/Tags/{tagId}/Page{page}/Sort{sort}",
                new
                {
                    controller = WebUi.ViewModels.NavigationKeys.ProductController,
                    action = WebUi.ViewModels.NavigationKeys.SearchTagAction,
                    tagId = (Int32?)null,
                    page = 1,
                    sort = 1
                }
            );


            routes.MapRoute(null,
                "Members/Profile/{user}",
                new
                {
                    controller = WebUi.ViewModels.NavigationKeys.MemberController,
                    action = WebUi.ViewModels.NavigationKeys.MemberProfileAction,
                    user = (Int64?)null
                }
            );


            routes.MapRoute(null,
                "Members/Settings/{user}",
                new
                {
                    controller = WebUi.ViewModels.NavigationKeys.MemberController,
                    action = WebUi.ViewModels.NavigationKeys.MemberSettingsAction,
                    user = (Int64?)null
                }
            );


            // /Messages/...
            routes.MapRoute(null,
                "Weblog/{url}",
                new 
                {
                    controller = WebUi.ViewModels.NavigationKeys.WeblogController,
                    action = WebUi.ViewModels.NavigationKeys.IndexAction,
                    url = (string)null
                }
            );
            
            // /Homde
            routes.MapRoute(
                null,
                "",
                new 
                {
                    controller = WebUi.ViewModels.NavigationKeys.HomeController,
                    action = WebUi.ViewModels.NavigationKeys.IndexAction,
                    section = "Home",
                    subSection = "Index"                
                }
            );

            // /Products/Yaas/Screenshots
            routes.MapRoute(null,
                "{controller}/{productName}/Screenshots/{imageIndex}",
                new
                {
                    controller = WebUi.ViewModels.NavigationKeys.DesktopController,
                    action = WebUi.ViewModels.NavigationKeys.ProductScreenshotsAction,
                    productName = (string)null,
                    imageIndex = 1
                }
            );


            // /Desktop/Yaas
            routes.MapRoute(null,
                "{controller}/{productName}/Catalog",
                new
                {
                    controller = WebUi.ViewModels.NavigationKeys.DesktopController,
                    action = WebUi.ViewModels.NavigationKeys.ProductCatalogAction,
                    productName = (string)null
                }
            );

            // /Desktop/Medical/EMR/Page1/Sort1
            routes.MapRoute(
                null,
                "{controller}/{action}/{category}/{subcategory}/Page{page}/Sort{sort}",
                new 
                { 
                    controller = WebUi.ViewModels.NavigationKeys.HomeController, 
                    action = WebUi.ViewModels.NavigationKeys.IndexAction, // List action?
                    category = (string)null,
                    subcategory = (string)null,
                    page = 1,
                    sort = 1
                }
            );


            // /Products/Medical/EMR
            // /Products/Medical
            // /Products
            routes.MapRoute(null,
                "{controller}/{action}/{category}/Page{page}/Sort{sort}",
                new
                {
                    controller = WebUi.ViewModels.NavigationKeys.HomeController,
                    action = WebUi.ViewModels.NavigationKeys.IndexAction,
                    section = (string)null,
                    category = (string)null,
                    subcategory = (string)null,
                    page = 1,
                    sort = 1
                }
            );

            // /Desktop/Page1/Sort1
            routes.MapRoute(
                null,
                "{controller}/{action}/Page{page}/Sort{sort}",
                new 
                { 
                    controller = WebUi.ViewModels.NavigationKeys.HomeController, 
                    action = WebUi.ViewModels.NavigationKeys.IndexAction, // List action?
                    page = 1,
                    sort = 1
                }
            );

            routes.MapRoute(
                null,
                "{controller}/{action}",
                new 
                { 
                    controller = WebUi.ViewModels.NavigationKeys.HomeController, 
                    action = WebUi.ViewModels.NavigationKeys.IndexAction  
                }
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
                DomainModel.Repository.Memory.Categories.Instance.ReloadAll();

                foreach (DomainModel.Entities.ProductLanguage lang in 
                    DomainModel.Repository.Memory.Languages.Instance.Items)
                {
                    DomainModel.Repository.Memory.Categories.Instance.Load(lang.CultureId);
                    DomainModel.Repository.Memory.Weblog.Instance.Reload(lang.CultureId);
                }
            }
            catch (Exception ex)
            {
                DomainModel.Errors.Handler.HandleException(ex);
            }
        }

        // Have you noticed how beautiful is "Jessica Jane Clement"?
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            DomainModel.Membership.MembershipService.AuthenticateRequest(Context, Request);
        }


        protected void Session_Start(object sender, EventArgs e)
        {
            DomainModel.Repository.Memory.Statistics.Instance.OnlineUserCount++;
        }


        protected void Session_End(object sender, EventArgs e)
        {
            DomainModel.Repository.Memory.Statistics.Instance.OnlineUserCount--;
        }


        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            HttpException httpEx = ex as HttpException;
            if (httpEx != null)
            {
                // Try to redirect an inexistent .aspx page to a probably existing .ashx page
                if (httpEx.GetHttpCode() == 404)
                {
                    string page = System.IO.Path.GetFileNameWithoutExtension(Request.PhysicalPath);
                    HttpContext.Current.Response.Redirect("/Errors/NotFound", true);
                    return;
                }
            }

            string url = "";
            try
            {
                url = HttpContext.Current.Request.Url.ToString();
            }
            catch { }

            DomainModel.Errors.Logger.LogException(
                WebUi.Models.Security.CurrentUser.Id.ToString(),
                WebUi.Models.AppCulture.CurrentCulture.CultureId,
                WebUi.Models.Security.UserIp,
                url,
                ex);

            if (!Request.PhysicalPath.ToLowerInvariant().Contains("Exception"))
            {
                HttpContext.Current.Response.Redirect("Errors/Exception", true);
            }
        }
    }
}