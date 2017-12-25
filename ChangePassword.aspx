<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>修改密码 - HAERMS</title>
    <link href="Content/form.css" rel="stylesheet" />
</head>
<body>
<div class="title">
    修 改 密 码
</div>
<div class="content">
    <form class="content-box" runat="server">
        <div class="">
            <input type="password" class="input-text" name="new_password" placeholder="新密码" autocomplete="off" id="new_password" runat="server"/>
            <div class="tip" id="SpanTipPassword" runat="server">请输入新密码</div>
        </div>
        <div class="">
            <input type="password" class="input-text" name="renew_password" placeholder="确认新密码" autocomplete="off" id="renew_password" runat="server"/>
            <div class="tip" id="SpanTipConfirmPassword" runat="server">请再次输入新密码</div>
        </div>
        <div class="">
            <asp:Button OnClick="ChangePasswordAction" type="submit" class="btn" text="确认" runat="server"></asp:Button>
        </div>
    </form>
</div>
</body>
</html>