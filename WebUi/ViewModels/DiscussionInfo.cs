using System;
using DomainModel.Entities;



namespace WebUi.ViewModels
{
    public class DiscussionInfo
    {
        public enum EditorTypes
        {
            Edit,
            Reply,
            Insert,
            Delete,
            Report
        }

        public DiscussionMessage MessageToReply { get; set; }
        public DiscussionMessage MessageToEdit { get; set; }
        public Int32 MessageToDelete { get; set; }
        public Int32 MessageToReport { get; set; }

        public EditorTypes EditorFor { get; set; }

        public string ReturnUrl { get; set; }

        public DiscussionInfo(EditorTypes editorFor)
        {
            this.EditorFor = editorFor;
        }


        public DiscussionMessage CreateMessage(Int16? forumGroup, Int64? forum, Int32 discussion, Int32 message, bool isParent)
        {
            DiscussionMessage msg = new DiscussionMessage();

            msg.Id = message;
            msg.IsParent = isParent;
            msg.Discussion = new Discussion(discussion, new Forum());
            msg.Discussion.Forum.UrlName = string.Empty;
            msg.Discussion.Forum.PageId = forum.Value;
            msg.Discussion.Forum.ForumId = forumGroup.Value;

            msg.Parent = new DiscussionMessage();

            return msg;
       }


    }
}