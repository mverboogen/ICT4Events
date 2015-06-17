<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEvent.aspx.cs" Inherits="EventBeheerSysteem.AddEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="style/stylesheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container" runat="server">
        <div id="item" runat="server">

        </div>
        <div id="detail" runat="server">
            <div id="detailLabel" runat="server">
                <p><asp:Label ID="eventNameLbl" runat="server" Text="Event Naam:"></asp:Label></p>
                <p><asp:Label ID="eventDateStartLbl" runat="server" Text="Start Datum:"></asp:Label></p>
                <p><asp:Label ID="eventDateEndLbl" runat="server" Text="Eind Datum:"></asp:Label></p>
                <p><asp:Label ID="eventMaxVisitorsLbl" runat="server" Text="Max Aantal Bezoekrs:"></asp:Label></p>
                <p><asp:Label ID="locationNameLbl" runat="server" Text="Lokatie Naam:"></asp:Label></p>
                <p><asp:Label ID="locationStreetLbl" runat="server" Text="Straat:"></asp:Label></p>
                <p><asp:Label ID="locationNumberLbl" runat="server" Text="Huisnummer:"></asp:Label></p>
                <p><asp:Label ID="locationZipcodeLbl" runat="server" Text="Postcode:"></asp:Label></p>
                <p><asp:Label ID="locationCityLbl" runat="server" Text="Plaats:"></asp:Label></p>
            </div>
            <div id="detailInput" runat="server">
                <p><asp:TextBox ID="eventNameTb" runat="server"></asp:TextBox></p>
                <p><asp:TextBox ID="eventDateStartTb" runat="server"></asp:TextBox></p>
                <p><asp:TextBox ID="eventDateEndTb" runat="server"></asp:TextBox></p>
                <p><asp:TextBox ID="eventMaxVisitorsTb" runat="server"></asp:TextBox></p>
                <p><asp:TextBox ID="locationNameTb" runat="server"></asp:TextBox></p>
                <p><asp:TextBox ID="locationStreetTb" runat="server"></asp:TextBox></p>
                <p><asp:TextBox ID="locationNumberTb" runat="server"></asp:TextBox></p>
                <p><asp:TextBox ID="locationZipcodeTb" runat="server"></asp:TextBox></p>
                <p><asp:TextBox ID="locationCityTb" runat="server"></asp:TextBox></p>
                <p><asp:Button ID="saveBtn" runat="server" Text="Save" OnClick="saveBtn_Click" /></p>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
