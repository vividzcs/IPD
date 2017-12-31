<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="CreateTeacher.aspx.cs" Inherits="Admin_CreateTeacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>创建教师 - HAERMS</title>
    <link href="/Content/form-controls.css" rel="stylesheet"/>
    <link href="/Content/createTeacher.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server" onsubmit="return check()">
        <div id="CreateTeacher">
             <div style="padding-top:30px">
                <asp:FileUpload CssClass="upload" ID="pic_upload" runat="server" />
                <asp:Label ID="lbl_pic" runat="server" class="pic_text"></asp:Label>
            </div>
            <div class="pic_label">上传图片格式为.jpg, .gif, .bmp,.png</div>
            <div class="name">
                姓名：<asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
            </div> 
            <div class="jobNumber">
                工号：<asp:TextBox ID="TextBoxJobNumber" runat="server"></asp:TextBox>
            </div>
            <div class="department">
                 学院：<asp:DropDownList ID="DropDownListDepartment" runat="server" DataSourceID="ObjectDataSourceDepartment" DataTextField="ChinesaeName" DataValueField="DepartmentId"></asp:DropDownList>
                 <asp:ObjectDataSource runat="server" ID="ObjectDataSourceDepartment" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Impl.DepartmentServiceImpl"></asp:ObjectDataSource>
            </div>
            <div class="introduction">
                 简介：<textarea id="TextAreaIntroduction" runat="server" rows="5" cols="103"></textarea>
            </div>  
            <asp:Button type="submit" CssClass="center btn btn-primary btn_create" Width="100px" ID="ButtonCreate" runat="server" Text="创建" OnClick="ButtonCreateTeacher_Click"/>
        </div> 
    </form>
    <script type="text/javascript">
        function check() {
            var name = document.getElementsByClassName('name')[0].getElementsByTagName('input')[0].value;
            var jobNumber = document.getElementsByClassName('jobNumber')[0].getElementsByTagName('input')[0].value;
            var fileUpload = document.getElementsByClassName('upload')[0].value;
            var flag = true;
            if (name === '' || jobNumber === '' || fileUpload === '') {
                alert("请将信息补充完整!");
                flag = false;
            } else if (jobNumber.length != 8 || isNaN(jobNumber)) {
                alert("请输入正确的工号!");
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
