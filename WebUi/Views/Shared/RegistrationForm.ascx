<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<% using (Html.BeginForm(WebUi.ViewModels.NavigationKeys.MemberRegisterAction, WebUi.ViewModels.NavigationKeys.MemberController/*, FormMethod.Post, new { @class="form" }*/))
    { %>
    <%: Html.ValidationSummary()%>
    
    <div class="form">
        <div class="editor-label">
            <%: Html.Label(UiTexts.email_address)%>
        </div>

        <div class="editor-field">
            <%: Html.TextBox("Email")%>
            <!--/*<%: Html.ValidationMessage("Email")%>*/-->
        </div>

        <p>
            <input type="submit" value="<%: UiTexts.register %>" />
        </p>

    </div>
<% } %>
