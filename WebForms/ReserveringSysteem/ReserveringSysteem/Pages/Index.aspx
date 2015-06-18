<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ReserveringSysteem.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div id="ErrorMessage">
        <asp:Label ID="lblReservationConfirm" runat="server" CssClass="lblConfirm" Text=""></asp:Label>
        </div>
    <div id="Booker">Vul de gegevens van de reserveerder in. De reservering komt op naam van deze persoon<br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Voornaam:"></asp:Label>
        <asp:TextBox ID="tbVoornaam" runat="server" CssClass="textbox"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Tussenvoegsel:"></asp:Label>
        <asp:TextBox ID="tbTussenvoegsel" runat="server" CssClass="textbox"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Achternaam:"></asp:Label>
        <asp:TextBox ID="tbAchternaam" runat="server" CssClass="textbox"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Straat:"></asp:Label>
        <asp:TextBox ID="tbStraat" runat="server" CssClass="textbox"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="HuisNr:"></asp:Label>
        <asp:TextBox ID="tbHuisNr" runat="server" CssClass="textbox"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Woonplaats:"></asp:Label>
        <asp:TextBox ID="tbWoonplaats" runat="server" CssClass="textbox"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="BankNr:"></asp:Label>
        <asp:TextBox ID="tbBankNr" runat="server" CssClass="textbox"></asp:TextBox>
        <br />
    </div>


    <div id="Visitor">
        Vul hier de gegevens in die kunnen worden gebruikt om in te loggen op het media
        sharing systeem. Vul zowel de gegevens in van de reserveerder als voor de bezoekers die met u mee komen.<br />
        <br />
        <asp:Label ID="Label8" runat="server" Text="Gebruikersnaam:"></asp:Label>
        <asp:TextBox ID="tbGebruikersnaam" runat="server" CssClass="textbox"></asp:TextBox>
        <br />
        <asp:Label ID="Label10" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="tbEmail" runat="server" CssClass="textbox"></asp:TextBox>
        <br />
        <asp:Button ID="btToevoegen" runat="server" OnClick="btToevoegen_Click" Text="Toevoegen" CssClass="button" />
        <br />
        <br />
        <asp:GridView ID="gvAccounts" runat="server">
        </asp:GridView>
        <br />
        <asp:Label ID="lblAccountConfirm" runat="server" CssClass="lblConfirm" Text=""></asp:Label>
    </div>


    <div id="Campsite">Hier de kampeerplaatsen<br />
        <asp:ListBox ID="lbCampsites" runat="server"  Width="400px"></asp:ListBox>
        <br />
        <asp:TextBox ID="tbCampsiteID" runat="server" CssClass="textbox"></asp:TextBox>
        <asp:Button ID="btAddCampsite" runat="server" Text="Toevoegen" OnClick="btAddCampsite_Click" CssClass="button"/>
        &nbsp;<asp:Button ID="btRemoveCampsite" runat="server" Text="Verwijderen" OnClick="btRemoveCampsite_Click" CssClass="button" />
        <br />
        <asp:ListBox ID="lbResCampsites" runat="server" width="80px"></asp:ListBox>
        <br />
        <asp:Label ID="lblCampsiteConfirm" runat="server" CssClass="lblConfirm" Text=""></asp:Label>
        <br />
    </div>


    <div id="Item">Hier de materialen<br />
        <asp:ListBox ID="lbItems" runat="server" Width="400px"></asp:ListBox>
        <br />
        <asp:TextBox ID="tbItemID" runat="server" CssClass="textbox"></asp:TextBox>
        <asp:Button ID="btAddItems" runat="server" Text="Toevoegen" OnClick="btAddItems_Click" CssClass="button" />
        &nbsp;<asp:Button ID="btRemoveItem" runat="server" Text="Verwijderen" OnClick="btRemoveItem_Click" CssClass="button" />
        <br />
        <asp:ListBox ID="lbResItems" runat="server" Width="80px"></asp:ListBox>
        <br />
        <asp:Label ID="lblItemConfirm" runat="server" CssClass="lblConfirm" Text=""></asp:Label>
    </div>


    <div id="Details">
        <asp:Label ID="Label11" runat="server" Text="StartDatum:"></asp:Label>
        <asp:Calendar ID="cBeginDate" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <WeekendDayStyle BackColor="#CCCCFF" />
        </asp:Calendar>
        <br />
        <asp:Label ID="Label12" runat="server" Text="EindDatum:"></asp:Label>
        <asp:Calendar ID="cEndDate" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <WeekendDayStyle BackColor="#CCCCFF" />
        </asp:Calendar>
        <br />
        <asp:Button ID="btBevestigen" runat="server" OnClick="btBevestigen_Click" Text="Bevestigen" CssClass="buttonConfirm" />
        <br />
    </div>
</asp:Content>
