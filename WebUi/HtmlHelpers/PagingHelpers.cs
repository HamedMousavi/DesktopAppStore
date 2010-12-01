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
            ret.Append("<span class=\"button_link\">");

            string action = html.ViewContext.RouteData.Values["action"].ToString();
            System.Web.Routing.RouteValueDictionary routeVals = html.ViewContext.RouteData.Values;

            for (int i = 1; i <= inf.TotalPages; i++)
            {
                // RouteData.Values["controller"].ToString()
                routeVals["sort"] = inf.CurrentSortOption;
                routeVals["page"] = i;
                string urlRef = url.Action(action, routeVals);

                TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag
                tag.MergeAttribute("href", urlRef);
                tag.InnerHtml = i.ToString();
                if (i == inf.CurrentPage)
                {
                    tag.AddCssClass("selected");
                }

                ret.AppendLine(tag.ToString());
            }

            ret.Append("</span>");
            return MvcHtmlString.Create(ret.ToString());
        }



        public static MvcHtmlString ListDetail(this HtmlHelper html, PagingInfo inf)
        {
            string ret = "<span class=\"list_pager_details\">";

            ret += string.Format(UiResources.UiTexts.items_found, inf.TotalItems);
            ret += "<span class=\"pager_inf_separator\">|</span>";

            ret += string.Format(UiResources.UiTexts.page_count, inf.TotalPages);
            ret += "<span class=\"pager_inf_separator\">|</span>";

            ret += "</span>";

            return MvcHtmlString.Create(ret);
        }
    
    }

}