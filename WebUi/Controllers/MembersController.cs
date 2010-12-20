using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DomainModel.Membership;



namespace WebUi.Controllers
{
    public class MembersController : BaseController
    {

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
                MembershipService.SignOut();
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
        public ActionResult Logon(WebUi.ViewModels.LoginInfo model)
        {
            // Validate input
            if (!DomainModel.Security.InputController.IsValid(model.ReturnUrl) ||
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
                DomainModel.Membership.User user = MembershipService.ValidateUser(model.Email, model.Password);
                if (user != null)
                {
                    MembershipService.SignIn(user, model.RememberMe);

                    // Redirect to return url or homepage
                    if (!String.IsNullOrWhiteSpace(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
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
            if (MembershipService.Exists(Email))
            {
                ModelState.AddModelError("email", string.Format(UiResources.UiTexts.error_already_a_user));
            }

            if (ModelState.IsValid)
            {
                // Send an activation email async.
                if (MembershipService.CreateUser(Email, WebUi.Models.AppCulture.CurrentCulture.CultureId))
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



        [HttpPost]
        public ActionResult VoteProduct(WebUi.ViewModels.VotingInfo votingInf)
        {
            if (!DomainModel.Security.InputController.IsValid(votingInf.ReturnUrl) ||
                !DomainModel.Security.InputController.IsValid(votingInf.VoteValue))
            {
                return RedirectToAction(
                    WebUi.ViewModels.NavigationKeys.SecurityBadInputAction,
                    WebUi.ViewModels.NavigationKeys.SecurityController);
            }

            if (votingInf == null ||
                votingInf.UserName == null ||
                !votingInf.UserName.HasValue ||
                votingInf.ProductId == null ||
                !votingInf.ProductId.HasValue ||
                string.IsNullOrWhiteSpace(votingInf.VoteValue))
            {
                return RedirectToAction(
                    WebUi.ViewModels.NavigationKeys.SecurityBadInputAction,
                    WebUi.ViewModels.NavigationKeys.SecurityController);
            }

            Int16 voteVal = Convert.ToInt16(votingInf.VoteValue);

            DomainModel.Repository.Sql.ProductRatings.Insert(
                votingInf.UserName,
                votingInf.ProductId,
                voteVal,
                Models.Security.UserIp
                );

            return Redirect(votingInf.ReturnUrl);
        }


        public ActionResult Profile(Int32? user)
        {
            ViewData[ViewModels.ViewDataKeys.HighlightedMemberMenuItem] = 0;
            
            DomainModel.Abstract.IUser sarvUser = null;
            DomainModel.Membership.UserProfile profile = null;

            // Check to see if user is already loaded in memory
            if (user == null || !user.HasValue || user.Value <= 0 || 
                user.Value == WebUi.Models.Security.CurrentUser.Id)
            {
                sarvUser = WebUi.Models.Security.CurrentUser;
            }
            else
            {
                sarvUser = DomainModel.Repository.Memory.Users.Instance.GetUser(user.Value);
            }

            // If user exists attach her profile
            if (sarvUser != null)
            {
                profile = sarvUser.Profile;
            }
            else
            {
                profile = new UserProfile();
            }

            // If profile is loaded and doesn't need a reload use it, otherwise load profile
            if (profile.Ownership.Details.Count <= 0 ||
                profile.Ownership.Details[WebUi.Models.AppCulture.CurrentCulture.CultureId] == null ||
                profile.Ownership.Details[WebUi.Models.AppCulture.CurrentCulture.CultureId].LastLoaded == null || 
                (DateTime.UtcNow - profile.Ownership.Details[WebUi.Models.AppCulture.CurrentCulture.CultureId].LastLoaded.Value).Hours 
                < 12)
            {
                DomainModel.Repository.Sql.Profiles.LoadAll(
                    WebUi.Models.Security.CurrentUser.Id,
                    WebUi.Models.Security.CurrentUser.Profile,
                    WebUi.Models.AppCulture.CurrentCulture.CultureId);
            }
            else
            {
                profile = WebUi.Models.Security.CurrentUser.Profile;
            }

            // UNDONE: PAGING FORUM
            DomainModel.Repository.Sql.Discussions.LoadProfileDiscussions(profile, 0, 1000);


            // Return loaded profile
            return View(WebUi.Models.Security.CurrentUser);
        }


        public ActionResult Settings()
        {
            ViewData[ViewModels.ViewDataKeys.HighlightedMemberMenuItem] = 1;

            return View(WebUi.Models.Security.CurrentUser.Profile);
        }


        [HttpPost]
        public ActionResult Settings(UserProfile profile)
        {
            // UNDONE: SECURITY
            ViewData[ViewModels.ViewDataKeys.HighlightedMemberMenuItem] = 1;

            WebUi.Models.Security.CurrentUser.Profile.Update(profile);
            if (WebUi.Models.Security.CurrentUser.Profile.HasUnsavedChanges)
            {
                if (DomainModel.Repository.Sql.Profiles.Update(
                    WebUi.Models.Security.CurrentUser))
                {
                    TempData[WebUi.ViewModels.ViewDataKeys.Alert] =
                        new WebUi.ViewModels.AlertInfo(
                            ViewModels.AlertInfo.AlertTypes.OK,
                            UiResources.UiTexts.alert_save_ok);
                }
                else
                {
                    TempData[WebUi.ViewModels.ViewDataKeys.Alert] = 
                        new WebUi.ViewModels.AlertInfo(
                            ViewModels.AlertInfo.AlertTypes.Error,
                            UiResources.UiTexts.alert_save_failed);
                }
            }


            return View(WebUi.Models.Security.CurrentUser.Profile);
        }
    }
}




/*
                var message = new StringBuilder(); 
                    message.AppendFormat("Date: {0:yyyy-MM-dd hh:mm}\n", DateTime.UtcNow); 
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
