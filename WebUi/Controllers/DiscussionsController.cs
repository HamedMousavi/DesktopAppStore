using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUi.Controllers
{
    public class DiscussionsController : Controller
    {
        //
        // GET: /Discussions/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Reply(string productName, Int32 discussion, Int32 message)
        {
            return View();
        }


        public ActionResult Edit(string productName, Int32 discussion, Int32 message)
        {
            return View();
        }


        public ActionResult Delete(string productName, Int32 discussion, Int32 message)
        {
             return View();
       }


        public ActionResult Report(string productName, Int32 discussion, Int32 message)
        {
             return View();
       }
    }
}
