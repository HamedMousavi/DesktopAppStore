<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<div id="members_toolbox">
    <div class="section_title"><%:UiResources.UiTexts.members%></div>

    <%
        if (WebUi.Models.Security.CurrentUser != null)
        {
            string urlref;
            int selected = -1;
            if (ViewData[WebUi.ViewModels.ViewDataKeys.HighlightedMemberMenuItem] != null)
            {
                selected = Convert.ToInt32(ViewData[WebUi.ViewModels.ViewDataKeys.HighlightedMemberMenuItem]);
            }
    %>
            <p>
                <%: UiResources.UiTexts.welcome%>
                <% if (WebUi.Models.Security.CurrentUser == null || WebUi.Models.Security.CurrentUser.Profile == null) 
                   {%>
                        <b><%:UiResources.UiTexts.anonymous%></b>!
                <% } %>
                <% else
                   { %>
                        <b><%:WebUi.Models.Security.CurrentUser.Profile.DislayName %></b>!
                <% } %>
            </p>
            <ul>
                <li class="<%:(selected == 0)? "selected" : "normal"%>">
                    <% urlref = Url.Action(
                            WebUi.ViewModels.NavigationKeys.MemberProfileAction,
                            WebUi.ViewModels.NavigationKeys.MemberController,
                            new { user = WebUi.Models.Security.CurrentUser.Id });%>

                    <a href="<%:urlref%>">
                        <img src="/Content/Images/Members/profile.png" alt="profile icon" />
                        <%:UiResources.UiTexts.my_profile%>
                    </a>
                </li>

                <li class="<%:(selected == 1)? "selected" : "normal"%>">
                    <% urlref = Url.Action(
                            WebUi.ViewModels.NavigationKeys.MemberSettingsAction,
                            WebUi.ViewModels.NavigationKeys.MemberController,
                            new { user = WebUi.Models.Security.CurrentUser.Id });%>

                    <a href="<%:urlref%>">
                        <img src="/Content/Images/Members/settings.png" alt="settings icon" />
                        <%:UiResources.UiTexts.my_settings%>
                    </a>
                </li>
                    
                <li>
                    <% urlref = Url.Action(
                            WebUi.ViewModels.NavigationKeys.MemberContactAdminAction,
                            WebUi.ViewModels.NavigationKeys.MemberController,
                            new { user = WebUi.Models.Security.CurrentUser.Id });%>

                    <a href="<%:urlref%>">
                        <img src="/Content/Images/Members/contact.png" alt="contact icon" />
                        <%:UiResources.UiTexts.contact_admin%>
                    </a>
                </li>

                <li>
                    <% urlref = Url.Action(
                            WebUi.ViewModels.NavigationKeys.MemberLogoffAction,
                            WebUi.ViewModels.NavigationKeys.MemberController);%>

                    <a href="<%:urlref%>">
                        <img src="/Content/Images/Members/log_off.png" alt="log_off icon" />
                        <%:UiResources.UiTexts.log_off%>
                    </a>
                </li>

            </ul>
    <%
        }
        else
        {
            Html.RenderPartial("LogonForm");
        }
    %>
</div>
