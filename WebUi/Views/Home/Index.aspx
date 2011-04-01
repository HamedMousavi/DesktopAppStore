<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%:UiResources.UiTexts.title_index %> - <%:UiResources.UiTexts.app_title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CenterContent" runat="server">
<!--/*    
    <div class="section_title"><%:UiResources.UiTexts.best_softwares%></div>
    <div class="section_title"><%:UiResources.UiTexts.popular_products%></div>
*/-->
    <div class="home_section_bar">
        <ul>
            <li><%:Html.ActionLink(
                        UiResources.UiTexts.product_list_sort_release,
                        WebUi.ViewModels.NavigationKeys.IndexAction,
                        WebUi.ViewModels.NavigationKeys.HomeController) %>
            </li>

            <li><%:Html.ActionLink(
                        UiResources.UiTexts.product_list_sort_price,
                        WebUi.ViewModels.NavigationKeys.IndexAction,
                        WebUi.ViewModels.NavigationKeys.ProductController,
                        new { Class="selected" } )%>
            </li>

            <li><%:Html.ActionLink(
                        UiResources.UiTexts.product_list_sort_popularity,
                        WebUi.ViewModels.NavigationKeys.IndexAction,
                        WebUi.ViewModels.NavigationKeys.ProductController) %>
            </li>

            <li><%:Html.ActionLink(
                        UiResources.UiTexts.product_list_user_rating,
                        WebUi.ViewModels.NavigationKeys.IndexAction,
                        WebUi.ViewModels.NavigationKeys.ProductController) %>
            </li>
        </ul>
        <div class="home_content">

            <div style="font-size:2em; font-family: Roman; font-weight:bold; padding: 20px 10px;" >ارزانترین نرم افزارهای کامپیوتر</div>
            <div id="best_products">
                <div id="popular_products">
                    <% Html.RenderPartial("PopularProducts"); %>
                </div>
            </div>

            <div id="messages">
                <% Html.RenderPartial("WeblogSummary"); %>
            </div>
        </div>
    </div>
<!--/*
    <div id="best_products">

<!--/*
        <div id="featured_products">
            <div class="title"><h2><%:UiResources.UiTexts.featured_products %></h2></div>
            <% Html.RenderPartial("FeaturedProducts"); %>
        </div>

        <div id="popular_products">
            <!--/*<div class="title"><h2><%:UiResources.UiTexts.popular_products%></h2></div>
            <% Html.RenderPartial("PopularProducts"); %>
        </div>
    </div>

    <div id="messages">
        <% Html.RenderPartial("WeblogSummary"); %>
    </div>

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
