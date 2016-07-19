<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            原始密碼:<asp:TextBox ID="OriginalPassword" runat="server"></asp:TextBox>
            <br />
            新密碼:<asp:TextBox ID="NewPassword" runat="server"></asp:TextBox>
            <br />
            確認密碼:<asp:TextBox ID="ConfirmPassword" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Modify" runat="server" OnClick="Modify_Click" Text="確定" />
            <asp:Label ID="Result" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
