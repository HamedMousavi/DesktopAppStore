<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>


<% using (Html.BeginForm(
       WebUi.ViewModels.NavigationKeys.MemberLogonAction, 
       WebUi.ViewModels.NavigationKeys.MemberController
       /*, FormMethod.Post, new { @class = "form" }*/))
    { %>

    <%: Html.ValidationSummary(true, "Login was NOT successful. Please correct the errors and try again.") %>
        <div class = "form">
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
                
            <input type="submit" value="<%: UiTexts.enter %>" />
            <%: Html.ActionLink(UiResources.UiTexts.become_a_member, WebUi.ViewModels.NavigationKeys.MemberRegisterAction, WebUi.ViewModels.NavigationKeys.MemberController)%>
            <%: Html.ActionLink(UiResources.UiTexts.forgot_your_password, WebUi.ViewModels.NavigationKeys.MemberResetPasswordAction, WebUi.ViewModels.NavigationKeys.MemberController)%>
            <input type="hidden" name="ReturnUrl" value="<%:Request.Url.AbsoluteUri%>" />
        </div>
<% } %>

