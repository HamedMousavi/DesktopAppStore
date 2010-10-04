<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<%
    DomainModel.Entities.CategoryParent parent = 
        DomainModel.Repository.Memory.Categories.Instance.Items[WebUi.Models.AppCulture.CurrentCulture.CultureId];
%>
<%: Html.AccordionList(parent)%>
