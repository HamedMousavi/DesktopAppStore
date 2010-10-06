<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebUi.ViewModels.LoginInfo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Persian Softwares - Membership
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CenterContent" runat="server">

    <div class = "form">
        <h2><%: UiTexts.log_on %></h2>
        <% using (Html.BeginForm("Logon", "Members"/*, FormMethod.Post, new { @class = "form" }*/))
           { %>
            <%: Html.ValidationSummary(true, "Login was NOT successful. Please correct the errors and try again.") %>
                <fieldset>
                    <legend><%: UiTexts.account_information %></legend>
                
                    <div class="editor-label">
                        <%: Html.Label(UiTexts.email_address) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBox("Email") %>
                        <%: Html.ValidationMessage("Email")%>
                    </div>
                
                    <div class="editor-label">
                        <%: Html.Label(UiTexts.password) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.Password("Password") %>
                        <%: Html.ValidationMessage("Password") %>
                    </div>
                
                    <div class="editor-label">
                        <%: Html.CheckBox("RememberMe") %>
                        <%: Html.Label(UiTexts.remember_me)%>
                    </div>
                
                    <p>
                        <input type="submit" value="<%: UiTexts.enter %>" />
                    </p>
                </fieldset>
        <% } %>
    </div>
    <div class = "form">
        <h2><%: UiTexts.become_a_member %></h2>
            <%: Html.ActionLink(UiTexts.become_a_member, "Register", "Members") %>
    </div>
    <div class = "form">
        <h2><%: UiTexts.forgot_your_password %></h2>
        <%: Html.ActionLink(UiTexts.password_recovery_wizard, "ResetPassword", "Members") %>
    </div>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>
