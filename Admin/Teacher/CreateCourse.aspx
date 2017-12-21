<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="CreateCourse.aspx.cs" Inherits="Admin_CreateCourse" %>
<%@ Import Namespace="Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>创建课程 - HAERMS</title>
    <link href="../../../Content/index.css" rel="stylesheet" />
    <link href="../../../Content/classes.css" rel="stylesheet" />
    <link href="../../../Content/teacher-style.css" rel="stylesheet" />
    <link href="../../../Content/form-controls.css" rel="stylesheet" />
    <link href="../../../Content/progressbar.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="progressbar-container progressbar-margin-top">
        <ul class="progressbar">
            <li class="active">基本信息</li>
            <li>详细介绍</li>
            <li>时间安排</li>
            <li>上传课件</li>
            <li>上传实验</li>
            <li>上传作业</li>
        </ul>
    </div>

    <form class="main-container create-class-main-container" runat="server">
        <div class="main-content card">
            <h2><input id="CourseName" title="课程名称" placeholder="课程名称" class="create-course-h2  input-style" required="required" runat="server"> <span style="font-size:12px;color:red"></span></h2>
            <h5 class="teacher">陈晓江/肖云</h5>
            <hr />
            <h2 style="margin:10px 0;">班级:&nbsp;<asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></h2>
            
            <hr />
            <h2 style="margin:10px 0;">
            学年:&nbsp;<asp:DropDownList ID="SchoolYear" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;学期:&nbsp;<asp:DropDownList ID="Semester" runat="server"></asp:DropDownList>
             </h2>
            <hr />
            <h2 style="margin:10px 0;">
            课程图片:&nbsp;<asp:FileUpload ID="CourseImage" runat="server" />
                </h2>
            <hr />
            <div class="paragraphs">
                <textarea id="ShortCourseIntro" title="课程简介" placeholder="课程简介" rows="8" class="input-style" runat="server"></textarea>
            </div>
        </div>
        <div class="button-group">
            &nbsp;&nbsp;&nbsp;<asp:label runat="server" id="Label" style="color:red" ></asp:label><br/>
            <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="完成，下一步" OnClick="NextStep" />
        </div>
    </form>
</asp:Content>

