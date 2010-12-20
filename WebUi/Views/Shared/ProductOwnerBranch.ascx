<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DomainModel.Entities.OwnerBranch>" %>

Blah blah blah
<%
    Html.RenderPartial("Address", Model.Address);
    Html.RenderPartial("Contacts", Model.Contacts);
 %>