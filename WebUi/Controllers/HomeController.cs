using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;

namespace WebUi.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        /*
        public ActionResult Redirect()
        {
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult TestForm()
        {
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public ActionResult TestForm([DefaultValue(0)] int index)
        {
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Article(string articlePath)
        {
            return View();
        }
        */
    }
}
