<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登录 - HAERMS</title>
    <link href="Content/form.css" rel="stylesheet" />
</head>
<body>
<div class="title">
    登 录
</div>
<div class="content">
    <form class="content-box" runat="server" onsubmit="return check()">
        <div class="">
            <input type="text" name="username" placeholder="学号或工号" id="Username" runat="server" class="input-text"/>
            <div class="tip" id="TipUsername">请输入学/工号</div>
        </div>
        <div class="">
            <input type="password" name="password"  placeholder="密码" autocomplete="off" id="Password" runat="server" class="input-text"/>
            <div class="tip" id="TipPassword">请输入密码</div>
        </div>
        <span class="inconsistent-input" id="InconsistentTip" runat="server" Visible="False">学工号和密码不匹配</span>
        <div class="">
            <asp:Button type="submit" class="btn" runat="server" Text="登录" OnClick="LoginAction"></asp:Button>
        </div>
    </form>
</div>
<script type="text/javascript">
    function check() {
        var username = document.getElementById('Username').value;
        var password = document.getElementById('Password').value;
        var tip1 = document.getElementById('TipUsername');
        var tip2 = document.getElementById('TipPassword');
        var flag = false;
        if (username === '') {
            tip1.style.visibility = 'visible';
            flag = true;
        }
        else {
            tip1.style.visibility = 'hidden';
        }
        if (password === '') {
            tip2.style.visibility = 'visible';
            flag = true;
        }
        else {
            tip2.style.visibility = 'hidden';
        }
        return !flag;
    }
</script>
</body>
</html>
