<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EventBeheerSysteem.Index" %>
<asp:Content ID="contentID" ContentPlaceHolderID="contentPH" runat="server">
    <div id="content">

        <asp:GridView ID="eventGridView" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" Width="960px">
            <Columns>
                <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />
                <asp:HyperLinkField HeaderText="Event Name" NavigateUrl="http://www.google.nl" DataTextField="EventName" DataNavigateUrlFields="RowNumber" DataNavigateUrlFormatString="EventDetails.aspx?EventID={0}" />
                <asp:BoundField DataField="EventEndDate" HeaderText="Eind Datum" />
                
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
