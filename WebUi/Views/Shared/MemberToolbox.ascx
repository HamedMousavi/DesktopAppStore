<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<div id="members_toolbox">
    <div class="section_title"><%:UiResources.UiTexts.members%></div>

    <%
        if (Request.IsAuthenticated)
        {
    %>
            <%: UiResources.UiTexts.welcome%>
            <% if (WebUi.Models.Security.CurrentUser == null || WebUi.Models.Security.CurrentUser.Profile == null) 
               {%>
                    <b><%:UiResources.UiTexts.anonymous%></b>!
            <% } %>
            <% else
               { %>
                    <b><%:WebUi.Models.Security.CurrentUser.Profile.DislayName %></b>!
            <% } %>

            <%: Html.ActionLink(UiResources.UiTexts.log_off, WebUi.ViewModels.NavigationKeys.MemberLogoffAction, WebUi.ViewModels.NavigationKeys.MemberController)%>
    <%
        }
        else
        {
            Html.RenderPartial("LogonForm");
        }
    %>
</div>
