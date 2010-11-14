<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%:UiResources.UiTexts.title_index %> - <%:UiResources.UiTexts.app_title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CenterContent" runat="server">
    <div id="best_products">
        <div id="featured_products">
            <div class="title"><%:UiResources.UiTexts.featured_products %></div>
            <% Html.RenderPartial("FeaturedProducts"); %>
        </div>

        <div id="popular_products">
            <div class="title"><%:UiResources.UiTexts.popular_products%></div>
            <% Html.RenderPartial("PopularProducts"); %>
        </div>
    </div>

    <div id="software_school">
        <div class="title"><%:UiResources.UiTexts.software_school%></div>
        <% Html.RenderPartial("SoftwareSchool"); %>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>
