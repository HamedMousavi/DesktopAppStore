<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebUi.ViewModels.ScreenshotInfo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%:UiResources.UiTexts.title_screenshots%> - <%:UiResources.UiTexts.app_title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CenterContent" runat="server">

    <div id="screenshots">
        <%
        string catalogUrl = Url.Action(
            WebUi.ViewModels.NavigationKeys.ProductCatalogAction,
            WebUi.ViewModels.NavigationKeys.ProductController,
            new { productName = Model.ProductName });        
        %>

        <div id="navigation_helper">
            <%:UiResources.UiTexts.inf_screenshot_thumbs %>
            <br />
            <a href="<%:catalogUrl%>"><%:string.Format(UiResources.UiTexts.inf_return_to_catalog, Model.ProductName) %></a>
        </div>

        <h2>
            <%:UiResources.UiTexts.screenshots%> <a href = "<%:catalogUrl%>"><%:Model.ProductName%></a>
        </h2>

        <div class="screenshot_description" style="text-align:<%:UiResources.UiTexts.float_left%>; width: <%:Model.Screenshots[Model.CurrentImageIndex].ImageSize.Width%>px;">
            <p>
                <span class="title"><%:Model.Screenshots[Model.CurrentImageIndex].Thumbnail.Title%></span>
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

        <div id="thumbs_holder">
            <ul id="thumbs_list">
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
                        WebUi.ViewModels.NavigationKeys.ProductController,
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
        
        
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>
