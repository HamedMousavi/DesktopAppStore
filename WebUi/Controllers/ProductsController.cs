using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using DomainModel.Entities;

namespace WebUi.Controllers
{
    public class ProductsController : BaseController
    {
        //
        // GET: /Products/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List(string category, string subcategory, int? page)
        {
            if (!DomainModel.Security.InputController.IsValid(category) ||
                !DomainModel.Security.InputController.IsValid(subcategory))
            {
                return RedirectToAction(
                    WebUi.ViewModels.NavigationKeys.SecurityBadInputAction,
                    WebUi.ViewModels.NavigationKeys.SecurityController);
            }

            if (page == null) page = 1;

            CategoryParent parent =
                DomainModel.Repository.Memory.Categories.Instance.Items
                [Models.AppCulture.CurrentCulture.CultureId];

            int? categoryId = null;
            int? parentId = null;

            if (!string.IsNullOrWhiteSpace(category))
            {
                parentId = parent[category].CategoryId;
            }

            if (!string.IsNullOrWhiteSpace(subcategory))
            {
                categoryId = parent[category].SubCategories[subcategory].CategoryId;
            }

            GeneralDatabaseList list =
                DomainModel.Repository.Sql.Products.GetByCategory(
                    WebUi.Models.AppCulture.CurrentCulture.CultureId, categoryId, parentId, 1, 5);

            WebUi.ViewModels.PagingInfo pagingInf = new ViewModels.PagingInfo();
            pagingInf.CurrentPage = page.Value;
            pagingInf.TotalItems = list.TotalCount;

            ViewData[ViewModels.ViewDataKeys.ListPagingDetails] = pagingInf;

            return View(list.List);
        }


        public ActionResult Catalog(string productName)
        {
            if (!DomainModel.Security.InputController.IsValid(productName))
            {
                return RedirectToAction(
                    WebUi.ViewModels.NavigationKeys.SecurityBadInputAction,
                    WebUi.ViewModels.NavigationKeys.SecurityController);
            }

            // productName is in fact products' urlName
            ApplicationProduct product = new ApplicationProduct();

            if (DomainModel.Repository.Sql.Catalog.Load(productName, WebUi.Models.AppCulture.CurrentCulture.CultureId, product))
            {
                DomainModel.Repository.Disk.Catalog.LoadScreenshots(product, WebUi.Models.AppCulture.CurrentCulture.CultureId, false);

                return View(product);
            }

            return RedirectToAction(
                WebUi.ViewModels.NavigationKeys.Errors404Action,
                WebUi.ViewModels.NavigationKeys.ErrorsController);
        }



        public ActionResult Screenshots(string productName, int? imageIndex)
        {
            if (!DomainModel.Security.InputController.IsValid(productName))
            {
                return RedirectToAction(
                    WebUi.ViewModels.NavigationKeys.SecurityBadInputAction,
                    WebUi.ViewModels.NavigationKeys.SecurityController);
            }

            if (imageIndex == null) imageIndex = 1;

            List<ProductImage> screenshots = new List<ProductImage>();
            DomainModel.Repository.Disk.Catalog.GetScreenShots(productName, WebUi.Models.AppCulture.CurrentCulture.CultureId, screenshots, true);

            WebUi.ViewModels.ScreenshotInfo info = new ViewModels.ScreenshotInfo(
                imageIndex.Value - 1/* UI indexes start from 1 */,
                screenshots,
                productName);

            return View(info);
        }
    }
}
