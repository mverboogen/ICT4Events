<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="MediaSharingSystem.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="width: 100%;">
        <div style="width:50%; margin: 0 auto;" >
            <div>
                <span>Username: </span>
                <asp:TextBox ID="UsernameTb" runat="server"></asp:TextBox>
            </div>
            <div>
                <span>Password: </span>
                <asp:TextBox ID="PasswordTb" TextMode="Password" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="LoginButton" Text="Login" OnClick="Login_Click" runat="server" />
                <asp:CheckBox ID="RememberMeCheckBox" runat="server" />
                <asp:Label ID="InvalidCredentialsLabel" Text="Invalid Credentials" Visible="false" ForeColor="Red" runat="server" />
            </div>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
