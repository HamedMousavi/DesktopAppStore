<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Members/Members.Master" Inherits="System.Web.Mvc.ViewPage<DomainModel.Abstract.IUser>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%:UiResources.UiTexts.title_profile%> - <%:UiResources.UiTexts.app_title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CenterContent" runat="server">
    
<div class="home_content">
    <div class="page_title">
        <%: UiResources.UiTexts.title_profile %>
    </div>

    <div class="profile">

        <%
            string displayName;
        
            DomainModel.Entities.ProductOwnerDetails owner =
                Model.Profile.Ownership.Details[
                    WebUi.Models.AppCulture.CurrentCulture.CultureId];
        
            if (owner == null) displayName = Model.Profile.DislayName;
            else
            {
                displayName = owner.DisplayName;
            }
        %>

        <!--
        <h1>Logo</h1>
        <p>For Users: Maybe display a personal photo.</p>
        <p>For owners: Display all logos of the owner.</p>
        -->

        <h1><%:displayName %></h1>

        <div class="info_bar">
            <span><%:UiResources.UiTexts.member_since %><%:DomainModel.Tools.DateTime.Convert.ToCulture(Model.MembershipDate, WebUi.Models.AppCulture.CurrentCulture) %></span>
        
            <span class="pager_inf_separator">|</span>
            <span>
                <a href="<%: Request.Url.AbsoluteUri %>#products">
                    <%:UiResources.UiTexts.registered_products %> (<%:owner.Products.Count %>)
                </a>
            </span>
        
            <span class="pager_inf_separator">|</span>
            <span>
                <a href="<%: Request.Url.AbsoluteUri %>#branches">
                    <%:UiResources.UiTexts.branches%> (<%:owner.Branches.Count %>)
                </a>
            </span>

            <span class="pager_inf_separator">|</span>
            <span>
                <a href="<%: Request.Url.AbsoluteUri %>#discuss">
                    <%: UiResources.UiTexts.discuss%><%:string.Format(" ({0}) ", Model.Profile.Forum.TotalMessageCount)%>
                </a> 
            </span>
        </div>

        <img class="logo" alt="logo" src="<%:Model.Profile.Logos[0].Url %>" />

        <a name="products" class="hidden"></a>
        <p class="overview_title"><%:UiResources.UiTexts.registered_products %></p>
        <%
            foreach (var product in owner.Products)
            {
                Html.RenderPartial("ProductSummary", product);
            }
        %>

        <a name="branches" class="hidden"></a>
        <p class="overview_title"><%:UiResources.UiTexts.branches %></p>
        <%
            foreach (DomainModel.Entities.OwnerBranch branch in owner.Branches)
            {
                Html.RenderPartial("ProductOwnerBranch", branch);
            }
        %>

        <!--
        <h1>Brands</h1>
        <p>If owner has a brand to advertise, details can go here!</p>
        -->
        <%Html.RenderPartial("Forum", Model.Profile.Forum); %>

    </div>

</div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">

    <p>
        For Owners & Users: A discussion forum will be here.
    </p>
</asp:Content>
