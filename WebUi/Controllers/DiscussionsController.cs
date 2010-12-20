using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUi.Controllers
{
    public class DiscussionsController : BaseController
    {
        //
        // GET: /Discussions/

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Create(Int16? group, Int64? forum, string returnUrl)
        {
            // UNDONE: SECURITY CONSIDERATIONS
            ViewModels.DiscussionInfo di = new ViewModels.DiscussionInfo(
                ViewModels.DiscussionInfo.EditorTypes.Insert);

            di.ReturnUrl = returnUrl;

            di.MessageToEdit =
                di.CreateMessage(group, forum, 0, 0, false);

            return View("Edit", di);
        }


        public ActionResult Reply(Int16? group, Int64? forum, Int32? discussion, Int32? message, string returnUrl)
        {
            // UNDONE: SECURITY CONSIDERATIONS
            ViewModels.DiscussionInfo di = new ViewModels.DiscussionInfo(
                ViewModels.DiscussionInfo.EditorTypes.Reply);

            di.MessageToReply =
                di.CreateMessage(group, forum, discussion.Value, message.Value, false);

            DomainModel.Repository.Sql.Discussions.LoadMessageById(di.MessageToReply);

            di.MessageToEdit =
                di.CreateMessage(group, forum, discussion.Value, 0, false);

            di.ReturnUrl = returnUrl;

            return View("Edit", di);
        }


        public ActionResult Edit(Int16? group, Int64? forum, Int32? discussion, Int32? message, string returnUrl)
        {
            // UNDONE: SECURITY CONSIDERATIONS
            ViewModels.DiscussionInfo di = new ViewModels.DiscussionInfo(
                ViewModels.DiscussionInfo.EditorTypes.Reply);

            di.MessageToEdit =
                di.CreateMessage(group, forum, discussion.Value, message.Value, false);

            di.MessageToReply =
                di.CreateMessage(group, forum, 0, 0, false);

            DomainModel.Repository.Sql.Discussions.LoadMessageAndParent(
                di.MessageToEdit, di.MessageToReply);

            di.ReturnUrl = returnUrl;

            return View("Edit", di);
        }


        public ActionResult Delete(Int16? group, Int64? forum, Int32? discussion, Int32? message, string returnUrl)
        {
            // UNDONE: SECURITY CONSIDERATIONS
            ViewModels.DiscussionInfo di = new ViewModels.DiscussionInfo(
                ViewModels.DiscussionInfo.EditorTypes.Delete);

            di.MessageToDelete = message.Value;

            di.ReturnUrl = returnUrl;

            return View("Confirm", di);
        }


        public ActionResult Report(Int16? group, Int64? forum, Int32? discussion, Int32? message, string returnUrl)
        {
             // UNDONE: SECURITY CONSIDERATIONS
           ViewModels.DiscussionInfo di = new ViewModels.DiscussionInfo(
                ViewModels.DiscussionInfo.EditorTypes.Report);

            di.MessageToReport = message.Value;
            di.ReturnUrl = returnUrl;
            
            return View("Confirm", di);
        }


        [HttpPost]
        public ActionResult Save(Int16? ForumId, Int64? PageId, Int32? Discussion, Int32? Message, Int32? Parent, string MessageType, string Subject, string Body, string returnUrl)
        {
            // UNDONE: SECURITY CONSIDERATIONS

            DomainModel.Entities.DiscussionMessage message = new 
                DomainModel.Entities.DiscussionMessage();

            message.Id = (Message != null && Message.HasValue) ? Message.Value : 0;
            message.InsertTime = null;
            message.UpdateTime = null;
            message.UserId = Models.Security.CurrentUser.Id;
            message.UserIp = Models.Security.UserIp;
            message.Body = Body;
            message.Subject = Subject;
            message.Type = (DomainModel.Repository.Memory.Forums.MessageTypes)Convert.ToInt16(MessageType);

            message.Discussion = new
                DomainModel.Entities.Discussion(
                (Discussion != null && Discussion.HasValue) ? Discussion.Value : 0,
                new DomainModel.Entities.Forum());
            message.Discussion.Forum.ForumId = ForumId.Value;
            message.Discussion.Forum.PageId = PageId.Value;
            message.Discussion.Forum.UrlName = string.Empty;
            
            message.Parent = new DomainModel.Entities.DiscussionMessage();
            message.Parent.Id = (Parent != null && Parent.HasValue) ? Parent.Value : 0;


            if (Message != null && Message.HasValue && Message.Value > 0)
            {
                // Update record
                DomainModel.Repository.Sql.Discussions.Update(message);

            }
            else
            {
                //Insert record
                DomainModel.Repository.Sql.Discussions.Insert(message);
            }
            
            // UNDONE: DISPLAY MESSAGE. NEED TO UPDATE ROUTING
            return Redirect(returnUrl);
        }



        [HttpPost]
        public ActionResult Delete(Int64? forum, Int32? Message, string returnUrl)
        {
            // UNDONE: AUTHORIZATION
            // UNDONE: SECURITY
            DomainModel.Repository.Sql.Discussions.Delete(
                Message.Value,
                WebUi.Models.Security.CurrentUser.Id,
                WebUi.Models.Security.UserIp);

            return Redirect(returnUrl);
        }



        [HttpPost]
        public ActionResult Report(Int64? forum, Int32? Message, string returnUrl)
        {
            // UNDONE: AUTHORIZATION
            // UNDONE: SECURITY
            DomainModel.Repository.Sql.Discussions.Report(
                Message.Value,
                WebUi.Models.Security.CurrentUser.Id,
                WebUi.Models.Security.UserIp);

            return Redirect(returnUrl);
        }

    }
}
