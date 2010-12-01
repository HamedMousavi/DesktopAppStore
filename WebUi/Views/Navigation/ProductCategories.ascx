<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<%            
    DomainModel.Entities.CategoryParent parent =
        DomainModel.Repository.Memory.Categories.Instance.Items
        [WebUi.Models.AppCulture.CurrentCulture.CultureId];

    WebUi.ViewModels.ListingInfo inf = 
        ViewData[WebUi.ViewModels.ViewDataKeys.HighlightedProductCategoryMenuItem]
            as WebUi.ViewModels.ListingInfo;
 %>
 <%: Html.AccordionList(parent, inf) %>
