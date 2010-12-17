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



        public ActionResult CreateDiscussion(string productName)
        {
            // UNDONE: SECURITY CONSIDERATIONS
            ViewModels.DiscussionInfo di = new ViewModels.DiscussionInfo(
                ViewModels.DiscussionInfo.EditorTypes.Insert, productName);

            di.MessageToEdit =
                di.CreateMessage(productName, 0, 0, false);

            return View("Edit", di);
        }


        public ActionResult Reply(string productName, Int32? discussion, Int32? message)
        {
            // UNDONE: SECURITY CONSIDERATIONS
            ViewModels.DiscussionInfo di = new ViewModels.DiscussionInfo(
                ViewModels.DiscussionInfo.EditorTypes.Reply, productName);

            di.MessageToReply =
                di.CreateMessage(productName, discussion.Value, message.Value, false);

            DomainModel.Repository.Sql.Discussions.LoadMessageById(di.MessageToReply);

            di.MessageToEdit =
                di.CreateMessage(productName, discussion.Value, 0, false);

            return View("Edit", di);
        }


        public ActionResult Edit(string productName, Int32? discussion, Int32? message)
        {
            // UNDONE: SECURITY CONSIDERATIONS
            ViewModels.DiscussionInfo di = new ViewModels.DiscussionInfo(
                ViewModels.DiscussionInfo.EditorTypes.Reply, productName);

            di.MessageToEdit =
                di.CreateMessage(productName, discussion.Value, message.Value, false);

            di.MessageToReply =
                di.CreateMessage(productName, 0, 0, false);

            DomainModel.Repository.Sql.Discussions.LoadMessageAndParent(
                di.MessageToEdit, di.MessageToReply);

            return View("Edit", di);
        }


        public ActionResult Delete(string productName, Int32? discussion, Int32? message)
        {
            // UNDONE: SECURITY CONSIDERATIONS
            ViewModels.DiscussionInfo di = new ViewModels.DiscussionInfo(
                ViewModels.DiscussionInfo.EditorTypes.Delete, productName);

            di.MessageToDelete = message.Value;

            return View("Confirm", di);
        }


        public ActionResult Report(string productName, Int32? discussion, Int32? message)
        {
             // UNDONE: SECURITY CONSIDERATIONS
           ViewModels.DiscussionInfo di = new ViewModels.DiscussionInfo(
                ViewModels.DiscussionInfo.EditorTypes.Report, productName);

            di.MessageToReport = message.Value;
            return View("Confirm", di);
        }


        [HttpPost]
        public ActionResult SaveDiscussion(string Product, Int32? Discussion, Int32? Message, Int32? Parent, string MessageType, string Subject, string Body)
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
            message.Discussion.Forum.ForumId = 0;
            message.Discussion.Forum.PageId = 0;
            message.Discussion.Forum.UrlName = Product;
            
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
            return RedirectToAction(
                WebUi.ViewModels.NavigationKeys.ProductCatalogAction,
                WebUi.ViewModels.NavigationKeys.ProductController,
                new { productName = Product});
        }



        [HttpPost]
        public ActionResult DeleteDiscussion(string Product, Int32? Message)
        {
            // UNDONE: AUTHORIZATION
            // UNDONE: SECURITY
            DomainModel.Repository.Sql.Discussions.Delete(
                Message.Value,
                WebUi.Models.Security.CurrentUser.Id,
                WebUi.Models.Security.UserIp);

            return RedirectToAction(
                WebUi.ViewModels.NavigationKeys.ProductCatalogAction,
                WebUi.ViewModels.NavigationKeys.ProductController,
                new { productName = Product});
        }



        [HttpPost]
        public ActionResult ReportDiscussion(string Product, Int32? Message)
        {
            // UNDONE: AUTHORIZATION
            // UNDONE: SECURITY
            DomainModel.Repository.Sql.Discussions.Report(
                Message.Value,
                WebUi.Models.Security.CurrentUser.Id,
                WebUi.Models.Security.UserIp);

            return RedirectToAction(
                WebUi.ViewModels.NavigationKeys.ProductCatalogAction,
                WebUi.ViewModels.NavigationKeys.ProductController,
                new { productName = Product});
        }

    }
}
