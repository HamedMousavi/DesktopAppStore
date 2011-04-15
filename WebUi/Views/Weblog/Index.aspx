<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DomainModel.Entities.WeblogEntryCollection>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Messages - <%:UiResources.UiTexts.app_title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CenterContent" runat="server">
    <div class="home_section_bar">
        <div class="home_content">
            <div class="page_title"><%:UiResources.UiTexts.announcements%></div>

            <% if (Model == null)
               { %>
                <div id="messages">
                    <% Html.RenderPartial("WeblogSummary"); %>
                </div>

                <% 
               }
               else
               {     
                   foreach (DomainModel.Entities.WeblogEntry message in Model)
                   {%>

                    <div class="message_item">
                        <div class="section_title"><%:message.Title%></div>
                        <div class="info_bar">
                            <%: DomainModel.Tools.DateTime.Convert.ToCulture(
                                                        message.UploadDate,
                                      WebUi.Models.AppCulture.CurrentCulture)%>
                        </div>
                        <%=message.Content%>
                    </div>
                    <%
                    Html.RenderPartial("Forum", message.Forum);    
                   }
               }
               %>

        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>
