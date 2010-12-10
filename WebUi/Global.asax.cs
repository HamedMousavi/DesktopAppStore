﻿using System;
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
                "Products/{productName}/Discussions/{action}/{discussion}/{message}",
                new
                {
                    controller = WebUi.ViewModels.NavigationKeys.DiscussionsController,
                    action = WebUi.ViewModels.NavigationKeys.IndexAction,
                    productName = (string)null,
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
            System.Diagnostics.Debug.WriteLine("-- Application_AuthenticateRequest -----------------------------------------------");
            try
            {
                if(string.IsNullOrWhiteSpace(FormsAuthentication.FormsCookieName)) return;
                if(Context.Request.Cookies.Count <= 0) return;
                if (Request.IsAuthenticated)
                {
                    System.Diagnostics.Debug.WriteLine("***************");/*
                    DomainModel.Security.SarvsoftUser user = 
                        Context.User as DomainModel.Security.SarvsoftUser;
                    if (user != null && user.Id > 0)*/ return;
                }

                HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null || string.IsNullOrWhiteSpace(authCookie.Value)) return;

                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket == null) return;

                DomainModel.Security.SarvsoftUser principal = new DomainModel.Security.SarvsoftUser();
                ((DomainModel.Security.SarvsoftUserIdentity)principal.Identity).Ticket = authTicket;

                if (!string.IsNullOrWhiteSpace(authTicket.UserData))
                {
                    principal.Id = Convert.ToInt64(authTicket.UserData);
                    principal.EmailAddress = principal.Identity.Name;
                }

                // Attach the new principal object to the current HttpContext object
                Context.User = principal;
                System.Threading.Thread.CurrentPrincipal = principal;
                System.Diagnostics.Debug.WriteLine("--> User loaded: -----------------------------------------------");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Exception:{0}", ex));
            }
        }
    }
}