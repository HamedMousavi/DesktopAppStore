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
                ret.AppendFormat("<a href=\"{2}/Screenshots\"><img alt=\"Product screenshot:{3}\" src=\"{4}\" width=\"{0}px\" height=\"{1}px\" /></a>",
                    400, 300,
                    url,
                    product.Screenshots[0].Description,
                    product.Screenshots[0].Url);
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
                               WebUi.ViewModels.NavigationKeys.SearchController,
                               new { tagId = tag.Id }, null);
                    ret.Append(url);

                    ret.Append("</li>");

                }
            }

            return MvcHtmlString.Create(ret.ToString());
       }
    }
}