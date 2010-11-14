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
        public static MvcHtmlString AccordionList(this HtmlHelper html, IEnumerable items, WebUi.ViewModels.CurrentListItem current)
        {
            bool selected;
            bool subSelected;
            StringBuilder ret = new StringBuilder();

            foreach (DomainModel.Entities.Category category in items)
            {
                selected = category.UrlName == current.Category;
                ret.Append(BeginTitleTag(category, selected));

                foreach(DomainModel.Entities.Category sub in category.SubCategories)
                {
                    subSelected = selected & (sub.UrlName == current.Subcategory);
                    ret.Append(GetSubcategoryTag(html, category, sub, subSelected));
                }

                ret.Append(EndTitleTag());
            }


            return MvcHtmlString.Create(ret.ToString());
        }


        private static string EndTitleTag()
        {
            return "</div>";
        }



        private static string BeginTitleTag(DomainModel.Entities.Category category, bool selected)
        {
            string titleUrl = string.Format(
                "<a onclick=\"return ToggleAccordionList('{0}');\"  href=\"/Products/List/{1}\">{2}</a>",
                category.CategoryId,
                category.UrlName,
                category.CategoryName);

            return string.Format(
                "<div class=\"accordion_list_title\">" +
                    "{0}" +
                "</div>" +
                    "<div id=\"{1}\" class=\"accordion_dropdown\" style=\"display: {2};\">",
                titleUrl,
                category.CategoryId,
                selected ? "block" : "none");
        }



        private static string GetSubcategoryTag(HtmlHelper html, DomainModel.Entities.Category category, DomainModel.Entities.Category sub, bool selected)
        {
            MvcHtmlString url = System.Web.Mvc.Html.LinkExtensions.ActionLink(
                       html,
                       sub.CategoryName,
                       WebUi.ViewModels.NavigationKeys.ProductListAction,
                       WebUi.ViewModels.NavigationKeys.ProductController,
                       new { category = category.UrlName, subcategory = sub.UrlName }, null);

            return string.Format(
                "<div class=\"accordion_list_item{0}\">" +
                    "{1}" +
                "</div>",
                selected?"_selected":"",
                url.ToString());
        }
    }
}