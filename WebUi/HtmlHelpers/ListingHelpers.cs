using System.Collections.Generic;
using System;
using System.Web.Mvc;
using System.Collections;
using System.Text;
using System.Web.Routing;



namespace WebUi.HtmlHelpers
{
    public static class ListingHelpers
    {
        public static MvcHtmlString AccordionList(this HtmlHelper html, IEnumerable items)
        {
            StringBuilder ret = new StringBuilder();

            foreach (DomainModel.Entities.Category category in items)
            {
                ret.Append(BeginTitleTag(category));

                foreach(DomainModel.Entities.Category sub in category.SubCategories)
                {
                    ret.Append(GetSubcategoryTag(html, category, sub));
                }

                ret.Append(EndTitleTag());
            }


            return MvcHtmlString.Create(ret.ToString());
        }


        private static string EndTitleTag()
        {
            return "</div>";
        }



        private static string BeginTitleTag(DomainModel.Entities.Category category)
        {
            string titleUrl = string.Format(
                "<a onclick=\"return ToggleAccordionList('{0}');\"  href=\"/Products/{1}\">{2}</a>",
                category.CategoryId,
                category.UrlName,
                category.CategoryName);

            return string.Format(
                "<div class=\"accordion_list_title\">" +
                    "{0}" +
                "</div>" +
                    "<div id=\"{1}\" class=\"accordion_dropdown\" style=\"display: none;\">",
                titleUrl,
                category.CategoryId);
        }



        private static string GetSubcategoryTag(HtmlHelper html, DomainModel.Entities.Category category, DomainModel.Entities.Category sub)
        {
            MvcHtmlString url = System.Web.Mvc.Html.LinkExtensions.ActionLink(
                       html,
                       sub.CategoryName,
                       "List",
                       "Products",
                       new { category = category.UrlName, subcategory = sub.UrlName }, null);

            return string.Format(
                "<div class=\"accordion_list_item\">" +
                    "{0}" +
                "</div>",
                url.ToString());
        }
    }
}