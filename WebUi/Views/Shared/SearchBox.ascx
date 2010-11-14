<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<% using(Html.BeginForm(WebUi.ViewModels.NavigationKeys.SearchBasicAction, WebUi.ViewModels.NavigationKeys.SearchController)) %>
<% { %>
<%:     Html.Label(UiResources.UiTexts.search) %>
<%:     Html.TextBox("search_term") %>
        <input type="submit" value="<%: UiResources.UiTexts.search %>" />
<% } %>

