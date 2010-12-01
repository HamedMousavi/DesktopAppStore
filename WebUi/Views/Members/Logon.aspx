<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebUi.ViewModels.LoginInfo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Membership - <%:UiResources.UiTexts.app_title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CenterContent" runat="server">

    <div class="section_title"><%:UiTexts.log_on%></div>
    <%Html.RenderPartial("LogonForm");%>

    <div style="margin-top: 10px;">
        <div class="button_link" style="float:right; width: 49%; line-height:1.5em;">
            <div class="section_title"><%:UiTexts.become_a_member%></div>
            <%Html.RenderPartial("RegistrationForm");%>
        </div>
        <div class="button_link" style="float:left; width: 50%; line-height:1.5em;">
            <div class="section_title"><%: UiTexts.forgot_your_password %></div>
            <%: Html.ActionLink(UiTexts.password_recovery_wizard, WebUi.ViewModels.NavigationKeys.MemberResetPasswordAction, WebUi.ViewModels.NavigationKeys.MemberController) %>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>
