﻿<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="UploadCourseware.aspx.cs" Inherits="Admin_UploadCourseware" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>创建课程 - 上传课件 - HAERMS</title>
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
            <li>详细介绍</li>
            <li>时间安排</li>
            <li class="active">上传课件</li>
            <li>上传实验</li>
            <li>上传作业</li>
        </ul>
    </div>

    <form class="main-container create-class-main-container">
        <div class="main-content card">
            <h2>上传课件</h2>
            <hr>
            <div class="table-top-form">
                <button class="btn btn-info" type="button" onclick="addCourseWare()">添加课件</button>
            </div>
            <table class="attachment-table clear" id="AttachmentTable" border="2">
                <tr>
                    <th>课件名称</th>
                    <th colspan="2">操作</th>
                </tr>
                <tr>
                    <td>
                        <div class="content-cell">
                            <input type="text" title="课件名称" placeholder="在这里输入课件名称" class="input-style">
                        </div>
                    </td>
                    <td>
                        <div class="content-cell">
                            <input type="file" class="btn btn-danger input-style" >
                        </div>
                    </td>
                    <td>
                        <div class="content-cell">
                            <button class="btn btn-primary" type="button">上传</button>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div class="button-group">
            <button class="btn btn-warning">跳过</button>
            <button class="btn btn-success">完成，下一步</button>
        </div>
    </form>
    <script>
        var courseCounter = 0;
        function addCourseWare() {
            var attachmentTable = document.getElementById("AttachmentTable");
            var tr = document.createElement("tr");

            var td1 = document.createElement("td");
            var div1 = document.createElement("div");
            var input1 = document.createElement("input");

            var td2 = document.createElement("td");
            var div2 = document.createElement("div");
            var input2 = document.createElement("input");

            var td3 = document.createElement("td");
            var div3 = document.createElement("div");
            var btn = document.createElement("button");

            div1.setAttribute("class", "content-cell");
            div2.setAttribute("class", "content-cell");
            div3.setAttribute("class", "content-cell");

            input1.setAttribute("type", "text");
            input1.setAttribute("title", "课件名称");
            input1.setAttribute("placeholder", "在这里输入课件名称");
            input1.setAttribute("class", "input-style");
            input2.setAttribute("type", "file");
            input2.setAttribute("class", "btn btn-danger input-style");
            btn.setAttribute("class", "btn btn-primary");
            btn.setAttribute("type", "button");
            btn.innerText = "上传";

            div1.appendChild(input1);
            td1.appendChild(div1);

            div2.appendChild(input2);
            td2.appendChild(div2);

            div3.appendChild(btn);
            td3.appendChild(div3);

            tr.appendChild(td1);
            tr.appendChild(td2);
            tr.appendChild(td3);
            attachmentTable.appendChild(tr);
        }
    </script>
</asp:Content>

