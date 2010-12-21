using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUi.Controllers
{
    public class WeblogController : BaseController
    {
        //
        // GET: /Weblog/

        public ActionResult Index(string url)
        {
            if (!DomainModel.Security.InputController.IsValid(url))
            {
                return RedirectToAction(
                    WebUi.ViewModels.NavigationKeys.SecurityBadInputAction,
                    WebUi.ViewModels.NavigationKeys.SecurityController);
            }

            DomainModel.Entities.WeblogEntryCollection msgs =
                DomainModel.Repository.Memory.Weblog.Instance.GetMessages(
                    WebUi.Models.AppCulture.CurrentCulture.CultureId,
                    url);

            if (msgs != null)
            {
                foreach (DomainModel.Entities.WeblogEntry entry in msgs)
                {
                    // UNDONE: MESSAGE PAGING
                    DomainModel.Repository.Sql.Discussions.LoadWeblogDiscussion(entry, 0, 1000);
                }

                return View(msgs);
            }

            return RedirectToAction(ViewModels.NavigationKeys.Errors404Action);
        }

    }
}
