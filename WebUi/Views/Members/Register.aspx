<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Members/Members.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Register - <%:UiResources.UiTexts.app_title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CenterContent" runat="server">
    
    <div class="home_content">

        <div class="page_title">
            <%: UiResources.UiTexts.registration %>
        </div>

        <div style="line-height: 1.5em;">
            <%Html.RenderPartial("RegistrationForm");%>
        </div>
        <br />

    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>
