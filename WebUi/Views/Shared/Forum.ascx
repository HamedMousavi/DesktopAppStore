<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DomainModel.Entities.Forum>" %>

    <div class="forum">
        <a name="discuss" class="hidden"></a>
        <div class="forum_title">
            <%:UiResources.UiTexts.discuss%>
        </div>
        <div class="forum_body">
        
        <div class="discussion_control_panel">
            <%if (WebUi.Models.Security.CurrentUser != null)
              {
                  if (DomainModel.Security.InputController.IsValid(Model.UrlName))
                  {
            %>
                        <a href="<%:string.Format("/Discussions/{0}/{1}/{2}?returnUrl={3}", 
                                        WebUi.ViewModels.NavigationKeys.DiscussionsNewAction,
                                        Model.ForumId,
                                        Model.PageId,
                                        Request.Url.AbsoluteUri) %>">
                            <%:UiResources.UiTexts.new_discussion%>
                        </a>
            <%  
                  }
              }
              else
              {
            %>
                <%:UiResources.UiTexts.login_to_manage_comments %>
            <%} %>
        </div>

        <%Model.ForumPageUrl = Request.Url.AbsoluteUri;%>
        <%:Html.Forum(Model)%>
        </div>
    </div>
