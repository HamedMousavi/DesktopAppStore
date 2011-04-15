using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace WebUi.Controllers
{
    public class NavigationController : BaseController
    {
        // Parameters are provided by routing mechanism if an item is selected from left menu
        public ActionResult ProductCategories(string category, string subcategory, int? page, int? sort)
        {
            if (!DomainModel.Security.InputController.IsValid(category) ||
                !DomainModel.Security.InputController.IsValid(subcategory))
            {
                return RedirectToAction(
                    WebUi.ViewModels.NavigationKeys.SecurityBadInputAction,
                    WebUi.ViewModels.NavigationKeys.SecurityController);
            }

            if (page == null || !page.HasValue) page = 1;
            if (sort == null || !sort.HasValue) sort = 1;


            WebUi.ViewModels.CurrentListItem current = new ViewModels.CurrentListItem();
            current.Category = category;
            current.Subcategory = subcategory;
            
            WebUi.ViewModels.ListingInfo inf = new ViewModels.ListingInfo();
            inf.CurrentItem = current;
            inf.CurrentPage = 1;
            inf.CurrentSortOption = sort.Value;

            // UNDONE: If clicked on the same subcategory don't change anything

            ViewData[WebUi.ViewModels.ViewDataKeys.HighlightedProductCategoryMenuItem] = inf;

            return View();
        }


        public ActionResult SiteSections()
        {
            //string action = ControllerContext.ParentActionViewContext.RouteData.Values["action"].ToString();
            string section = ControllerContext.ParentActionViewContext.RouteData.Values["controller"].ToString();

            WebUi.ViewModels.SectionInfo info = new ViewModels.SectionInfo();
            info.Section = section;

            info.Menu = new
                List<WebUi.ViewModels.SectionLinkInfo>();

            info.Menu.Add(new WebUi.ViewModels.SectionLinkInfo(
                WebUi.ViewModels.NavigationKeys.HomeController,
                WebUi.ViewModels.NavigationKeys.IndexAction,
                UiResources.UiTexts.title_index,
                "Home"));

            info.Menu.Add(new WebUi.ViewModels.SectionLinkInfo(
                WebUi.ViewModels.NavigationKeys.DesktopController,
                WebUi.ViewModels.NavigationKeys.IndexAction,
                UiResources.UiTexts.desktop,
                "Desktop"));
            /*
            info.Menu.Add(new WebUi.ViewModels.SectionLinkInfo(
                WebUi.ViewModels.NavigationKeys.WebsiteController,
                WebUi.ViewModels.NavigationKeys.IndexAction,
                UiResources.UiTexts.website,
                "Website"));

            info.Menu.Add(new WebUi.ViewModels.SectionLinkInfo(
                WebUi.ViewModels.NavigationKeys.MobileController,
                WebUi.ViewModels.NavigationKeys.IndexAction,
                UiResources.UiTexts.mobile,
                "Mobile"));
            */
            info.Menu.Add(new WebUi.ViewModels.SectionLinkInfo(
                WebUi.ViewModels.NavigationKeys.MemberController,
                WebUi.ViewModels.NavigationKeys.IndexAction,
                UiResources.UiTexts.members,
                "Members"));
            /*
            info.Menu.Add(new WebUi.ViewModels.SectionLinkInfo(
                WebUi.ViewModels.NavigationKeys.ManufactorersController,
                WebUi.ViewModels.NavigationKeys.IndexAction,
                UiResources.UiTexts.manufactorers,
                "Manufactorers"));

            info.Menu.Add(new WebUi.ViewModels.SectionLinkInfo(
                WebUi.ViewModels.NavigationKeys.JobsController,
                WebUi.ViewModels.NavigationKeys.IndexAction,
                UiResources.UiTexts.jobs,
                "Jobs"));
            */
            info.Menu.Add(new WebUi.ViewModels.SectionLinkInfo(
                WebUi.ViewModels.NavigationKeys.WeblogController,
                WebUi.ViewModels.NavigationKeys.IndexAction,
                UiResources.UiTexts.announcements,
                "Weblog"));

            return View("SectionTabBar", info);
        }


        public ActionResult DesktopSections()
        {
            string controller = string.Empty;
            string sort = string.Empty;
            string category = string.Empty;
            string subcategory = string.Empty;

            try
            {
                controller  = ControllerContext.ParentActionViewContext.RouteData.Values["controller"].ToString();
                sort        = ControllerContext.ParentActionViewContext.RouteData.Values["sort"].ToString();
                category    = ControllerContext.ParentActionViewContext.RouteData.Values["category"].ToString();
                subcategory = ControllerContext.ParentActionViewContext.RouteData.Values["subcategory"].ToString();
            }
            catch (Exception ex)
            {
            }


            WebUi.ViewModels.SectionInfo info = new ViewModels.SectionInfo();
            info.Section = sort;
            info.Menu = new
                List<WebUi.ViewModels.SectionLinkInfo>();

            foreach (KeyValuePair<int, string> sortOption in DomainModel.Repository.Memory.ProductList.Instance.SortOptions)
            {
                string section = Convert.ToString(sortOption.Key);
                string text = WebUi.Models.DynamicResources.GetText(sortOption.Value);

                info.Menu.Add(new WebUi.ViewModels.SectionLinkInfo(
                    controller,
                    "List",
                    new { category = category, subcategory = subcategory, page = "1", sort = section },
                    text,
                    section));
            }

            return View("SectionTabBar", info);
        }


        public ActionResult ProductSections()
        {
            string productName = ControllerContext.ParentActionViewContext.
                RouteData.Values["productName"].ToString();

            string action = ControllerContext.ParentActionViewContext.
                RouteData.Values["action"].ToString();

            WebUi.ViewModels.SectionInfo info = new ViewModels.SectionInfo();
            info.Section = action;

            info.Menu = new
                List<WebUi.ViewModels.SectionLinkInfo>();

            info.Menu.Add(new WebUi.ViewModels.SectionLinkInfo(
                WebUi.ViewModels.NavigationKeys.DesktopController,
                WebUi.ViewModels.NavigationKeys.ProductCatalogAction,
                new { productName = productName },
                UiResources.UiTexts.specification,
                WebUi.ViewModels.NavigationKeys.ProductCatalogAction));

            info.Menu.Add(new WebUi.ViewModels.SectionLinkInfo(
                WebUi.ViewModels.NavigationKeys.DesktopController,
                WebUi.ViewModels.NavigationKeys.ProductScreenshotsAction,
                new { productName = productName, imageIndex = 1},
                UiResources.UiTexts.screenshots,
                WebUi.ViewModels.NavigationKeys.ProductScreenshotsAction));

            return View("SectionTabBar", info);
        }


        public ActionResult MembersSections()
        {
            string action = ControllerContext.ParentActionViewContext.
                RouteData.Values["action"].ToString();

            WebUi.ViewModels.SectionInfo info = new ViewModels.SectionInfo();
            info.Section = action;

            info.Menu = new
                List<WebUi.ViewModels.SectionLinkInfo>();

            if (WebUi.Models.Security.CurrentUser == null)
            {

                info.Menu.Add(new WebUi.ViewModels.SectionLinkInfo(
                    WebUi.ViewModels.NavigationKeys.MemberController,
                    WebUi.ViewModels.NavigationKeys.MemberLogonAction,
                    UiResources.UiTexts.log_on,
                    WebUi.ViewModels.NavigationKeys.MemberLogonAction));

                info.Menu.Add(new WebUi.ViewModels.SectionLinkInfo(
                    WebUi.ViewModels.NavigationKeys.MemberController,
                    WebUi.ViewModels.NavigationKeys.MemberRegisterAction,
                    UiResources.UiTexts.registration,
                    WebUi.ViewModels.NavigationKeys.MemberRegisterAction));

                info.Menu.Add(new WebUi.ViewModels.SectionLinkInfo(
                    WebUi.ViewModels.NavigationKeys.MemberController,
                    WebUi.ViewModels.NavigationKeys.MemberResetPasswordAction,
                    UiResources.UiTexts.password_recovery_wizard,
                    WebUi.ViewModels.NavigationKeys.MemberResetPasswordAction));
            }
            else
            {
                info.Menu.Add(new WebUi.ViewModels.SectionLinkInfo(
                    WebUi.ViewModels.NavigationKeys.MemberController,
                    WebUi.ViewModels.NavigationKeys.MemberWelcomeAction,
                    UiResources.UiTexts.title_welcome,
                    WebUi.ViewModels.NavigationKeys.MemberWelcomeAction));

                info.Menu.Add(new WebUi.ViewModels.SectionLinkInfo(
                    WebUi.ViewModels.NavigationKeys.MemberController,
                    WebUi.ViewModels.NavigationKeys.MemberSettingsAction,
                    UiResources.UiTexts.title_settings,
                    WebUi.ViewModels.NavigationKeys.MemberSettingsAction));

                info.Menu.Add(new WebUi.ViewModels.SectionLinkInfo(
                    WebUi.ViewModels.NavigationKeys.MemberController,
                    WebUi.ViewModels.NavigationKeys.MemberProfileAction,
                    UiResources.UiTexts.title_profile,
                    WebUi.ViewModels.NavigationKeys.MemberProfileAction));
            }

            return View("SectionTabBar", info);
        }
    }


}
