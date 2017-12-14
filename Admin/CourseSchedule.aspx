﻿<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="CourseSchedule.aspx.cs" Inherits="Admin_CourseSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>创建课程 - 时间安排 - HAERMS</title>
    <link href="../Content/index.css" rel="stylesheet" />
    <link href="../Content/classes.css" rel="stylesheet" />
    <link href="../Content/teacher-style.css" rel="stylesheet" />
    <link href="../Content/form-controls.css" rel="stylesheet" />
    <link href="../Content/progressbar.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="progressbar-container progressbar-margin-top">
        <ul class="progressbar">
            <li>基本信息</li>
            <li>详细介绍</li>
            <li class="active">时间安排</li>
            <li>上传课件</li>
            <li>上传实验</li>
            <li>上传作业</li>
        </ul>
    </div>

    <form class="main-container create-class-main-container">
        <div class="main-content card">
            <h2>课程时间</h2>
            <hr>
            <table class="class-hour-table" border="2">
                <tr>
                    <td class="table-head">开课时间</td>
                    <td>
                        <input title="开始时间" type="date" class="input-style" min="2017-09-01" max="2099-12-31">
                        -
                        <input title="结束时间" type="date" class="input-style" min="2017-09-01" max="2099-12-31">
                    </td>
                </tr>
                <tr>
                    <td class="table-head">课时安排</td>
                    <td>
                        理论<input title="理论课时" type="number" class="input-style" min="1" max="300">课时
                        +
                        实验<input title="实验课时" type="number" class="input-style" min="1" max="300">课时
                    </td>
                </tr>
            </table>
        </div>
        <div class="button-group">
            <button class="btn btn-warning">跳过</button>
            <button class="btn btn-success">完成，下一步</button>
        </div>
    </form>
</asp:Content>
