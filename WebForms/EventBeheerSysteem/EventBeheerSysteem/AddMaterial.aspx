<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AddMaterial.aspx.cs" Inherits="EventBeheerSysteem.AddMaterial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPH" runat="server">
    <div id="titleContainer" runat="server">
        <h1 id="title" runat="server"></h1>
    </div>
    <div id="container" runat="server">
        <div id="item" runat="server">
        </div>
        <div id="detail" runat="server">
            <div id="detailLabel" runat="server">
                <p><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></p>
                <p><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></p>
                <p><asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></p>
                <p><asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></p>
            </div>
            <div id="detailInput" runat="server">
            </div>
        </div>
    </div>
</asp:Content>
