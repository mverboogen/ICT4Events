<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EventBeheerSysteem.Index" %>
<asp:Content ID="contentID" ContentPlaceHolderID="contentPH" runat="server">
    <div id="content">
    <div id="titleContainer" runat="server">
        <h1 id="title" runat="server"></h1>
    </div>
        <asp:GridView ID="eventGridView" runat="server" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Width="960px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />
                <asp:HyperLinkField HeaderText="Event Name" NavigateUrl="http://www.google.nl" DataTextField="EventName" DataNavigateUrlFields="RowNumber" DataNavigateUrlFormatString="EventDetails.aspx?EventID={0}" />
                <asp:BoundField DataField="EventStartDate" HeaderText="Start Datum" />
                <asp:BoundField DataField="EventEndDate" HeaderText="Eind Datum" />
                
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="Gray" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>

    </div>
</asp:Content>
