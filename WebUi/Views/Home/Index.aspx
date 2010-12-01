<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%:UiResources.UiTexts.title_index %> - <%:UiResources.UiTexts.app_title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CenterContent" runat="server">
<!--/*    
    <div class="section_title"><%:UiResources.UiTexts.best_softwares%></div>
*/-->
    <div class="section_title"><%:UiResources.UiTexts.popular_products%></div>

    <div id="best_products">
<!--/*
        <div id="featured_products">
            <div class="title"><h2><%:UiResources.UiTexts.featured_products %></h2></div>
            <% Html.RenderPartial("FeaturedProducts"); %>
        </div>
*/-->
        <div id="popular_products">
            <!--/*<div class="title"><h2><%:UiResources.UiTexts.popular_products%></h2></div>*/-->
            <% Html.RenderPartial("PopularProducts"); %>
        </div>
    </div>

    <div id="messages">
        <% Html.RenderPartial("WeblogSummary"); %>
    </div>
<!--/*
    <div id="software_school">
        <div class="title"><h2><%:UiResources.UiTexts.software_school%></h2></div>
        <% Html.RenderPartial("SoftwareSchool"); %>
    </div>
*/-->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>
