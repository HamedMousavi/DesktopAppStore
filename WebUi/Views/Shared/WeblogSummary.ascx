<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>


<%
    int index = 0;
    DomainModel.Entities.WeblogEntryCollection messages =
        DomainModel.Repository.Memory.Weblog.Instance.GetMessages(
            WebUi.Models.AppCulture.CurrentCulture.CultureId);

    foreach (DomainModel.Entities.WeblogEntry message in messages)
    {
%>
        <div class="message_item">
            <% if (index == 0)
               { %>
                    <div class="section_title"><%:message.Title%></div>
            <% }
               index++;
            %>
            <%=message.Brief%>
            <%: Html.ActionLink(
                   UiResources.UiTexts.read_more,
                   WebUi.ViewModels.NavigationKeys.IndexAction,
                   WebUi.ViewModels.NavigationKeys.WeblogController,
                   new { url = message.Url },
                   null
                   )
            %>
        </div>
<%        
    }
%>