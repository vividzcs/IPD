<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="IntroductionInDetail.aspx.cs" Inherits="Admin_IntroductionInDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>创建课程 - 详细介绍 - HAERMS</title>
    <link href="../../Content/index.css" rel="stylesheet" />
    <link href="../../Content/classes.css" rel="stylesheet" />
    <link href="../../Content/teacher-style.css" rel="stylesheet" />
    <link href="../../Content/form-controls.css" rel="stylesheet" />
    <link href="../../Content/progressbar.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="progressbar-container progressbar-margin-top">
        <ul class="progressbar">
            <li>基本信息</li>
            <li class="active">详细介绍</li>
            <li>时间安排</li>
            <li>上传课件</li>
            <li>上传实验</li>
            <li>上传作业</li>
        </ul>
    </div>

    <form class="main-container create-class-main-container" runat="server">
        <div class="main-content card">
           
            <h2>课程概述</h2>
             <input id="CourseId" type="hidden" runat="server">
            <hr>
            <div class="paragraphs">
                <textarea id="Description" title="课程简介" placeholder="课程简介" rows="14" class="input-style" runat="server"></textarea>
            </div>
        </div>
        <div class="button-group">
             &nbsp;&nbsp;&nbsp;<asp:label runat="server" id="Label" style="color:red" ></asp:label><br/>
            <asp:button class="btn btn-warning" runat="server" text="跳过" OnClick ="StepOver" />
            <asp:button class="btn btn-success" runat="server" text="完成，下一步" OnClick="NextStep" />
        </div>
    </form>
</asp:Content>

