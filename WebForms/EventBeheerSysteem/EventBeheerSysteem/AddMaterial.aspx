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
                <p><asp:Label ID="materialBrandLbl" runat="server" Text="Merk:"></asp:Label></p>
                <p><asp:Label ID="materialSerieLbl" runat="server" Text="Serie:"></asp:Label></p>
                <p><asp:Label ID="materialPriceLbl" runat="server" Text="Prijs:"></asp:Label></p>
                <p><asp:Label ID="materialCategorieLbl" runat="server" Text="Categorie:"></asp:Label></p>
                <p><asp:Label ID="materialAmountLbl" runat="server" Text="Aantal:"></asp:Label></p>
            </div>
            <div id="detailInput" runat="server">
                <p><asp:TextBox ID="materialBrandTb" runat="server"></asp:TextBox></p>
                <p><asp:TextBox ID="materialSerieTb" runat="server"></asp:TextBox></p>
                <p><asp:TextBox ID="materialPriceTb" runat="server"></asp:TextBox></p>
                <p><asp:DropDownList ID="materiaalCategorieDDL" runat="server" style="float: left;"></asp:DropDownList><asp:Button ID="addCategorie" runat="server" Text="Categorie Toevoegen" OnClick="addCategorie_OnClick" style="float: left;" /></p>
                <p><asp:TextBox ID="materialAmountTb" runat="server"></asp:TextBox></p>
                <p><asp:Button ID="saveButton" runat="server" Text="Save" style="float: left;" OnClick="saveBtn_OnClick" /></p>
            </div>
        </div>
    </div>
</asp:Content>
