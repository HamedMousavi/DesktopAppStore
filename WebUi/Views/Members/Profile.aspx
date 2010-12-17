<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DomainModel.Abstract.IUser>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%:UiResources.UiTexts.title_profile%> - <%:UiResources.UiTexts.app_title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CenterContent" runat="server">


<div class="profile">
    <div class="section_title">
        <%:UiResources.UiTexts.title_profile%>
    </div>

    <img class="logo" alt="logo" src="<%:Model.Profile.Logos[0].Url %>" />

    <h1>Logo</h1>
    <p>For Users: Maybe display a personal photo.</p>
    <p>For owners: Display all logos of the owner.</p>

    <h1>Profile</h1>
    <p>If a normal user here's just a user profile. (name, Country, link to social networks, etc.)</p>
    <p>If an owner, then owners profile based on culture will be available here.</p>
    
    <h1>Branches</h1>
    <p>For owners only. Address and contact information of at least one main branch comes here.</p>
    <p>Optionally we can display all branch locations on a google map :-)</p>

    <h1>Registered products</h1>
    <p>For owners only. List of the products of an owner comes here</p>

    <h1>Brands</h1>
    <p>If owner has a brand to advertise, details can go here!</p>


</div>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">

    <p>
        For Owners & Users: A discussion forum will be here.
    </p>
</asp:Content>
