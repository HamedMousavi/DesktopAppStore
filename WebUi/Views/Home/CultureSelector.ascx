<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<% 
object htmlAttribs;

foreach (WebUi.Models.CultureItem item in WebUi.Models.AppCulture.CultureList)
{
    if (item == WebUi.Models.AppCulture.CurrentCulture)
    {
        htmlAttribs = new { @class = "selected" };
    }
    else
    {
        htmlAttribs = null;
    }
%>
       
<%:
    Html.ActionLink(
        item.Text, 
        "Index", 
        "Culture", 
        new { SelectedCulture = item.Culture, ReturnUrl = Request.Url.AbsoluteUri },
        htmlAttribs)
%>
<%}%>
<!--// MVC Get current URL action and controller(navigation options) -->