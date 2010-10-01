<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<% using(Html.BeginForm("Basic", "Search")) %>
<% { %>
<%:     Html.Label(UiResources.UiTexts.search) %>
<%:     Html.TextBox("search_term") %>
        <input type="submit" value="<%: UiResources.UiTexts.search %>" />
<% } %>

