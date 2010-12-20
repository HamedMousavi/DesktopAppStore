<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebUi.ViewModels.DiscussionInfo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%:UiResources.UiTexts.confirm%> - <%:UiResources.UiTexts.app_title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CenterContent" runat="server">

    <div class="section_title"><%:UiResources.UiTexts.confirm%></div>

<%
        if (Model.EditorFor == WebUi.ViewModels.DiscussionInfo.EditorTypes.Delete)
        {
            using (Html.BeginForm(
                WebUi.ViewModels.NavigationKeys.DiscussionsDeleteAction,
                WebUi.ViewModels.NavigationKeys.DiscussionsController,
                FormMethod.Post))
            {
%>
                <p><%:UiResources.UiTexts.confirm_discussion_delete%></p>
                <p class="submit"><input type="submit" value="<%:UiResources.UiTexts.delete_message%>" /></p>
                <a href="<%:Model.ReturnUrl%>"><%:UiResources.UiTexts.cancel%></a>

                <input type="hidden" name="ReturnUrl" value="<%:Model.ReturnUrl%>" />
                <input type="hidden" name="Message" value="<%:Model.MessageToDelete.ToString()%>" />
<%
            }
        }
        else if (Model.EditorFor == WebUi.ViewModels.DiscussionInfo.EditorTypes.Report)
        {
            using (Html.BeginForm(
                WebUi.ViewModels.NavigationKeys.DiscussionsReportAction,
                WebUi.ViewModels.NavigationKeys.DiscussionsController, 
                FormMethod.Post))
            {
%>
                <p><%:UiResources.UiTexts.confirm_discussion_report%></p>
                <p class="submit"><input type="submit" value="<%:UiResources.UiTexts.report_abuse%>" /></p>
                <a href="<%:Model.ReturnUrl%>"><%:UiResources.UiTexts.cancel%></a>

                <input type="hidden" name="ReturnUrl" value="<%:Model.ReturnUrl%>" />
                <input type="hidden" name="Message" value="<%:Model.MessageToReport.ToString()%>" />
<%
            }
        }
        else
        {
        }
%>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
