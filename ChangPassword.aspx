<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="ChangPassword.aspx.cs" Inherits="ChangPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>修改密码 - HAERMS</title>
    <link href="/Content/form.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="title">
        修 改 密 码
    </div>
    <div class="content">
        <form class="content-box" onsubmit="return check()" runat="server">
            <div class="">
                <input type="password" class="input-text" name="new_password" placeholder="新密码" autocomplete="off" id="new_password" runat="server"/>
                <div class="tip" id="tip_2">请输入新密码</div>
            </div>
            <div class="">
                <input type="password" class="input-text" name="renew_password" placeholder="确认新密码" autocomplete="off" id="renew_password"/>
                <div class="tip" id="tip_3">请再次输入新密码</div>
            </div>
            <div class="">
                <asp:Button OnClick="ChangePasswordAction" type="submit" class="btn" text="确认" runat="server"></asp:Button>
            </div>
        </form>
    </div>
    <script>
        function check() {
            var newPassword = document.getElementById('new_password').value;
            alert(newPassword);
            var renewPassword = document.getElementById('renew_password').value;
            var tip2 = document.getElementById('tip_2');
            var tip3 = document.getElementById('tip_3');
            var flag = false;
            if (newPassword === '') {
                tip2.style.visibility = 'visible';
                flag = true;
            } else {
                tip2.style.visibility = 'hidden';
            }
            if (renewPassword === '') {
                tip3.innerHTML = '请再次输入新密码';
                tip3.style.visibility = 'visible';
                flag = true;
            } else {
                tip3.style.visibility = 'hidden';
            }
            console.log(flag);
            if (flag) return false;
            if (newPassword !== renewPassword) {
                tip3.innerHTML = '两次输入不一致！';
                tip3.style.visibility = 'visible';
                flag = true;
            } else {
                tip2.style.visibility = 'hidden';
            }
            return !flag;
        }
    </script>
</asp:Content>