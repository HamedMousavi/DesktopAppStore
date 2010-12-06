using System;
using System.Web.Mvc;
using System.Text;
using DomainModel.Entities;


namespace WebUi.HtmlHelpers
{
    public static class ForumHelpers
    {
        public static MvcHtmlString ForumDiscussions(this HtmlHelper html, Discussion discussion)
        {
            StringBuilder ret = new StringBuilder();

            ret.Append(ForumMessage(discussion));

            return MvcHtmlString.Create(ret.ToString());
        }


        private static string ForumMessage(DiscussionMessage message)
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendFormat("<div class=\"forum_message\" style=\"margin-{0}: {1}px;\">",
                UiResources.UiTexts.float_left,
                message.IsParent ? 2 : 20);

            ret.AppendFormat(
                "<div class=\"forum_message_subject_normal\" id=\"msg_hd_{0}\" " +
                "onclick=\"return ToggleForumMessage('msg_bd_{0}');\" " +
                ">" +
                    "<img alt=\"{5} message\" src=\"/Content/Forums/Images/{5}.gif\"></img> " +
                    "<span class=\"forum_message_caption\">{1}</span>" +
                    "<span class=\"forum_message_time\" style=\"float:{2}; text-align:{2}\">{3}</span>" +
                    "<span class=\"forum_message_user\" style=\"float:{2}; text-align:{2}\">{4}</span>" +
                "</div>", 
                message.Id,
                message.Subject,
                UiResources.UiTexts.float_right,
                DomainModel.Tools.DateTime.Convert.ToCulture(
                    message.UpdateTime, 
                    WebUi.Models.AppCulture.CurrentCulture),
                message.UserName,
                message.Type.ToString()
                );
            ret.AppendFormat("<div class=\"forum_message_body\" style=\"display: none;\" id=\"msg_bd_{0}\">", message.Id);
            ret.AppendFormat("<span>{0}</span>", message.Body);

            ret.AppendFormat("  <div class=\"message_control_panel\">");
            if(Models.Security.UserId == null || 
                !Models.Security.UserId.HasValue ||
                Models.Security.UserId.Value <= 0)
            {
                ret.AppendFormat("<span>{0}</span>", UiResources.UiTexts.login_to_manage_comments);
            }
            else
            {
                ret.AppendFormat("<ul>");

                ret.AppendFormat("<li><a href=\"/Products/{0}/Discussions/Reply/{1}/{2}\">{3}</a></li>",
                    message.Discussion.forum.UrlName,
                    message.Discussion.Id,
                    message.Id,
                    UiResources.UiTexts.reply);

                if (Models.Security.UserId.Value == message.UserId)
                {
                    ret.AppendFormat("<li><a href=\"/Products/{0}/Discussions/Edit/{1}/{2}\">{3}</a></li>",
                        message.Discussion.forum.UrlName,
                        message.Discussion.Id,
                        message.Id,
                        UiResources.UiTexts.edit_message);

                    ret.AppendFormat("<li><a href=\"/Products/{0}/Discussions/Delete/{1}/{2}\">{3}</a></li>",
                        message.Discussion.forum.UrlName,
                        message.Discussion.Id,
                        message.Id,
                        UiResources.UiTexts.delete_message);
                }
                else
                {
                    ret.AppendFormat("<li><a href=\"/Products/{0}/Discussions/Report/{1}/{2}\" onclick=\"return ConfirmMessageReport();\">{3}</a></li>",
                        message.Discussion.forum.UrlName,
                        message.Discussion.Id,
                        message.Id,
                        UiResources.UiTexts.report_abuse);

                }

                ret.AppendFormat("</ul>");
            }
            ret.AppendFormat("  </div>");

            ret.AppendFormat("</div>");

            foreach (DiscussionMessage msg in message.Replies)
            {
                ret.Append(ForumMessage(msg));
            }

            ret.Append("</div>");

            return ret.ToString();
        }
    }
}
//"١"