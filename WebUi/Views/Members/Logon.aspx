<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Members/Members.Master" Inherits="System.Web.Mvc.ViewPage<WebUi.ViewModels.LoginInfo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Membership - <%:UiResources.UiTexts.app_title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CenterContent" runat="server">
    <div class="home_content">
        <div class="page_title">
            <%: UiResources.UiTexts.log_on %>
        </div>

        <%Html.RenderPartial("LogonForm");%>

        <br />
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>
