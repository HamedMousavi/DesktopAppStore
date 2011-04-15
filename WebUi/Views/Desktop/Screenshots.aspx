<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Desktop/Product.Master" Inherits="System.Web.Mvc.ViewPage<WebUi.ViewModels.ScreenshotInfo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%:UiResources.UiTexts.title_screenshots%> - <%:UiResources.UiTexts.app_title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CenterContent" runat="server">

<%
string catalogUrl = Url.Action(
    WebUi.ViewModels.NavigationKeys.ProductCatalogAction,
    WebUi.ViewModels.NavigationKeys.ProductController,
    new { productName = Model.ProductName });        
%>

    <div class="home_content">
        <span class="page_title"><%:UiResources.UiTexts.screenshots%></span>

        <% if (Model.Screenshots.Count > 0)
           {
        %>

        <div class="thumbs_holder">
            <ul class="thumbs_list">
            <% 
            int index = 0;
            string style;
            foreach (DomainModel.Entities.ProductImage screenshot in Model.Screenshots)
            {
                if (Model.CurrentImageIndex == index)
                {
                    style = "selected";
                }
                else
                {
                    style = "normal";
                }

                string target = Url.Action(
                    WebUi.ViewModels.NavigationKeys.ProductScreenshotsAction,
                    WebUi.ViewModels.NavigationKeys.DesktopController,
                    new { imageIndex = index + 1 });
            %> 
                    <li class="<%:style%>">
                        <div class="thumb_title" style="text-align:<%:UiResources.UiTexts.float_left%>;">
                            <a href="<%:target%>"><%:screenshot.Thumbnail.Title%></a>
                        </div>
                        <a href="<%:target%>">
                            <img alt="<%:screenshot.Description%>" src="<%:screenshot.Thumbnail.Url%>" width="120" height="80" />
                        </a>
                    </li>
            <%
                    
            index++;
            } 
            %>
            </ul>
        </div>

        <div class="screenshot_description" style="text-align:<%:UiResources.UiTexts.float_left%>;">
            <p>
                <span class="overview_title"><%:Model.Screenshots[Model.CurrentImageIndex].Thumbnail.Title%></span>
                <br />
                <span class="text"><%:Model.Screenshots[Model.CurrentImageIndex].Description%></span>
            </p>
        </div>

        <div class="screenshot_holder">

            <div class="selected_screenshot">
                <img alt="<%:Model.Screenshots[Model.CurrentImageIndex].Description%>" 
                        src="<%:Model.Screenshots[Model.CurrentImageIndex].Url%>" 
                        width="<%:Model.Screenshots[Model.CurrentImageIndex].ImageSize.Width%>"
                        height="<%:Model.Screenshots[Model.CurrentImageIndex].ImageSize.Height%>" />
            </div>
        </div>

        <%}
           else
           {
        %>
            <div id="navigation_helper"><%:UiResources.UiTexts.no_screenshot_available %></div>
            <br />
        <% } %>
    </div>        
    

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>
