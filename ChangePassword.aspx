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
            <asp:RegularExpressionValidator runat="server" ErrorMessage="密码必须包含英文、符号和数字中的两种，长度6~18位！" CssClass="tip"
                ValidationExpression="(?!^[0-9]+$)(?!^[A-z]+$)(?!^[^A-z0-9]+$)^.{6,18}$" ControlToValidate="new_password">
            </asp:RegularExpressionValidator>
        </div>
        <div class="">
            <input type="password" class="input-text" name="renew_password" placeholder="确认新密码" autocomplete="off" id="renew_password" runat="server"/>
            <asp:CompareValidator runat="server" ControlToValidate="renew_password" ControlToCompare="new_password" 
                ErrorMessage="输入密码不一致" CssClass="tip">
            </asp:CompareValidator>
        </div>
        <div class="">
            <asp:Button OnClick="ChangePasswordAction" type="submit" class="btn" text="确认" runat="server"></asp:Button>
        </div>
    </form>
</div>
</body>
</html>