using System;
using System.Web.Mvc;
using WebUi.ViewModels;
using System.Text;



namespace WebUi.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, UrlHelper url, PagingInfo inf)
        {
            StringBuilder ret = new StringBuilder();

            for (int i = 1; i <= inf.TotalPages; i++)
            {
                // RouteData.Values["controller"].ToString()
                string action = html.ViewContext.RouteData.Values["action"].ToString();
                string urlRef = url.Action(action, new { page = inf.CurrentPage });

                TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag
                tag.MergeAttribute("href", urlRef);
                tag.InnerHtml = i.ToString();
                if (i == inf.CurrentPage)
                {
                    tag.AddCssClass("selected");
                }

                ret.AppendLine(tag.ToString());
            }

            return MvcHtmlString.Create(ret.ToString());
        }
    }
}