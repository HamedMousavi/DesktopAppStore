using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUi.Controllers
{
    public class BaseController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            try
            {
                string culture = WebUi.Models.AppCulture.CurrentCulture.CultureId;

                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name != culture)
                {
                    // Update thread culture
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
                }
            }
            catch (Exception ex)
            {/*
                DomainModel.Errors.Handler.HandleException(
                    this, 
                    HttpContext, 
                    Models.AppCulture.CurrentCulture.CultureId, 
                    ex);*/
            }

            base.Initialize(requestContext);
        }


        protected override void OnException(ExceptionContext filterContext)
        {
            try
            {
                if (filterContext.ExceptionHandled)
                    return;

                //redirect to error handler
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                    new
                    {
                        controller = ViewModels.NavigationKeys.ErrorsController,
                        action = ViewModels.NavigationKeys.ErrorsExceptionAction
                    }));

                // Stop any other exception handlers from running
                filterContext.ExceptionHandled = true;

                // CLear out anything already in the response
                filterContext.HttpContext.Response.Clear();

                //Let the request know what went wrong
                filterContext.Controller.TempData[ViewModels.ViewDataKeys.LastException] =
                    filterContext.Exception;
                /*
                DomainModel.Errors.Handler.HandleException(
                    filterContext.Controller,
                    filterContext.HttpContext,
                    "",
                    filterContext.Exception);*/
            }
            catch (Exception ex)
            {
                // UNDONE:
                System.Diagnostics.Debug.WriteLine(string.Format("Exception:{0}", ex));
            }
        }

    }
}