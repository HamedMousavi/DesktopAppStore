using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUi.Controllers
{
    public class SearchController : BaseController
    {
        //
        // GET: /Search/
        // Advanced search page
        public ActionResult Index()
        {
            return RedirectToAction("Advanced");
        }


        // Search from home page
        public ActionResult Basic(string search_term)
        {
            ViewData["term"] = search_term;
            return View();
        }


        // Advanced search page
        public ActionResult Advanced()
        {
            return View();
        }
    }
}
