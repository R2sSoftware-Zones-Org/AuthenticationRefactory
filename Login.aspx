<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            帳號:<asp:TextBox ID="Id" runat="server"></asp:TextBox>
            <br />
            密碼:<asp:TextBox ID="Password" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Vefify" runat="server" OnClick="Vefify_Click" Text="Vefify" />
            <asp:Label ID="Result" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
