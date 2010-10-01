<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<%
    DomainModel.Entities.CategoryParent parent = 
        DomainModel.Repository.Memory.Categories.Instance.Items[WebUi.Models.AppCulture.CurrentCulture.CultureId];
    foreach (DomainModel.Entities.Category cat in parent)
    {
%>
        <%:            
        // Draw parent
        Html.Label(cat.CategoryName)
        %>
<%
        foreach(DomainModel.Entities.Category sub in cat.SubCategories)
        {
%>
            <%:                
            // Add sub category
            Html.Label("  " + sub.CategoryName)
            %>
<%
        }
    }
 %>