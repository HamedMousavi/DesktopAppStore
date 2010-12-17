<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<div class="voting_bar">
    <% 
        if (WebUi.Models.Security.CurrentUser != null)
        {
            DomainModel.Entities.ProductBase product =
                Model as DomainModel.Entities.ProductBase;

            using (Html.BeginForm(
                   WebUi.ViewModels.NavigationKeys.MemberVoteProductAction,
                   WebUi.ViewModels.NavigationKeys.MemberController))
            {
                
     %>
                <% if (product != null && product.Catalog != null && product.Catalog.CurrentUserRating > 0) 
                   {%>
                        <span style="margin-bottom: 8px;">
                            <%:string.Format(UiResources.UiTexts.your_vote, product.Catalog.CurrentUserRating) %>
                        </span>
                <%  } %>
                <div>
                    <span><%:UiResources.UiTexts.poor_product %></span>
                    <input type="radio" value="1" name="VoteValue" id="vote1" />
                    <input type="radio" value="2" name="VoteValue" id="vote2" />
                    <input type="radio" value="3" name="VoteValue" id="vote3" />
                    <input type="radio" value="4" name="VoteValue" id="vote4" />
                    <input type="radio" value="5" name="VoteValue" id="vote5" />
                    <span><%:UiResources.UiTexts.excellent_product%></span>

                    <input type="submit" value="<%:UiResources.UiTexts.vote%>" />
                </div>
                <input type="hidden" name="ReturnUrl" value="<%:Request.Url.AbsoluteUri%>" />
                <input type="hidden" name="ProductId" value="<%:Model.ProductId%>" />
                <input type="hidden" name="UserName" value="<%:WebUi.Models.Security.CurrentUser==null? -1: WebUi.Models.Security.CurrentUser.Id%>" />
    <%
            }
        }
        else
        {
    %>
            <%:UiResources.UiTexts.login_to_vote%>
    <%
        }
    %>
</div>
