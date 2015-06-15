<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="EventMaterials.aspx.cs" Inherits="EventBeheerSysteem.EventMaterials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPH" runat="server">
    <div id="titleContainer" runat="server">
        <h1 id="title" runat="server"></h1>
    </div>
    <div id="container" runat="server">
        <div id="item" runat="server">
            <asp:ListBox ID="materialsLb" runat="server" AutoPostBack="true" CssClass="listBox"></asp:ListBox>
            <p><asp:Button ID="addButton" runat="server" Text="Toevoegen" OnClick="addMaterial_OnClick" CssClass="Button" /></p>
            <p><asp:Button ID="removeButton" runat="server" Text="Verwijderen" CssClass="Button" /></p>
        </div>
        <div id="detail" runat="server">
            <div id="detailLabel" runat="server">
                <p><asp:Label ID="materialBrandLbl" runat="server" Text="Brand:"></asp:Label></p>
                <p><asp:Label ID="materialSerieLbl" runat="server" Text="Serie:"></asp:Label></p>
                <p><asp:Label ID="materialTypeNumberLbl" runat="server" Text="Type Nummer:"></asp:Label></p>
                <p><asp:Label ID="materialPriceLbl" runat="server" Text="Prijs:"></asp:Label></p>
                <p></p>
                <p><asp:Label ID="materialItemCountLbl" runat="server" Text="Beschikbaar:"></asp:Label></p>
                <p><asp:Label ID="materailRenterLbl" runat="server" Text="Huurders:"></asp:Label></p>
            </div>
            <div id="detailInput" runat="server">
                <p><asp:TextBox ID="materialBrandTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:TextBox ID="materialSerieTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:TextBox ID="materialTypeNumberTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:TextBox ID="materialPriceTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:Button ID="saveBtn" runat="server" Text="Save" OnClick="saveBtn_OnClick" style="margin-left: 55%; width: 100px;"/></p>
                <p><asp:TextBox ID="materialItemCountTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:ListBox ID="materialRenterLb" runat="server" style="width: 80%; height: 180px;"></asp:ListBox></p>
            </div>
        </div>
    </div>
</asp:Content>
