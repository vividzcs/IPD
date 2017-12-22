<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="CreateDepartment.aspx.cs" Inherits="Admin_CreateDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>管理教师 - HAERMS</title>
    <link href="/Content/createTeacher.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server" onsubmit="return check()">
        <div id="CreateDepartment">
            <div class="name">
                名称：<asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
            </div> 
            <div class="englishName">
                英文名：<asp:TextBox ID="TextBoxEnglishName" runat="server" Width="360px"></asp:TextBox>
            </div>
            <div class="introduction">
                 <span>简介：</span><textarea id="TextAreaIntroduction" runat="server" rows="20" cols="50"></textarea>
            </div>  
            <asp:Button type="submit" CssClass="buttonCreate" ID="ButtonCreate" runat="server" Text="创建" OnClick="ButtonCreateDepartment_Click"/>
        </div> 
    </form>
    <script type="text/javascript">
        function check() {
            var name = document.getElementsByClassName('name')[0].getElementsByTagName('input')[0].value;
            var englishName = document.getElementsByClassName('englishName')[0].getElementsByTagName('input')[0].value;
            var reg = /^[A-Za-z]+$/;
            var flag = true;
            if (name === '' || englishName === '') {
                alert("请将信息补充完整!");
                flag = false;
            }
            if (reg.test(englishName)) {
                alert("请输入正确的英文名!");
                flag = false;
            }
            if (!flag) {
                return false;
            } else {
                return true;
            }
        }
    </script>
</asp:Content>
