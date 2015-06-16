<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AddCampsite.aspx.cs" Inherits="EventBeheerSysteem.AddCampsite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPH" runat="server">
    <div id="titleContainer" runat="server">
        <h1 id="title" runat="server"></h1>
    </div>
    <div id="container" runat="server">
        <div id="item" runat="server">
        </div>
        <div id="detail" runat="server">
            <div id="detailLabel" runat="server">
                <p><asp:Label ID="campsiteCapacityLbl" runat="server" Text="Capaciteit:"></asp:Label></p>
                <p><asp:Label ID="campsiteComfortLbl" runat="server" Text="Comfort:"></asp:Label></p>
                <p><asp:Label ID="campsiteHandicapLbl" runat="server" Text="Handicap:"></asp:Label></p>
                <p><asp:Label ID="campsiteSizeLbl" runat="server" Text="Oppervlakte:"></asp:Label></p>
                <p><asp:Label ID="campsiteCraneLbl" runat="server" Text="Kraan:"></asp:Label></p>
                <p><asp:Label ID="campsiteXCorLbl" runat="server" Text="X Coordinaat:"></asp:Label></p>
                <p><asp:Label ID="campsiteYCorLbl" runat="server" Text="Y Coordinaat:"></asp:Label></p>
            </div>
            <div id="detailInput" runat="server">
                <p><asp:TextBox ID="campsiteCapacityTb" runat="server"></asp:TextBox></p>
                <p><asp:CheckBox ID="campsiteComfortCb" runat="server" /></p>
                <p><asp:CheckBox ID="campsiteHandicapCb" runat="server" /></p>
                <p><asp:TextBox ID="campsiteSizeTb" runat="server"></asp:TextBox></p>
                <p><asp:CheckBox ID="campsiteCraneCb" runat="server" /></p>
                <p><asp:TextBox ID="campsiteXCorTb" runat="server"></asp:TextBox></p>
                <p><asp:TextBox ID="campsiteYCorTb" runat="server"></asp:TextBox></p>
                <p><asp:Button ID="saveBtn" runat="server" Text="Save" OnClick="saveBtn_OnClick" /></p>
            </div>
        </div>
    </div>
</asp:Content>
