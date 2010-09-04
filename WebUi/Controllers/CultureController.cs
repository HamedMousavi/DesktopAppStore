using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUi.Controllers
{
    public class CultureController : BaseController
    {
        
        public ActionResult Index(string SelectedCulture,string ReturnUrl)
        {
            if (!DomainModel.Security.InputController.IsValid(SelectedCulture) ||
                !DomainModel.Security.InputController.IsValid(ReturnUrl))
            {
                return RedirectToAction("BadInput", "Security");
            }

            // Save culture
            WebUi.Models.AppCulture.CurrentCulture =
                WebUi.Models.AppCulture.CultureList[SelectedCulture];


            // Return to previous page
            return Redirect(ReturnUrl);
        }

    }
}
