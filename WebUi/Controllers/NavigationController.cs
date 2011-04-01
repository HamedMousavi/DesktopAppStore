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


        public ActionResult SiteSections(string subSection)
        {
            //string action = ControllerContext.ParentActionViewContext.RouteData.Values["action"].ToString();
            string section = ControllerContext.ParentActionViewContext.RouteData.Values["controller"].ToString();

            WebUi.ViewModels.SectionInfo info = new ViewModels.SectionInfo();
            info.Section = section;
            info.SubSection = subSection;

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

            info.Menu.Add(new WebUi.ViewModels.SectionLinkInfo(
                WebUi.ViewModels.NavigationKeys.WeblogController,
                WebUi.ViewModels.NavigationKeys.IndexAction,
                UiResources.UiTexts.announcements,
                "Weblog"));

            return View("SectionTabBar", info);
        }
    }


}
