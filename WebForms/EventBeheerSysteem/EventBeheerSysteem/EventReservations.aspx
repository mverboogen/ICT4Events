<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="EventReservations.aspx.cs" Inherits="EventBeheerSysteem.EventReservations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPH" runat="server">
    <div id="titleContainer" runat="server">
        <h1 id="title" runat="server"></h1>
    </div>
    <div id="container" runat="server">
        <div id="item" runat="server">
            <asp:ListBox ID="reservationLb" runat="server" AutoPostBack="true" OnSelectedIndexChanged="reservationLb_IndexChanged" CssClass="listBox"></asp:ListBox>
        </div>
        <div id="detail" runat="server">
            <div id="detailLabel" runat="server">
                <p><asp:Label ID="reservationStartDateLbl" runat="server" Text="Start Datum:"></asp:Label></p>
                <p><asp:Label ID="reservationEndDateLbl" runat="server" Text="Eind Datum:"></asp:Label></p>
                <p><asp:Label ID="reservationPayed" runat="server" Text="Betaald:"></asp:Label></p>
                <p><asp:Label ID="reservationNameLbl" runat="server" Text="Voornaam:"></asp:Label></p>
                <p><asp:Label ID="reservationStreetLbl" runat="server" Text="Straat:"></asp:Label></p>
                <p><asp:Label ID="reservationNumberLbl" runat="server" Text="Nummer:"></asp:Label></p>
                <p><asp:Label ID="reservationCityLbl" runat="server" Text="Woonplaats:"></asp:Label></p>
                <p><asp:Label ID="reservationBankLbl" runat="server" Text="Bank:"></asp:Label></p>
            </div>
            <div id="detailInput" runat="server">
                <p><asp:TextBox ID="reservationStartDateTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:TextBox ID="reservationEndDateTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:CheckBox ID="reservationPayedCb" runat="server" /></p>
                <p><asp:TextBox ID="reservationNameTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:TextBox ID="reservationStreetTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:TextBox ID="reservationNUmberTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:TextBox ID="reservationCityTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:TextBox ID="reservationBankTb" runat="server" style="width: 80%;"></asp:TextBox></p>
            </div>
        </div>
    </div>
</asp:Content>
