using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;



namespace WebUi.Controllers
{
    public class MembersController : BaseController
    {

        public DomainModel.Abstract.IMembership MembershipService { get; set; }


        protected override void Initialize(RequestContext requestContext)
        {
            if (MembershipService == null) 
            { 
                MembershipService = new DomainModel.Security.MembershipService(); 
            }

            base.Initialize(requestContext);
        }


        public ActionResult Index()
        {
            return RedirectToAction("Logon");
        }


        public ActionResult Logon()
        {
            return View();
        }


        public ActionResult Register()
        {
            return View();
        }


        public ActionResult Welcome()
        {
            return View();
        }


        public ActionResult LogOff()
        {
            try
            {
                this.MembershipService.SignOut();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                DomainModel.Errors.Handler.HandleException(
                    this,
                    HttpContext,
                    Models.AppCulture.CurrentCulture.CultureId,
                    ex);

                return RedirectToAction(
                            WebUi.ViewModels.NavigationKeys.ErrorsExceptionAction,
                            WebUi.ViewModels.NavigationKeys.ErrorsController);
            }
        }


        [HttpPost]
        public ActionResult Logon(WebUi.ViewModels.LoginInfo model, string returnUrl)
        {
            // Validate input
            if (!DomainModel.Security.InputController.IsValid(returnUrl) ||
                !DomainModel.Security.InputController.IsValid(model.UserName) ||
                !DomainModel.Security.InputController.IsValid(model.Password))
            {
                return RedirectToAction(
                    WebUi.ViewModels.NavigationKeys.SecurityBadInputAction,
                    WebUi.ViewModels.NavigationKeys.SecurityController);
            }

            // Validate model data
            if (ModelState.IsValid)
            {
                // Authenticate user
                if (this.MembershipService.ValidateUser(model.Email, model.Password))
                {
                    this.MembershipService.SignIn(model.Email, model.RememberMe);

                    // Redirect to return url or homepage
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", UiResources.UiTexts.error_authentication_failed);
                }
            }

            return View(model);
        }


        [HttpPost]
        public ActionResult Register(string Email)
        {
            // Validate input
            if (!DomainModel.Security.InputController.IsValid(Email))
            {
                ModelState.AddModelError("email", UiResources.UiTexts.error_security);
                return RedirectToAction(
                    WebUi.ViewModels.NavigationKeys.SecurityBadInputAction,
                    WebUi.ViewModels.NavigationKeys.SecurityController);
            }

            if (!DomainModel.Security.InputController.IsValidEmail(Email))
            {
                ModelState.AddModelError("email", UiResources.UiTexts.error_email);
            }

            // Ensure user is new
            if (this.MembershipService.Exists(Email))
            {
                ModelState.AddModelError("email", string.Format(UiResources.UiTexts.error_already_a_user));
            }

            if (ModelState.IsValid)
            {
                // Send an activation email async.
                if (this.MembershipService.CreateUser(Email))
                {
                    // UNDONE : SEND AN EMAIL CONTAINING USER CREDENTIALS
                    return RedirectToAction("Welcome", "Members");
                }
                else
                {
                    ModelState.AddModelError("", string.Format(UiResources.UiTexts.error_internal));
                }
            }


            return View("Register");
        }
    }
}




/*
                var message = new StringBuilder(); 
                    message.AppendFormat("Date: {0:yyyy-MM-dd hh:mm}\n", DateTime.Now); 
                    message.AppendFormat("RSVP from: {0}\n", Name); 
                    message.AppendFormat("Email: {0}\n", Email); 
                    message.AppendFormat("Phone: {0}\n", Phone); 
                    message.AppendFormat("Can come: {0}\n", WillAttend.Value ? "Yes" : "No"); 
                    return new MailMessage( 
                        "rsvps@example.com",                                          // From 
                        "party-organizer@example.com",                                // To 
                        Name + (WillAttend.Value ? " will attend" : " won't attend"), // Subject 
                        message.ToString()                                            // Body 
                    );
                 * 
using (var smtpClient = new SmtpClient()) 
    using (var mailMessage = BuildMailMessage()) { 
        smtpClient.Send(mailMessage); 
    }
 
 */
