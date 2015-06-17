<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ReserveringSysteem.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p>EMAIL TEST</p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server" Width="237px"></asp:TextBox>
        </p>
    </div>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Send email" />
        </p>
    </form>
</body>
</html>
