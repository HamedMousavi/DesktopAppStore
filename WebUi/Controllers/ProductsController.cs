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


        public ActionResult List(string category, string subcategory, int page)
        {
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
                DomainModel.Repository.Sql.Products.GetByCategory
                (categoryId, parentId, 1, 5);
            
            WebUi.ViewModels.PagingInfo pagingInf = new ViewModels.PagingInfo();
            pagingInf.CurrentPage = page;
            pagingInf.TotalItems = list.TotalCount;

            ViewData[ViewModels.ViewDataKeys.ListPagingDetails] = pagingInf;

            return View(list.List);
        }


        public ActionResult Details(string productName)
        {
            // GET ALL INFO ABOUT PRODUCT
            // SHOW IT NICELY TO USER
            return View();
        }

    }
}
