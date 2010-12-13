<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DomainModel.Entities.Forum>" %>

    <div class="forum">
        <a name="discuss"></a>
        <div class="forum_title">
            <%:UiResources.UiTexts.discuss%>
        </div>
        <div class="forum_body">
        
        <div class="discussion_control_panel">
            <%if (Request.IsAuthenticated)
              {
                  if (DomainModel.Security.InputController.IsValid(Model.UrlName))
                  {
            %>
                        <a href="<%:string.Format("/Products/{0}/Discussions/{1}", Model.UrlName, WebUi.ViewModels.NavigationKeys.DiscussionsNewAction) %>"><%:UiResources.UiTexts.new_discussion%></a>
            <%  
                  }   
              }
              else
              {
            %>
                <%:UiResources.UiTexts.login_to_manage_comments %>
            <%} %>
        </div>

        <% 
            foreach (DomainModel.Entities.Discussion discussion in Model)
            {
        %>      
                <div class="forum_discussion">
                    <%:Html.ForumDiscussions(discussion)%>
                </div>
        <%
            }   
        %>
        </div>
    </div>
