<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<DomainModel.Entities.ProductBase>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%:UiResources.UiTexts.title_list %> - <%:UiResources.UiTexts.app_title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CenterContent" runat="server">
    <div class="home_section_bar">
        <% Html.RenderAction("DesktopSections", "Navigation"); %>

        <div class="home_content">

            <% WebUi.ViewModels.PagingInfo pagingData = 
                   (WebUi.ViewModels.PagingInfo)ViewData[
                        WebUi.ViewModels.ViewDataKeys.ListPagingDetails]; %>
            
            <div class="page_title"><%:pagingData.listTitle%></div>

            <div class="search_results">
        
                <%
                    foreach (var product in Model)
                    {
                        Html.RenderPartial("ProductSummary", product);
                    }
                %>
            </div>

            <div class="list_pager">
                <%: Html.ListDetail(pagingData) %>
        
                <%: Html.PageLinks(Url, pagingData) %>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
    <div id="product_categories">
        <div class="section_title product_categories_title">
            <%:UiResources.UiTexts.software_categories%>
        </div>
        <% Html.RenderAction("ProductCategories", "Navigation"); %>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
