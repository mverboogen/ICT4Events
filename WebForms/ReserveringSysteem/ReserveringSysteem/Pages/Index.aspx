<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ReserveringSysteem.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Booker">Vul de gegevens van de reserveerder in. De reservering komt op naam van deze persoon<br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Voornaam:"></asp:Label>
        <asp:TextBox ID="tbVoornaam" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Tussenvoegsel:"></asp:Label>
        <asp:TextBox ID="tbTussenvoegsel" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Achternaam:"></asp:Label>
        <asp:TextBox ID="tbAchternaam" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Straat:"></asp:Label>
        <asp:TextBox ID="tbStraat" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="HuisNr:"></asp:Label>
        <asp:TextBox ID="tbHuisNr" runat="server" Width="126px"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Woonplaats:"></asp:Label>
        <asp:TextBox ID="tbWoonplaats" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="BankNr:"></asp:Label>
        <asp:TextBox ID="tbBankNr" runat="server"></asp:TextBox>
        <br />
    </div>

    <div id="Visitor">
        
        Vul hier de gegevens in die kunnen worden gebruikt om in te loggen op het media
        sharing systeem. Vul zowel de gegevens in van de reserveerder als voor de bezoekers die met u mee komen.<br />
        <br />
        <asp:Label ID="Label8" runat="server" Text="Gebruikersnaam"></asp:Label>
        <asp:TextBox ID="tbGebruikersnaam" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label9" runat="server" Text="Wachtwoord"></asp:Label>
        <asp:TextBox ID="tbWachtwoord" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label10" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:GridView ID="gvAccounts" runat="server">
        </asp:GridView>
        <br />
        <asp:Button ID="btToevoegen" runat="server" OnClick="Button1_Click" Text="Toevoegen" />
    </div>
    <div id="Campsite">Hier de kampeerplaatsen<br />
        <asp:ListBox ID="lbCampsites" runat="server" Width="384px"></asp:ListBox>
        <br />
        <asp:TextBox ID="tbCampsiteID" runat="server"></asp:TextBox>
        <asp:Button ID="btAddCampsite" runat="server" Text="Toevoegen" OnClick="btAddCampsite_Click" />
        &nbsp;<asp:Button ID="btRemoveCampsite" runat="server" Text="Verwijderen" OnClick="btRemoveCampsite_Click" />
        <br />
        <asp:ListBox ID="lbResCampsites" runat="server" Width="93px"></asp:ListBox>
        <br />
        <asp:Label ID="lblCampsiteConfirm" runat="server" Text=""></asp:Label>
        <br />
    </div>
    <div id="Item">Hier de materialen<br />
        <asp:ListBox ID="lbItems" runat="server" Width="385px"></asp:ListBox>
        <br />
        <asp:TextBox ID="tbItemID" runat="server"></asp:TextBox>
        <asp:Button ID="btAddItems" runat="server" Text="Toevoegen" OnClick="btAddItems_Click" />
        &nbsp;<asp:Button ID="btRemoveItem" runat="server" Text="Verwijderen" OnClick="btRemoveItem_Click" />
        <br />
        <asp:ListBox ID="lbResItems" runat="server" Width="88px"></asp:ListBox>
        <br />
        <asp:Label ID="lblItemConfirm" runat="server" Text=""></asp:Label>
    </div>
    <div id="Details">Hier het overzicht<br />
        <br />
        <asp:Button ID="btBevestigen" runat="server" OnClick="btBevestigen_Click" Text="Bevestigen" />
        <br />
    </div>
</asp:Content>
