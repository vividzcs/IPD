<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="CreateCourse.aspx.cs" Inherits="Admin_CreateCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>创建课程 - HAERMS</title>
    <link href="../Content/index.css" rel="stylesheet" />
    <link href="../Content/classes.css" rel="stylesheet" />
    <link href="../Content/teacher-style.css" rel="stylesheet" />
    <link href="../Content/form-controls.css" rel="stylesheet" />
    <link href="../Content/progressbar.css" rel="stylesheet" />
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

    <form class="main-container create-class-main-container">
        <div class="main-content card">
            <h2><input title="课程名称" placeholder="课程名称" class="create-course-h2  input-style" required="required"></h2>
            <h5 class="teacher">陈晓江/肖云</h5>
            <hr>
            <div class="paragraphs">
                <textarea title="课程简介" placeholder="课程简介" rows="8" class="input-style"></textarea>
            </div>
        </div>
        <div class="button-group">
            <button class="btn btn-success">完成，下一步</button>
        </div>
    </form>
</asp:Content>

