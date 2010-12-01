using System;
using System.Web.Mvc;
using DomainModel.Entities;
using System.Text;
using System.Collections.Generic;
using System.Collections;




namespace WebUi.HtmlHelpers
{
    public static class CatalogHelpers
    {
        public static MvcHtmlString LanguageOverview(this HtmlHelper html, ApplicationProduct product, string url)
        {
            StringBuilder ret = new StringBuilder();

            if (product.SupportedLanguages.Count > 2)
            {
                ret.Append(string.Format("<a href=\"{0}#languages\">{1} {2}</a>", 
                    url, 
                    product.SupportedLanguages.Count, 
                    UiResources.UiTexts.product_language));
            }
            else
            {
                foreach (ProductLanguage language in product.SupportedLanguages)
                {
                    if (ret.Length > 0) ret.Append(", ");
                    ret.Append(language.Name);
                }
            }

            return MvcHtmlString.Create(ret.ToString());
        }


        public static MvcHtmlString SoftwareScreenshot(this HtmlHelper html, ApplicationProduct product, string url)
        {
            StringBuilder ret = new StringBuilder();

            if (product.Screenshots.Count > 0)
            {
                ret.Append("<div>");
                ret.AppendFormat("<a href=\"{2}/Screenshots\"><img alt=\"Product screenshot:{3}\" src=\"{4}\" width=\"{0}px\" height=\"{1}px\" /></a>",
                    400, 300,
                    url,
                    product.Screenshots[0].Description,
                    product.Screenshots[0].Url);
                ret.Append("</div>");

                ret.Append("<div>");
                ret.AppendFormat("<b><a href=\"{0}/Screenshots\">{1}</a></b>",
                    url,
                    UiResources.UiTexts.more_images);
                ret.Append("</div>");

            }
            else
            {
                ret.Append("<img alt=\"Product screenshot:No Image Available\" src=\"/Content/Products/Common/no_screenshot.png\" width=\"400px\" height=\"300px\" />");
            }

            return MvcHtmlString.Create(ret.ToString());
        }


        public static MvcHtmlString SoftwareAwards(this HtmlHelper html, ApplicationProduct product, string url)
        {
            /*
            StringBuilder ret = new StringBuilder();

            ret.AppendFormat("<a href=\"{0}\"><img alt=\"Early-Adapter Seal\" src=\"/Content/Images/seal_early_adapters.gif\" /></a>",
                url);

            return MvcHtmlString.Create(ret.ToString());
            */

            return MvcHtmlString.Create(string.Empty);
        }


        public static MvcHtmlString HardwareRequirements(this HtmlHelper html, ApplicationProduct product)
        {
            StringBuilder ret = new StringBuilder();

            if (product.HardwareRequirements.Count <= 0)
            {
                ret.Append(UiResources.UiTexts.nothing_special);
            }
            else
            {
                ret.Append("<ul>");
                foreach (string req in product.HardwareRequirements)
                {
                    ret.AppendFormat("<li class=\"article_li_{0}\">", UiResources.UiTexts.float_right);
                    ret.Append(req);
                    ret.Append("</li>");
                }
                ret.Append("</ul>");
            }

            return MvcHtmlString.Create(ret.ToString());
        }


        public static MvcHtmlString SoftwareOptions(this HtmlHelper html, IList options)
        {
            StringBuilder ret = new StringBuilder();

            if (options.Count <= 0)
            {
                ret.Append(UiResources.UiTexts.nothing_special);
            }
            else
            {
                ret.Append("<ul>");
                foreach (ProductOptionBase option in options)
                {
                    ret.AppendFormat("<li class=\"article_li_{0}\">", UiResources.UiTexts.float_right);
                    ret.Append(option.Name);
                    ret.Append("</li>");

                }
                ret.Append("</ul>");
            }

            return MvcHtmlString.Create(ret.ToString());
        }


        public static MvcHtmlString SoftwareContacts(this HtmlHelper html, List<ProductContact> contacts)
        {
            StringBuilder ret = new StringBuilder();
            bool colored = false;
            string align = UiResources.UiTexts.float_left;

            if (contacts.Count <= 0)
            {
                ret.Append(UiResources.UiTexts.nothing_special);
            }
            else
            {
                ret.AppendFormat("<table id=\"contacts\" cellpadding=\"0\"; cellspacing=\"0px\";>");
                ret.Append("<tbody>");

                // Add header
                ret.Append("<tr class=\"contacts_colored_row\">");
                ret.AppendFormat("<th style=\"text-align:{1};\">{0}</th>", UiResources.UiTexts.contact_title, align);
                ret.AppendFormat("<th style=\"text-align:{1};\">{0}</th>", UiResources.UiTexts.contact_name, align);
                ret.AppendFormat("<th style=\"text-align:{1};\">{0}</th>", UiResources.UiTexts.contact_media, align);
                ret.AppendFormat("<th style=\"text-align:{1};\">{0}</th>", UiResources.UiTexts.contact_value, align);
                ret.Append("</tr>");

                // Add rows
                foreach (ProductContact contact in contacts)
                {
                    if (colored)
                    {
                        ret.Append("<tr class=\"contacts_colored_row\">");
                    }
                    else
                    {
                        ret.Append("<tr>");
                    }
                    colored = !colored;

                    ret.AppendFormat("<td style=\"text-align:{1};\">{0}</td>", contact.Unit.Name, align);
                    ret.AppendFormat("<td style=\"text-align:{1};\">{0}</td>", contact.ContactPerson, align);
                    ret.AppendFormat("<td style=\"text-align:{1};\">{0}</td>", contact.MediaType.Name, align);
                    ret.AppendFormat("<td style=\"text-align:{1};\">{0}</td>", contact.ContactValue, align);

                    ret.Append("</tr>");
                }

                ret.Append("</tbody>");
                ret.Append("</table>");
            }

            return MvcHtmlString.Create(ret.ToString());
        }


        public static MvcHtmlString SoftwareTags(this HtmlHelper html, List<ProductTag> tags)
        {
            
            StringBuilder ret = new StringBuilder();

            if (tags.Count <= 0)
            {
                ret.Append(UiResources.UiTexts.nothing_special);
            }
            else
            {
                foreach (ProductTag tag in tags)
                {
                    ret.AppendFormat("<li class=\"tag_li_{0}\">", UiResources.UiTexts.float_right);
                    
                    MvcHtmlString url = System.Web.Mvc.Html.LinkExtensions.ActionLink(
                               html,
                               tag.Name,
                               WebUi.ViewModels.NavigationKeys.SearchTagAction,
                               WebUi.ViewModels.NavigationKeys.ProductController,
                               new { tagId = tag.Id }, null);
                    ret.Append(url);

                    ret.Append("</li>");

                }
            }

            return MvcHtmlString.Create(ret.ToString());
       }


        public static MvcHtmlString SoftwareListSortOptions(this HtmlHelper html, UrlHelper url, WebUi.ViewModels.PagingInfo pagingData)
        {

            StringBuilder ret = new StringBuilder();
            ret.AppendFormat("<div class=\"sort_options\"><span class=\"caption\">{0}</span>",
                UiResources.UiTexts.product_list_sort_order_caption);

            string action = html.ViewContext.RouteData.Values["action"].ToString();
            System.Web.Routing.RouteValueDictionary routeVals = html.ViewContext.RouteData.Values;

            foreach(KeyValuePair<int, string> sortOption in DomainModel.Repository.Memory.ProductList.Instance.SortOptions)
            {
                routeVals["sort"] = sortOption.Key;
                routeVals["page"] = 1;
                string urlRef = url.Action(action, routeVals);

                TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag
                tag.MergeAttribute("href", urlRef);

                tag.InnerHtml = WebUi.Models.DynamicResources.GetText(sortOption.Value);

                if (sortOption.Key == pagingData.CurrentSortOption)
                {
                    tag.AddCssClass("selected");
                }

                ret.Append(tag.ToString());
                ret.Append("<span class=\"pager_inf_separator\">.</span>");
            }

            ret.Append("</div>");
            return MvcHtmlString.Create(ret.ToString());
        }


        public static MvcHtmlString SoftwareRating(this HtmlHelper html, ProductBase product)
        {
            StringBuilder starsTags = new StringBuilder();
            starsTags.Append("<div class=\"stars\">");

            decimal rating;
            decimal stars;

            if (product == null ||
                product.Catalog == null ||
                product.Catalog.UserRating == null ||
                !product.Catalog.UserRating.HasValue)
            {
                rating = 0.0M;
            }
            else
            {
                rating = product.Catalog.UserRating.Value;
            }

            for (int i = 0; i < 5; i++)
            {
                stars = rating - Convert.ToDecimal(i);
                if (stars.CompareTo(1.0M) >= 0)
                {
                    starsTags.AppendFormat("<img alt=\"Full Star\" src=\"/Content/Images/Stars/{0}/100.png\"></img>", UiResources.UiTexts.page_direction);
                }
                else if (stars.CompareTo(0.75M) >= 0)
                {
                    starsTags.AppendFormat("<img alt=\"3 Quarter Star\" src=\"/Content/Images/Stars/{0}/075.png\"></img>", UiResources.UiTexts.page_direction);
                }
                else if (stars.CompareTo(0.50M) >= 0)
                {
                    starsTags.AppendFormat("<img alt=\"Half Star\" src=\"/Content/Images/Stars/{0}/050.png\"></img>", UiResources.UiTexts.page_direction);
                }
                else if (stars.CompareTo(0.25M) >= 0)
                {
                    starsTags.AppendFormat("<img alt=\"Quarter Star\" src=\"/Content/Images/Stars/{0}/025.png\"></img>", UiResources.UiTexts.page_direction);
                }
                else
                {
                    starsTags.AppendFormat("<img alt=\"Empty Star\" src=\"/Content/Images/Stars/{0}/000.png\"></img>", UiResources.UiTexts.page_direction);
                }
            }
            starsTags.Append("</div>");

            return MvcHtmlString.Create(starsTags.ToString());
        }
    }
}