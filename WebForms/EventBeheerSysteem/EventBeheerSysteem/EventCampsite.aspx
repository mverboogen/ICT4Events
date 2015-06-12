<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="EventCampsite.aspx.cs" Inherits="EventBeheerSysteem.EventCampsite" %>
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
                <p><asp:Label ID="eventNameLbl" runat="server" Text="Naam:"></asp:Label></p>
                <p><asp:Label ID="eventStartDateLbl" runat="server" Text="Begin Datum:"></asp:Label></p>
                <p><asp:Label ID="eventEndDateLbl" runat="server" Text="Eind Datum:"></asp:Label></p>
                <p><asp:Label ID="eventMaxVisitorsLbl" runat="server" Text="Maximale Bezoekers:"></asp:Label></p>
                <p><asp:Label ID="eventLocationLbl" runat="server" Text="Lokatie:"></asp:Label></p>
                <p><asp:Label ID="eventCityLbl" runat="server" Text="Plaats:"></asp:Label></p>
                <p><asp:Label ID="eventStreetLbl" runat="server" Text="Straat:"></asp:Label></p>
                <p><asp:Label ID="eventNumberLbl" runat="server" Text="Huisnummer:"></asp:Label></p>
                <p><asp:Label ID="eventZipcodeLbl" runat="server" Text="Postcode:"></asp:Label></p>
            </div>
            <div id="detailInput" runat="server">
                <p><asp:TextBox ID="eventNameTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:TextBox ID="eventStartDateTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:TextBox ID="eventEndDateTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:TextBox ID="eventMaxVisitorTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:TextBox ID="eventLocationTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:TextBox ID="eventCityTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:TextBox ID="eventStreetTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:TextBox ID="eventNumberTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:TextBox ID="eventZipcodeTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:Button ID="saveBtn" runat="server" Text="Save" OnClick="saveBtn_OnClick" style="margin-left: 55%; width: 100px;"/></p>
            </div>
        </div>
    </div>
</asp:Content>
