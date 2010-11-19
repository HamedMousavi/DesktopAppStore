<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DomainModel.Entities.WeblogEntryCollection>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Messages - <%:UiResources.UiTexts.app_title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CenterContent" runat="server">

<% foreach (DomainModel.Entities.WeblogEntry message in Model)
   {
 %>

    <div class="message_item">
        <h2><%:message.Title%></h2>
        <div class="text clean">
            <span><%: DomainModel.Tools.DateTime.Convert.ToCulture(
                                        message.UploadDate,
                      WebUi.Models.AppCulture.CurrentCulture)%>
            </span>
        </div>
        <hr />
        <%=message.Content%>
    </div>
<%
   } 
%>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>
