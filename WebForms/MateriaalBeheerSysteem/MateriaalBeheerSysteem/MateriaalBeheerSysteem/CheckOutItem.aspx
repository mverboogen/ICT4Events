<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="CheckOutItem.aspx.cs" Inherits="MateriaalBeheerSysteem.CheckOutItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPH" runat="server">
    <div id="titleContainer" runat="server">
        <h1 id="title" runat="server">Uit Checken</h1>
    </div>
    <div id="container" runat="server">
        <div id="item" runat="server">
            <p><asp:TextBox ID="barcodeTb" runat="server"></asp:TextBox><asp:Button ID="checkBarcode" runat="server" Text="Check" OnClick="checkBarcode_Click" /></p>
        </div>
        <div id="detail" runat="server">
            <div id="detailLabel" runat="server">
                <p><asp:Label ID="itemInstanceNameLbl" runat="server" Text="Naam:"></asp:Label></p>
                <p><asp:Label ID="itemInstanceTypeNumberLbl" runat="server" Text="Type Nummer:"></asp:Label></p>
                <p><asp:Label ID="itemInstanceBarcodeLbl" runat="server" Text="Barcode:"></asp:Label></p>
                <p><asp:Label ID="itemInstancePayedLbl" runat="server" Text="Betaald:"></asp:Label></p>
                <p><asp:Label ID="itemInstanceDateOutLbl" runat="server" Text="Datum Uit:"></asp:Label></p>
                <p><asp:Label ID="itemInstanceDateInLbl" runat="server" Text="Datum In:"></asp:Label></p>
                <p></p>
            </div>
            <div id="detailInput" runat="server">
                <p><asp:TextBox ID="itemInstanceNameTb" runat="server" Enabled="false"></asp:TextBox></p>
                <p><asp:TextBox ID="iteminstanceTypeNumberTb" runat="server" Enabled="false"></asp:TextBox></p>
                <p><asp:TextBox ID="itemInstanceBarcodeTb" runat="server" Enabled="false"></asp:TextBox></p>
                <p><asp:CheckBox ID="itemInstancePayedCb" runat="server" Enabled="false" /></p>
                <p><asp:TextBox ID="itemInstanceDateOutTb" runat="server" Enabled="false"></asp:TextBox></p>
                <p><asp:TextBox ID="itemInstanceDateInTb" runat="server" Enabled="false"></asp:TextBox></p>
                <p><asp:Button ID="checkOutBtn" runat="server" Text="Uit Checken" OnClick="checkOutBtn_Click" /><asp:Button ID="PayBtn" runat="server" Text="Betalen" OnClick="PayBtn_Click" /></p>
                <p></p>
                <p><asp:ListBox ID="materialLb" runat="server" AutoPostBack="true" OnSelectedIndexChanged="materialLb_SelectedIndexChanged" style="width: 80%; height:200px;"></asp:ListBox></p>
            </div>
        </div>
    </div>
</asp:Content>
