using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUi.Controllers
{
    public class ErrorsController : Controller
    {
        //
        // GET: /Errors/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Exception()
        {
            //Response.Write(TempData[ViewModels.ViewDataKeys.LastException]);
            return View();
        }


        public ActionResult NotFound()
        {
            return View();
        }
    }
}
