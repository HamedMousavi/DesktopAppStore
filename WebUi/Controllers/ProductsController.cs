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


        public ActionResult List(string category, string subcategory, int? page, int? sort)
        {
            if (!DomainModel.Security.InputController.IsValid(category) ||
                !DomainModel.Security.InputController.IsValid(subcategory))
            {
                return RedirectToAction(
                    WebUi.ViewModels.NavigationKeys.SecurityBadInputAction,
                    WebUi.ViewModels.NavigationKeys.SecurityController);
            }

            if (page == null) page = 1;
            if (sort == null) sort = 1;

            CategoryParent parent =
                DomainModel.Repository.Memory.Categories.Instance.Items
                [Models.AppCulture.CurrentCulture.CultureId];

            int? categoryId = null;
            int? parentId = null;
            string listTitle = string.Empty;
            Category cat = null;

            if (!string.IsNullOrWhiteSpace(category))
            {
                cat = parent[category];

                if (cat != null)
                {
                    parentId = cat.CategoryId;
                    listTitle = cat.CategoryName;
                }
            }

            if (!string.IsNullOrWhiteSpace(subcategory) && cat != null)
            {
                cat = cat.SubCategories[subcategory];

                if (cat != null)
                {
                    categoryId = cat.CategoryId;

                    if (!string.IsNullOrWhiteSpace(listTitle)) listTitle += " - ";
                    listTitle += cat.CategoryName;
                }
            }

            WebUi.ViewModels.PagingInfo pagingInf = new ViewModels.PagingInfo();
            int startRow = (page.Value - 1) * pagingInf.ItemsPerPage + 1;

            GeneralDatabaseList list =
                DomainModel.Repository.Sql.Products.GetByCategory(
                    WebUi.Models.AppCulture.CurrentCulture.CultureId, 
                    categoryId, 
                    parentId, 
                    startRow, 
                    startRow + pagingInf.ItemsPerPage - 1,
                    sort.Value);
            pagingInf.CurrentSortOption = sort.Value;
            pagingInf.CurrentPage = page.Value;
            pagingInf.TotalItems = list.TotalCount;
            pagingInf.listTitle = listTitle;

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

            if (DomainModel.Repository.Sql.Catalog.Load(
                productName, 
                WebUi.Models.AppCulture.CurrentCulture.CultureId, 
                product,
                Models.Security.CurrentUser == null ? -1 : Models.Security.CurrentUser.Id))
            {
                DomainModel.Repository.Disk.Catalog.LoadScreenshots(
                    product,
                    WebUi.Models.AppCulture.CurrentCulture.CultureId,
                    false);

                DomainModel.Repository.Disk.Catalog.LoadDemoVersions(
                    product,
                    WebUi.Models.AppCulture.CurrentCulture.CultureId);

                // UNDONE: ADD MESSAGE DATA TO PRODUCT CONTROLLER
                DomainModel.Repository.Sql.Discussions.LoadProductDiscussions
                    (product, 0, 1000);

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



        public ActionResult Tags(Int32? tagId, int? page, int? sort)
        {
            if (tagId == null ||
                !tagId.HasValue)
            {
                return RedirectToAction(
                    WebUi.ViewModels.NavigationKeys.SecurityBadInputAction,
                    WebUi.ViewModels.NavigationKeys.SecurityController);
            }

            if (sort == null || !sort.HasValue) sort = 1;

            string listTitle = UiResources.UiTexts.related_tags;
            ProductTag tag = DomainModel.Repository.Sql.Tags.GetById(
                tagId.Value,
                WebUi.Models.AppCulture.CurrentCulture.Id);
            
            if (tag != null)
            {
                listTitle += " - " +tag.Name;
            }

            WebUi.ViewModels.PagingInfo pagingInf = new ViewModels.PagingInfo();
            int startRow = (page.Value - 1) * pagingInf.ItemsPerPage + 1;

            GeneralDatabaseList list =
                DomainModel.Repository.Sql.Products.GetByTagId(
                    WebUi.Models.AppCulture.CurrentCulture.Id, 
                    tagId.Value, 
                    startRow, 
                    startRow + pagingInf.ItemsPerPage - 1,
                    sort.Value);

            pagingInf.CurrentSortOption = sort.Value;
            pagingInf.CurrentPage = page.Value;
            pagingInf.TotalItems = list.TotalCount;
            pagingInf.listTitle = listTitle;

            ViewData[ViewModels.ViewDataKeys.ListPagingDetails] = pagingInf;

            return View("List", list.List);
        }
    }
}
