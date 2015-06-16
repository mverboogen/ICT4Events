<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="EventCampsite.aspx.cs" Inherits="EventBeheerSysteem.EventCampsite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPH" runat="server">
    <div id="titleContainer" runat="server">
        <h1 id="title" runat="server"></h1>
    </div>
    <div id="container" runat="server">
        <div id="item" runat="server">
            <asp:ListBox ID="campsiteLb" runat="server" AutoPostBack="true" OnSelectedIndexChanged="campsiteLb_IndexChanged" CssClass="listBox"></asp:ListBox>
            <p><asp:Button ID="addButton" runat="server" Text="Toevoegen" CssClass="Button" OnClick="addCampsite_OnClick" /></p>
            <p><asp:Button ID="removeButton" runat="server" Text="Verwijderen" CssClass="Button" OnClientClick="Confirm()" OnClick="removeBtn_OnClick" /></p>
        </div>
        <div id="detail" runat="server">
            <div id="detailLabel" runat="server">
                <p><asp:Label ID="campSiteNumberLbl" runat="server" Text="Nummer:" ></asp:Label></p>
                <p><asp:Label ID="campsiteCapacityLbl" runat="server" Text="Capaciteit:"></asp:Label></p>
                <p><asp:Label ID="campsiteSizeLbl" runat="server" Text="Oppervlakte:"></asp:Label></p>
                <p><asp:Label ID="campsiteComfortLbl" runat="server" Text="Comfort:"></asp:Label></p>
                <p><asp:Label ID="campsiteCraneLbl" runat="server" Text="Kraan:"></asp:Label></p>
                <p><asp:Label ID="campsiteHandicapLbl" runat="server" Text="Handicap:"></asp:Label></p>
                <p><asp:Label ID="campsiteXCorLbl" runat="server" Text="X Positie:"></asp:Label></p>
                <p><asp:Label ID="campsiteYCorLbl" runat="server" Text="Y Positie:"></asp:Label></p>
                <p><asp:Label ID="campsiteRenterLbl" runat="server" Text="Huurder:"></asp:Label></p>
            </div>
            <div id="detailInput" runat="server">
                <p><asp:TextBox ID="campsiteNumberTb" runat="server" style="width: 80%;" Enabled="false"></asp:TextBox></p>
                <p><asp:TextBox ID="campsiteCapacityTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:TextBox ID="campsiteSizeTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:CheckBox ID="campsiteComfortCb" runat="server" /></p>
                <p><asp:CheckBox ID="campsiteCraneCb" runat="server" /></p>
                <p><asp:CheckBox ID="campsiteHandicapCb" runat="server" /></p>
                <p><asp:TextBox ID="campsiteXCorTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:TextBox ID="campsiteYCorTb" runat="server" style="width: 80%;"></asp:TextBox></p>
                <p><asp:TextBox ID="campsiteRenterTb" runat="server" style="width: 186px;" Enabled="false"></asp:TextBox><asp:Button ID="changeRenterBtn" runat="server" Text="Selecteer Huurder" style="width: 128px;"/></p>
                <p><asp:Button ID="saveBtn" runat="server" Text="Save" OnClick="saveBtn_OnClick" style="margin-left: 55%; width: 100px;"/></p>
            </div>
        </div>
    </div>
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (document.getElementById('<%=campsiteRenterTb.ClientID%>').value != "")
            {
                if (confirm("De kampeerplaats heeft een huurder. Weet u zeker dat u de kampeerplaats wilt verwijderen")) {
                    confirm_value.value = "Yes";
                } else {
                    confirm_value.value = "No";
                }
            }
            else
            {
                confirm_value.value = "Yes";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>
