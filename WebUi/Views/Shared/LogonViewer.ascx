<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<%
    if (Request.IsAuthenticated) {
%>
        <%: UiResources.UiTexts.welcome %> <b><%: Page.User.Identity.Name %></b>!
        <%: Html.ActionLink(UiResources.UiTexts.log_off, WebUi.ViewModels.NavigationKeys.MemberLogoffAction, WebUi.ViewModels.NavigationKeys.MemberController) %>
<%
    }
    else {
%> 
    <ul>
        <li><%: Html.ActionLink(UiResources.UiTexts.log_on, WebUi.ViewModels.NavigationKeys.MemberLogonAction, WebUi.ViewModels.NavigationKeys.MemberController)%></li>
        <li><%: Html.ActionLink(UiResources.UiTexts.become_a_member, WebUi.ViewModels.NavigationKeys.MemberRegisterAction, WebUi.ViewModels.NavigationKeys.MemberController)%></li>
    </ul>
<%
    }
%>
