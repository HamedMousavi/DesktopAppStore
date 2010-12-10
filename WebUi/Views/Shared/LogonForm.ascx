<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>


<% using (Html.BeginForm(
       WebUi.ViewModels.NavigationKeys.MemberLogonAction, 
       WebUi.ViewModels.NavigationKeys.MemberController
       /*, FormMethod.Post, new { @class = "form" }*/))
    { %>

    <%: Html.ValidationSummary(true, "Login was NOT successful. Please correct the errors and try again.") %>
        <div class = "form">
            <p>
                <%: Html.Label(UiTexts.email_address) %>
                <%: Html.TextBox("Email") %>
                <%: Html.ValidationMessage("Email")%>
            </p>
                
            <p>
                <%: Html.Label(UiTexts.password) %>
                <%: Html.Password("Password") %>
                <%: Html.ValidationMessage("Password") %>
            </p>
                
            <p class="checkbox">
                <%: Html.CheckBox("RememberMe")%>
                <label for="RememberMe"><%:UiTexts.remember_me%></label>
            </p>
               
            <p class="submit">
                <input type="submit" value="<%: UiTexts.enter %>" />
                <%: Html.ActionLink(UiResources.UiTexts.become_a_member, WebUi.ViewModels.NavigationKeys.MemberRegisterAction, WebUi.ViewModels.NavigationKeys.MemberController)%>
                <%: Html.ActionLink(UiResources.UiTexts.forgot_your_password, WebUi.ViewModels.NavigationKeys.MemberResetPasswordAction, WebUi.ViewModels.NavigationKeys.MemberController)%>
            </p> 
            <input type="hidden" name="ReturnUrl" value="<%:Request.Url.AbsoluteUri%>" />
        </div>
<% } %>

