<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AddCategorie.aspx.cs" Inherits="MateriaalBeheerSysteem.AddCategorie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPH" runat="server">
    <div id="titleContainer" runat="server">
        <h1 id="title" runat="server"></h1>
    </div>
    <div id="container" runat="server">
        <div id="item" runat="server">
        </div>
        <div id="detail" runat="server">
            <div id="detailLabel" runat="server">
                <p><asp:Label ID="categorieNameLbl" runat="server" Text="Categorie Naam:"></asp:Label></p>
                <p><asp:Label ID="categorieSubCategorie" runat="server" Text="Sub Categorie:"></asp:Label></p>
            </div>
            <div id="detailInput" runat="server">
                <p><asp:TextBox ID="categorieNameTb" runat="server"></asp:TextBox></p>
                <p><asp:DropDownList ID="categorieSubCategorieDDL" runat="server"></asp:DropDownList></p>
                <p><asp:Button ID="saveBtn" runat="server" Text="Save" OnClick="saveBtn_OnClick" /></p>
            </div>
        </div>
    </div>
</asp:Content>
