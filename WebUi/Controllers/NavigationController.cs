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
        public ViewResult ProductCategories(string category, string subcategory)
        {
            if (!DomainModel.Security.InputController.IsValid(category) ||
                !DomainModel.Security.InputController.IsValid(subcategory))
            {
                // UNDONE: UNSECURE INPUT DETECTED
            }

            WebUi.ViewModels.CurrentListItem current = new ViewModels.CurrentListItem();
            current.Category = category;
            current.Subcategory = subcategory;

            ViewData[WebUi.ViewModels.ViewDataKeys.HighlightedProductCategoryMenuItem] = current;

            return View();
        }
    }
}
