<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DomainModel.Entities.ApplicationProduct>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%:UiResources.UiTexts.title_catalog%> - <%:UiResources.UiTexts.app_title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CenterContent" runat="server">


    <div id="catalog">

        <div class="title" style="float:<%:UiResources.UiTexts.float_left%>;">
            <%: Model.ProductName%>
        </div>
        <span style="float:<%:UiResources.UiTexts.float_right%>; margin: 20px 4px 0px 4px;"><%Html.RenderPartial("ProductRating");%></span>
        
        <div class="info_bar" style="clear:<%:UiResources.UiTexts.float_left%>;">
            <span><%: DomainModel.Tools.DateTime.Convert.ToCulture(Model.Catalog.UpdateDate, WebUi.Models.AppCulture.CurrentCulture)%></span>
            <span class="pager_inf_separator">|</span>
            <span><%: UiResources.UiTexts.views %></span>:
            <span><b><%: (Model.Catalog.ViewsCount == null) ? "0" : Model.Catalog.ViewsCount.Value.ToString() %></b></span>
            <span class="pager_inf_separator">|</span>
            <span><a href="<%: Request.Url.AbsoluteUri %>#discuss"><%: UiResources.UiTexts.discuss%></a> </span>
            <span class="pager_inf_separator">|</span>
            <span><a href="<%: Request.Url.AbsoluteUri %>?print=1"><%: UiResources.UiTexts.print%></a> </span>
        </div>

        <div id="showcase">
            <div id="screenshot" style="float:<%:UiResources.UiTexts.float_left%>;">
                <%: Html.SoftwareScreenshot(Model, Request.Url.AbsoluteUri)%>
            </div>

            <div id="overview" style="margin-<%:UiResources.UiTexts.float_left%>:20px;">
                <% Html.RenderPartial("ProductVotingBar"); %>

                <div id="product_overview">
                    <div class="overview_title"><%:UiResources.UiTexts.overview %></div>
                    <dl>
                        <dt class="overview_head" style="float:<%:UiResources.UiTexts.float_left%>;"><%:UiResources.UiTexts.product_version%></dt>
                        <dd class="overview_item" style="text-align:<%:UiResources.UiTexts.float_right%>;"><%:Model.ProductVersion %></dd>
                        <dt class="overview_head" style="float:<%:UiResources.UiTexts.float_left%>;"><%:UiResources.UiTexts.product_price%></dt>
                        <dd class="overview_item" style="text-align:<%:UiResources.UiTexts.float_right%>;"><%: DomainModel.Tools.Currencies.Format(Model.Price, WebUi.Models.AppCulture.CurrentCulture) %></dd>
                        <dt class="overview_head" style="float:<%:UiResources.UiTexts.float_left%>;"><%:UiResources.UiTexts.product_release_date%></dt>
                        <dd class="overview_item" style="text-align:<%:UiResources.UiTexts.float_right%>;"><%: DomainModel.Tools.DateTime.Convert.ToCulture(Model.ProductReleaseDate, WebUi.Models.AppCulture.CurrentCulture) %></dd>
                        <dt class="overview_head" style="float:<%:UiResources.UiTexts.float_left%>;"><%:UiResources.UiTexts.product_languages%></dt>
                        <dd class="overview_item" style="text-align:<%:UiResources.UiTexts.float_right%>;"><%: Html.LanguageOverview(Model, Request.Url.AbsoluteUri) %></dd>
                        <dt class="overview_head" style="float:<%:UiResources.UiTexts.float_left%>;"><%:UiResources.UiTexts.product_language_extendable%></dt>
                        <dd class="overview_item" style="text-align:<%:UiResources.UiTexts.float_right%>;"><%:Model.LanguageExtendable?UiResources.UiTexts.has:UiResources.UiTexts.has_not %></dd>
                        <dt class="overview_head" style="float:<%:UiResources.UiTexts.float_left%>;"><%:UiResources.UiTexts.product_volume_size%></dt>
                        <dd class="overview_item" style="text-align:<%:UiResources.UiTexts.float_right%>;"><%:Model.MinimumVolumeSize%>  <%: UiResources.UiTexts.megabytes %></dd>
                        <dt class="overview_head" style="float:<%:UiResources.UiTexts.float_left%>;"><%:UiResources.UiTexts.website%></dt>
                        <dd class="overview_item" style="text-align:<%:UiResources.UiTexts.float_right%>;"><a href="<%:Model.ProductWebsite%>"><%:Model.ProductWebsite.Replace("https://", "").Replace("http://", "") %></a></dd>
                    </dl>
                </div>


                <!--/*
                <div id="product_awards">
                    <img style="margin: 4px;" alt="Product awards" src="/Content/Images/awards_logo.png" />
                    <%:Html.SoftwareAwards(
                        Model, 
                        Url.Action(
                            WebUi.ViewModels.NavigationKeys.ProductAwardsAction, 
                            WebUi.ViewModels.NavigationKeys.ProductController,
                            new { productName = Model.Catalog.UrlName }))%>
                </div>*/-->
            </div>
            
        </div>

        <div id="article">
            <h2><%:UiResources.UiTexts.product_brief_description %></h2>
            <p><%:Model.BriefDescription %></p>

            <h2><%:UiResources.UiTexts.product_environment%></h2>
            <dl>
                <dt><%:UiResources.UiTexts.product_software_platform %></dt>
                <dd><%:Html.SoftwareOptions(Model.SupportedPlatforms)%></dd>

                <dt><%:UiResources.UiTexts.product_hardware_requirements %></dt>
                <dd><%:Html.HardwareRequirements(Model) %></dd>

                <dt><%:UiResources.UiTexts.product_software_requirements%></dt>
                <dd><%:Html.SoftwareOptions(Model.ProductTechnologies)%></dd>

                <dt><%:UiResources.UiTexts.product_network%></dt>
                <dd><%:Html.SoftwareOptions(Model.EnvironmentOptions)%></dd>
            </dl>

            <br />
        
            <h2><%:UiResources.UiTexts.technical_details%></h2>
            <dl>
                <dt><%:UiResources.UiTexts.product_languages %></dt>
                <dd><%:Html.SoftwareOptions(Model.SupportedLanguages)%></dd>

                <dt><%:UiResources.UiTexts.product_languages_extendablity %></dt>
                <dd><%:Model.LanguageExtendable?UiResources.UiTexts.has:UiResources.UiTexts.has_not %></dd>

                <dt><%:UiResources.UiTexts.product_demo %></dt>
                <dd><%:Html.SoftwareOptions(Model.DemoOptions)%></dd>

                <dt><%:UiResources.UiTexts.product_installation%></dt>
                <dd><%:Html.SoftwareOptions(Model.InstallationOptions)%></dd>

                <dt><%:UiResources.UiTexts.product_access%></dt>
                <dd><%:Html.SoftwareOptions(Model.PublishOptions)%></dd>

                <dt><%:UiResources.UiTexts.product_backup%></dt>
                <dd><%:Html.SoftwareOptions(Model.BackupOptions)%></dd>

                <dt><%:UiResources.UiTexts.product_update%></dt>
                <dd><%:Html.SoftwareOptions(Model.UpdateOptions)%></dd>

                <dt><%:UiResources.UiTexts.product_extendabilities%></dt>
                <dd><%:Html.SoftwareOptions(Model.ExtensionOptions)%></dd>
            </dl>

            <h2><%:UiResources.UiTexts.legal_details%></h2>
            <dl>
                <dt><%:UiResources.UiTexts.product_guaranty%></dt>
                <dd><%:Html.SoftwareOptions(Model.GuarantyOptions)%></dd>

                <dt><%:UiResources.UiTexts.product_customization%></dt>
                <dd><%:Html.SoftwareOptions(Model.CustomizationOptions)%></dd>

                <dt><%:UiResources.UiTexts.product_support%></dt>
                <dd><%:Html.SoftwareOptions(Model.SupportOptions)%></dd>

                <dt><%:UiResources.UiTexts.product_support_access%></dt>
                <dd><%:Html.SoftwareOptions(Model.SupportTypes)%></dd>

                <dt><%:UiResources.UiTexts.product_source%></dt>
                <dd><%:Html.SoftwareOptions(Model.SourceOptions)%></dd>

                <dt><%:UiResources.UiTexts.product_payment%></dt>
                <dd><%:Html.SoftwareOptions(Model.PaymentOptions)%></dd>

                <dt><%:UiResources.UiTexts.product_price_details%></dt>
                <dd><%:Model.PriceDetails%></dd>
            </dl>

            <h2><%:UiResources.UiTexts.extra_services%></h2>
            <dl>
                <dt><%:UiResources.UiTexts.product_training%></dt>
                <dd><%:Html.SoftwareOptions(Model.TrainingOptions)%></dd>
            </dl>

            <br />

            <h2><%:UiResources.UiTexts.product_contacts %></h2>
            <%:Html.SoftwareContacts(Model.ProductContacts)%>

            <br />

            <h2><%:UiResources.UiTexts.producer_comments %></h2>
            <%= Model.Article.Content %>
        </div>
    </div>




</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightContent" runat="server">

    <div id="related_tags">
        <div class="section_title"><%:UiResources.UiTexts.related_tags%></div>
        <ul>
            <%:Html.SoftwareTags(Model.Tags)%>
        </ul>
    </div>

</asp:Content>
