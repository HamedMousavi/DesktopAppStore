<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%: UiResources.UiTexts.language %>: 
<% 
object htmlAttribs;

foreach (DomainModel.Entities.ProductLanguage item in DomainModel.Repository.Memory.Languages.Instance.Items)
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
        item.Name, 
        "Index", 
        "Culture", 
        new { SelectedCulture = item.CultureId, ReturnUrl = Request.Url.AbsoluteUri },
        htmlAttribs)
    %>
<%}%>

<!--// MVC Get current URL action and controller(navigation options) -->