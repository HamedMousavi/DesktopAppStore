<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<%
    if (Request.IsAuthenticated) {
%>
        <%: UiResources.UiTexts.welcome %> <b><%: Page.User.Identity.Name %></b>!
        <%: Html.ActionLink(UiResources.UiTexts.log_off, "LogOff", "Members") %>
<%
    }
    else {
%> 
        <%: Html.ActionLink(UiResources.UiTexts.log_on, "LogOn", "Members")%>
        <%: Html.ActionLink(UiResources.UiTexts.become_a_member, "Register", "Members")%>
<%
    }
%>
