<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="CreateDepartment.aspx.cs" Inherits="Admin_CreateDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>创建院系 - HAERMS</title>
    <link href="/Content/form-controls.css" rel="stylesheet"/>
    <link href="/Content/createTeacher.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server" onsubmit="return check()">
        <div id="CreateDepartment">
            <div style="padding-top:30px">
                <asp:FileUpload CssClass="upload" ID="pic_upload" runat="server" />
                <asp:Label ID="lbl_pic" runat="server" class="pic_text"></asp:Label>
            </div>
            <div class="pic_label">上传图片格式为.jpg, .gif, .bmp,.png</div>
           
            <div class="name">
                名称：<asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
            </div> 
            <div class="englishName">
                英文名：<asp:TextBox ID="TextBoxEnglishName" runat="server" Width="360px"></asp:TextBox>
            </div>
            <div class="introduction">
                 简介：<textarea id="TextAreaIntroduction" runat="server" rows="5" cols="103"></textarea>
            </div>  
             <asp:Button type="submit" CssClass="center btn btn-primary btn_create" Width="100px" ID="ButtonCreate" runat="server" Text="创建" OnClick="ButtonCreateDepartment_Click"/>
        </div> 
    </form>
    <script type="text/javascript">
        function check() {
            var name = document.getElementsByClassName('name')[0].getElementsByTagName('input')[0].value;
            var englishName = document.getElementsByClassName('englishName')[0].getElementsByTagName('input')[0].value;
            var fileUpload = document.getElementsByClassName('upload')[0].value;
            var flag = true;
            if (name === '' || englishName === '' || fileUpload === '') {
                alert("请将信息补充完整!");
                flag = false;
            }
            if (!englishName.toLocaleLowerCase()) {
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
