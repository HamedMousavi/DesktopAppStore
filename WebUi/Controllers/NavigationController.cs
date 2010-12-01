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
    }
}
