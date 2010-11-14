<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<%
    DomainModel.Entities.GeneralDatabaseList products = 
        DomainModel.Repository.Sql.Products.GetPopular(
            WebUi.Models.AppCulture.CurrentCulture.CultureId);
    
    foreach (DomainModel.Entities.ProductBase product in products.List)
     {
          Html.RenderPartial("ProductSummary", product);
     }
 %>