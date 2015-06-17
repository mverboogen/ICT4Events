<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="CheckOutItem.aspx.cs" Inherits="MateriaalBeheerSysteem.CheckOutItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPH" runat="server">
    <div id="titleContainer" runat="server">
        <h1 id="title" runat="server"></h1>
    </div>
    <div id="container" runat="server">
        <div id="item" runat="server">
            <p><asp:TextBox ID="barcodeTb" runat="server"></asp:TextBox><asp:Button ID="checkBarcode" runat="server" Text="Check" OnClick="checkBarcode_Click" /></p>
        </div>
        <div id="detail" runat="server">
            <div id="detailLabel" runat="server">
                <p></p>
                <p>Items:</p>
            </div>
            <div id="detailInput" runat="server">
                <p><asp:Button ID="checkOutBtn" runat="server" Text="Uit Checken" OnClick="checkOutBtn_Click" /></p>
                <p><asp:ListBox ID="materialLb" runat="server" AutoPostBack="true" OnSelectedIndexChanged="materialLb_SelectedIndexChanged" style="width: 80%; height:200px;"></asp:ListBox></p>
            </div>
        </div>
    </div>
</asp:Content>
