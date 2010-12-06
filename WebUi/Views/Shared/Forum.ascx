<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DomainModel.Entities.Forum>" %>

    <div class="forum">
        <div class="forum_title">Discussion area. Have your sayings:</div>
        <div class="forum_body">
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
