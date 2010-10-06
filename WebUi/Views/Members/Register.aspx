﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Register
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CenterContent" runat="server">

    <div class = "form">
        <h2><%: UiTexts.registeration_form %></h2>
        <% using (Html.BeginForm("Register", "Members"/*, FormMethod.Post, new { @class="form" }*/))
           { %>
            <%: Html.ValidationSummary()%>
    
            <fieldset>
                <legend><%: UiTexts.registration_information%></legend>

                <div class="editor-label">
                    <%: Html.Label(UiTexts.email_address)%>
                </div>

                <div class="editor-field">
                    <%: Html.TextBox("Email")%>
                    <%: Html.ValidationMessage("Email")%>
                </div>

                <p>
                    <input type="submit" value="<%: UiTexts.register %>" />
                </p>

            </fieldset>
        <% } %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>
