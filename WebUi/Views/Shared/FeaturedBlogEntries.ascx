<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>


<div id="featured_blog_entries">
    <div class="section_title"><%:UiResources.UiTexts.featured_blog_entries%></div>
    <ul>
        <%
            DomainModel.Entities.WeblogEntryCollection messages =
                DomainModel.Repository.Memory.Weblog.Instance.GetFeatured(
                    WebUi.Models.AppCulture.CurrentCulture.CultureId);

            foreach (DomainModel.Entities.WeblogEntry message in messages)
            {
        %>
        <li>
            <%: Html.ActionLink(
                    message.Title,
                    WebUi.ViewModels.NavigationKeys.IndexAction,
                    WebUi.ViewModels.NavigationKeys.WeblogController,
                    new { url = message.Url },
                    null
                    )
            %>
        </li>
        <%        
            }
        %>
    </ul>
</div>
