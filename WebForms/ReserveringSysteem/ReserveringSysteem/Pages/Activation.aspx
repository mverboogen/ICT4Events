<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="Activation.aspx.cs" Inherits="ReserveringSysteem.Pages.Activation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #activation {
            height: 114px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="activation">
    <div id="activationLabel" style="width: 100px; float:left; display:inline">
        <p><asp:Label ID="Label1" runat="server" Text="Gebruikersnaam:"></asp:Label></p>
        <p><asp:Label ID="Label2" runat="server" Text="Hash:"></asp:Label></p>
        <p>&nbsp;</p>
        <p><asp:Label ID="lblActivationConfirm" runat="server" Text="" CssClass="lblConfirm"></asp:Label></p>
    </div>

    <div id="activationTextbox" style="width: 200px; float: right; margin-right: 600px"> 
         <p><asp:TextBox ID="tbAUsername" runat="server" CssClass="textbox"></asp:TextBox></p>
         <p><asp:TextBox ID="tbAHash" runat="server" CssClass="textbox"></asp:TextBox></p>
         <p><asp:Button ID="btActiveer" runat="server" Text="Activeer" CssClass="button" OnClick="btActiveer_Click"/></p>
    </div>
    </div>
 
</asp:Content>
