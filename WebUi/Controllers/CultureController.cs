﻿using System;
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
                return RedirectToAction(
                    WebUi.ViewModels.NavigationKeys.SecurityBadInputAction, 
                    WebUi.ViewModels.NavigationKeys.SecurityController);
            }

            // Save culture
            WebUi.Models.AppCulture.CurrentCulture =
                DomainModel.Repository.Memory.Languages.Instance.Items[SelectedCulture];


            // Return to previous page
            return Redirect(ReturnUrl);
        }

    }
}
