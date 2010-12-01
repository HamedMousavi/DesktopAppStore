<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DomainModel.Entities.ProductBase>" %>

    <div class = "search_results_item">

        <div class="list_title_link">
            <% string title = string.Format(
                   "{0} - ({1}:{2})", 
                   Model.ProductName, 
                   UiResources.UiTexts.product_version, 
                   Model.ProductVersion); %>
            <%: 
                Html.ActionLink(
                    title, 
                    WebUi.ViewModels.NavigationKeys.ProductCatalogAction, 
                    WebUi.ViewModels.NavigationKeys.ProductController, 
                    new { productName = Model.Catalog.UrlName }, 
                    null)
            %>
            <span style="float:<%:UiResources.UiTexts.float_right%>;">
            <%:Html.SoftwareRating(Model) %>
            </span>
        </div>
        

        <div>
            <span class="list_label"><%: UiResources.UiTexts.product_release_date%></span>
            <span class="list_field"><%: DomainModel.Tools.DateTime.Convert.ToCulture(Model.ProductReleaseDate, WebUi.Models.AppCulture.CurrentCulture) %></span>
        </div>

        <span class="list_label" style="margin:0 -20px; float:<%:UiResources.UiTexts.float_right%>;">
            <%: UiResources.UiTexts.product_update%> <%:DomainModel.Tools.DateTime.Convert.ToCulture(Model.Catalog.UpdateDate, WebUi.Models.AppCulture.CurrentCulture)%>
        </span>
        
        <div>
            <span class="list_label"><%: UiResources.UiTexts.product_price %></span>
            <span class="list_field"><%: DomainModel.Tools.Currencies.Format(Model.Price, WebUi.Models.AppCulture.CurrentCulture)%></span>
        </div>

        <span style="margin:0 -20px; float:<%:UiResources.UiTexts.float_right%>;">
        <%: 
            Html.ActionLink(
                UiResources.UiTexts.more_details, 
                WebUi.ViewModels.NavigationKeys.ProductCatalogAction, 
                WebUi.ViewModels.NavigationKeys.ProductController, 
                new { productName = Model.Catalog.UrlName }, 
                null)
            %>
            </span>
       
        <div>
            <span class="list_label"><%: UiResources.UiTexts.support_multiple_languages %></span>
            <span class="list_field"><%: Model.MultiLanguage?UiResources.UiTexts.has:UiResources.UiTexts.has_not %></span>
        </div>
        
        <div class="list_description"><%: Model.BriefDescription %></div>

        
    </div>


