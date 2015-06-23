<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ReserveringSysteem.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <div id="ErrorMessage">
          <asp:Label ID="lblReservationConfirm" runat="server" CssClass="lblConfirm" Text=""></asp:Label>
     </div>
    <div id="booker" style="float:left">
        <p><b>Stap 1/5: Vul hier de gegevens in van de reserveerder, de reservering komt op naam van deze persoon</b></p>
         <div id="BookerLabel" style="width: 176px; float:left; display:inline">
            <p><asp:Label ID="Label1" runat="server" Text="Voornaam:" CssClass="label"></asp:Label></p>
            <p><asp:Label ID="Label2" runat="server" Text="Tussenvoegsel:" CssClass="label"></asp:Label></p>
            <p><asp:Label ID="Label3" runat="server" Text="Achternaam:" CssClass="label"></asp:Label></p>
            <p><asp:Label ID="Label4" runat="server" Text="Straat:" CssClass="label"></asp:Label></p>
            <p><asp:Label ID="Label5" runat="server" Text="HuisNr:" CssClass="label"></asp:Label></p>
            <p><asp:Label ID="Label6" runat="server" Text="Woonplaats:" CssClass="label"></asp:Label></p>
            <p><asp:Label ID="Label7" runat="server" Text="BankNr:" CssClass="label"></asp:Label></p>
         </div>

         <div id="BookerTextbox" style="width: 200px; float: right; margin-right: 580px; display: inline; ">
            <p><asp:TextBox ID="tbVoornaam" runat="server" CssClass="textbox"></asp:TextBox></p>
            <p><asp:TextBox ID="tbTussenvoegsel" runat="server" CssClass="textbox"></asp:TextBox></p>
            <p><asp:TextBox ID="tbAchternaam" runat="server" CssClass="textbox"></asp:TextBox></p>
            <p><asp:TextBox ID="tbStraat" runat="server" CssClass="textbox"></asp:TextBox></p>
            <p><asp:TextBox ID="tbHuisNr" runat="server" CssClass="textbox"></asp:TextBox></p>
            <p><asp:TextBox ID="tbWoonplaats" runat="server" CssClass="textbox"></asp:TextBox></p>
            <p><asp:TextBox ID="tbBankNr" runat="server" CssClass="textbox"></asp:TextBox></p>
         </div>
    </div>

    <div id="visitor" style="float:left">
        <p><b>Stap 2/5: Vul hier de gegevens in van alle deelnemers. Deze gegevens zijn nodig om te kunnen inloggen op het media sharing systeem
            Vul hier ook de gegevens van de reserveerder in.</b>
        </p>
        <p>&nbsp;</p>
        <div id="visitorLabel" style="width: 126px; float:left; display:inline">
            <p><asp:Label ID="Label8" runat="server" Text="Gebruikersnaam:" CssClass="label"></asp:Label></p>
            <p><asp:Label ID="Label10" runat="server" Text="Email:" CssClass="label"></asp:Label></p>
            <p>&nbsp;</p>
            <p><asp:Label ID="lblAccountConfirm" runat="server" CssClass="lblConfirm" Text=""></asp:Label></p>
        </div>

        <div id="visitorTextbox" style="width: 200px; float: right; margin-right: 580px">
            <p><asp:TextBox ID="tbGebruikersnaam" runat="server" CssClass="textbox"></asp:TextBox></p>
            <p><asp:TextBox ID="tbEmail" runat="server" CssClass="textbox"></asp:TextBox></p>
            <p><asp:Button ID="btToevoegen" runat="server" OnClick="btToevoegen_Click" Text="Toevoegen" CssClass="button" /></p>
            <p><asp:GridView ID="gvAccounts" runat="server"></asp:GridView></p>
        </div> 
    </div>    

    <div id="Campsite" style="float:left; width:100%; height: 275px;">
        <p><b>Stap 3/5: Vul het id van een kampeerplek in en druk op toevoegen om deze aan de lijst met te reserveren plekken toe te voegen</b></p>
        <p><asp:ListBox ID="lbCampsites" runat="server"  Width="400px"></asp:ListBox></p>
        <p>&nbsp;</p>
        <p><asp:TextBox ID="tbCampsiteID" runat="server" CssClass="textbox"></asp:TextBox></p>
        <p><asp:Button ID="btAddCampsite" runat="server" Text="Toevoegen" OnClick="btAddCampsite_Click" CssClass="button"/></p>
        <p><asp:Button ID="btRemoveCampsite" runat="server" Text="Verwijderen" OnClick="btRemoveCampsite_Click" CssClass="button" /></p>
        <p><asp:ListBox ID="lbResCampsites" runat="server" width="400px"></asp:ListBox></p>
        <p>&nbsp;</p>
        <p>&nbsp;</p>
        <p>&nbsp;</p>
    </div>


    <div id="Item" style="float:left; width:100%">
        <p><asp:Label ID="lblCampsiteConfirm" runat="server" CssClass="lblConfirm" Text=""></asp:Label></p>
        <p><b>Stap 4/5: Vul het id van een item in en druk op toevoegen om deze aan de lijst met te reserveren items toe te voegen</b></p>
        <p><asp:ListBox ID="lbItems" runat="server" Width="400px"></asp:ListBox></p>
        <p>&nbsp;</p>
        <p><asp:TextBox ID="tbItemID" runat="server" CssClass="textbox"></asp:TextBox>
          <p><asp:Button ID="btAddItems" runat="server" Text="Toevoegen" OnClick="btAddItems_Click" CssClass="button" /></p>
        <p><asp:Button ID="btRemoveItem" runat="server" Text="Verwijderen" OnClick="btRemoveItem_Click" CssClass="button" /></p>
        <p><asp:ListBox ID="lbResItems" runat="server" Width="400px"></asp:ListBox></p>
        <p>&nbsp;</p>
        <p><asp:Label ID="lblItemConfirm" runat="server" CssClass="lblConfirm" Text=""></asp:Label></p>
    </div>

    <div id="Details" style="float:left; width: 100%">
        <p><b>Stap 5/5: Vul de begin en de eind datum van uw reservering in</b></p>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <p><asp:Calendar ID="cBeginDate" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" >
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <WeekendDayStyle BackColor="#CCCCFF" />
        </asp:Calendar></p>
       
        <p><asp:Calendar ID="cEndDate" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <WeekendDayStyle BackColor="#CCCCFF" />
        </asp:Calendar></p>

        </ContentTemplate>
        </asp:UpdatePanel>

        <p><asp:Button ID="btBevestigen" runat="server" OnClick="btBevestigen_Click" Text="Bevestigen" CssClass="buttonConfirm" /></p>

    </div>
    
</asp:Content>
