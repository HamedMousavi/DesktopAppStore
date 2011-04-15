<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Members/Members.Master" Inherits="System.Web.Mvc.ViewPage<DomainModel.Membership.UserProfile>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%:UiResources.UiTexts.title_settings%> - <%:UiResources.UiTexts.app_title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CenterContent" runat="server">
    <div class="home_content">
        <div class="page_title">
            <%: UiResources.UiTexts.title_settings %>
        </div>

        <div class="settings">

            <p>
                <%:UiResources.UiTexts.settings_brief %>
            </p>

            <div class = "form">
                <% 
                    using (Html.BeginForm(
                       WebUi.ViewModels.NavigationKeys.MemberSettingsAction,
                       WebUi.ViewModels.NavigationKeys.MemberController,
                       FormMethod.Post))
                    { 
                %>
                        <p>
                            <%: Html.Label(UiTexts.app_culture) %>
                            <select id="Culture" name="Culture">
                                <%
                                    foreach (DomainModel.Entities.ProductLanguage lng in DomainModel.Repository.Memory.Languages.Instance.Items)
                                    {
                                        if (Model.Culture == lng.CultureId)
                                        {
                                %>
                                            <option value="<%:lng.CultureId%>" selected="selected"><%:lng.Name%></option>
                                <%
                                        }
                                        else
                                        {
                                %>
                                            <option value="<%:lng.CultureId%>" ><%:lng.Name%></option>
                                <%
                                        }
                                    }
                                %>
                            </select>
                            <%: Html.ValidationMessage("Culture")%>
                        </p>
                
                        <p>
                            <%: Html.Label(UiTexts.display_name) %>
                            <%: Html.TextBox("DislayName")%>
                            <%: Html.ValidationMessage("DislayName")%>
                        </p>
               
                        <p class="submit">
                            <input type="submit" value="<%: UiTexts.save %>" />
                        </p> 
                <%  }
                %>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
