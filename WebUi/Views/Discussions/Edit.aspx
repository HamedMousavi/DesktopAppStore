<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebUi.ViewModels.DiscussionInfo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%:UiResources.UiTexts.title_discussion_edit%> - <%:UiResources.UiTexts.app_title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CenterContent" runat="server">

<div class="section_title"><%:UiResources.UiTexts.message_details%></div>
<div class="discussion_message_editor">
<%
    if (WebUi.Models.Security.CurrentUser != null)
    {
        if (WebUi.Models.Security.CurrentUser.Id == Model.MessageToEdit.UserId ||
            Model.MessageToEdit.Id <= 0)
        {
            if (Model.MessageToReply != null)
            {
            %>
                <p><b><%:UiResources.UiTexts.message_original%></b></p>
                <div class="discussion_message_original">
                    <p><%:Model.MessageToReply.Subject%></p>
                    <p><%:Model.MessageToReply.Body%></p>
                </div>
            <%
            }
            %>

            <% 
            using (Html.BeginForm(
                WebUi.ViewModels.NavigationKeys.DiscussionsSaveAction,
                WebUi.ViewModels.NavigationKeys.DiscussionsController
                /*, FormMethod.Post, new { @class="form" }*/))
            {
                
             %>
                <div class="form">
                    <div class="discussion_message_type">
                        <span class="hor_sep">
                            <input type="radio" id="General" name="MessageType" value="0" <%:(Model.MessageToEdit.Type == DomainModel.Repository.Memory.Forums.MessageTypes.General)? "checked=checked": "" %>  />
                            <label for="General"><img alt="General" src="/Content/Forums/Images/General.gif" /><%:UiResources.UiTexts.message_type_general %></label>
                        </span>
                        <span class="hor_sep">
                            <input type="radio" id="Question" name="MessageType" value="1" <%:(Model.MessageToEdit.Type == DomainModel.Repository.Memory.Forums.MessageTypes.Question)? "checked=checked": "" %>  />
                            <label for="Question"><img alt="Question" src="/Content/Forums/Images/Question.gif" /><%:UiResources.UiTexts.message_type_question %></label>
                        </span>

                        <span class="hor_sep">
                            <input type="radio" id="Answer" name="MessageType" value="2" <%:(Model.MessageToEdit.Type == DomainModel.Repository.Memory.Forums.MessageTypes.Answer)? "checked=checked": "" %>  />
                            <label for="Answer"><img alt="Answer" src="/Content/Forums/Images/Answer.gif" /><%:UiResources.UiTexts.message_type_answer %></label>
                        </span>
                        
                        <span class="hor_sep">
                            <input type="radio" id="Joke" name="MessageType" value="3" <%:(Model.MessageToEdit.Type == DomainModel.Repository.Memory.Forums.MessageTypes.Joke)? "checked=checked": "" %>  />
                            <label for="Joke"><img alt="Joke" src="/Content/Forums/Images/Joke.gif" /><%:UiResources.UiTexts.message_type_joke %></label>
                        </span>
                    </div>
                    <p>
                        <label><%:UiResources.UiTexts.message_subject %>: </label>
                        <%:Html.TextBox("Subject", Model.MessageToEdit.Subject)%>
                    </p>
                    <p>
                        <label><%:UiResources.UiTexts.message_body %>: </label>
                        <%:Html.TextArea("Body", Model.MessageToEdit.Body)%>
                    </p>
                    <p class="submit"><input type="submit" value="<%:UiResources.UiTexts.message_send%>" /></p>
                </div>
                <input type="hidden" name="Product" value="<%:Model.Product%>" />
                <input type="hidden" name="Message" value="<%:Model.MessageToEdit.Id%>" />

                <input type="hidden" name="Discussion" value="<%:(Model.MessageToEdit.Discussion == null)? 0 : Model.MessageToEdit.Discussion.Id%>" />
                <input type="hidden" name="Parent" value="<%:(Model.MessageToReply == null)? 0 : Model.MessageToReply.Id%>" />
            <%
            }
        }
        else
        {
%>
            <div class="warning"><%:UiResources.UiTexts.cant_edit_somone_else_message%></div>
<%
        }
    }
    else
    {
%>
        <div class="warning"><%:UiResources.UiTexts.login_to_manage_comments%></div>
<%  } 
%>
</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
