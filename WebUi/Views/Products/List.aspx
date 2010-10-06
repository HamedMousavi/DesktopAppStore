<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<DomainModel.Entities.ProductBase>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CenterContent" runat="server">

    <div class="search_results">
        
        <%
            foreach (var product in Model)
            {
                Html.RenderPartial("ProductSummary", product);
            }
         %>

    </div>

    <div class="list_pager button_link">
        <% WebUi.ViewModels.PagingInfo pagingData = (WebUi.ViewModels.PagingInfo)ViewData[WebUi.ViewModels.ViewDataKeys.ListPagingDetails]; %>
        
        <%: Html.ListDetail(pagingData) %>

        <%: Html.PageLinks(Url, pagingData) %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>
