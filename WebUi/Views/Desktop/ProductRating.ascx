<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DomainModel.Entities.ProductBase>" %>

<div id="product_rating">
<%:Html.SoftwareRating(Model)%>
<b><%:Model.Catalog.UserRating%> <%:UiResources.UiTexts.of%> 5.0</b>
<span class="pager_inf_separator">|</span>
<%:UiResources.UiTexts.votes%>: <%:Model.Catalog.VoteCounts %>
</div>