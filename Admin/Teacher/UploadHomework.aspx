<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="UploadHomework.aspx.cs" Inherits="Admin_UploadHomework" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>创建课程 - 上传作业 - HAERMS</title>
    <link href="../../Content/index.css" rel="stylesheet"/>
    <link href="../../Content/classes.css" rel="stylesheet"/>
    <link href="../../Content/teacher-style.css" rel="stylesheet"/>
    <link href="../../Content/form-controls.css" rel="stylesheet"/>
    <link href="../../Content/progressbar.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="progressbar-container progressbar-margin-top">
    <ul class="progressbar">
        <li>基本信息</li>
        <li>详细介绍</li>
        <li>时间安排</li>
        <li>上传课件</li>
        <li>上传实验</li>
        <li  class="active">上传作业</li>
    </ul>
</div>

<form class="main-container create-class-main-container">
    <div class="main-content card">
        <h2>课程作业</h2>
        <hr>
        <div class="table-top-form">
            <button class="btn btn-info" type="button" onclick="addHomework()">添加作业</button>
        </div>
        <div class="homeworks" id="homework-container" onclick="expandOrCollapseHw(event)">
            <div class="an-homework">
                <div class="title-box" id="title-box-hw-0">
                    <img src="../../Images/down_arrow.svg" id="img-hw-0">
                    <span class="homework-name" id="homework-name-hw-0">
                        <input title="作业名称" placeholder="作业名称" class="create-course-h4 input-style">
                    </span>
                    <span class="homework-deadline" id="homework-deadline-hw-0">
                        截止时间：
                        <input title="作业截止时间" type="date" class="input-style">
                    </span>
                </div>
                <div class="homework-detail">
                    <div class="homework-purpose">
                        <h4>作业内容</h4>
                        <hr>
                        <p><textarea class="input-style" title="作业内容" rows="3" placeholder="作业内容"></textarea></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="button-group">
        <button class="btn btn-success">完成</button>
    </div>
</form>

<script>
    (function init() {
        document.getElementsByClassName('homework-detail')[0].style.display = 'none';
    })();
    function expandOrCollapseHw(event) {
        var homework = document.getElementsByClassName('homework-detail')[
            parseInt(event.target.id.substr(event.target.id.lastIndexOf('-') + 1,
                event.target.id.length))];
        var flagHw = homework.style.display === 'none';
        if (homework !== undefined) {
            homework.style.display = flagHw ? 'block' : 'none';
        }
        var img = document.getElementById('img-hw-' + parseInt(event.target.id.substr(event.target.id.lastIndexOf('-') + 1,
            event.target.id.length)));
        if (img !== null) {
            img.src = flagHw ? '../../Images/up_arrow.svg' : '../../Images/down_arrow.svg';
        }
    }

    var homeworkCounter = 0;
    function addHomework() {
        homeworkCounter++;
        var div = document.createElement("div");
        div.setAttribute("class", "homework");
        div.innerHTML = "<div class=\"an-homework\">\n" +
            "                <div class=\"title-box\" id=\"title-box-hw-"+homeworkCounter+"\">\n" +
            "                    <img src=\"../../Images/down_arrow.svg\" id=\"img-hw-"+homeworkCounter+"\">\n" +
            "                    <span class=\"homework-name\" id=\"homework-name-hw-"+homeworkCounter+"\">\n" +
            "                        <input title=\"作业名称\" placeholder=\"作业名称\" class=\"create-course-h4 input-style\">\n" +
            "                    </span>\n" +
            "                    <span class=\"homework-deadline\" id=\"homework-deadline-hw-"+homeworkCounter+"\">\n" +
            "                        截止时间：\n" +
            "                        <input title=\"作业截止时间\" type=\"date\" class=\"input-style\">\n" +
            "                    </span>\n" +
            "                </div>\n" +
            "                <div class=\"homework-detail\">\n" +
            "                    <div class=\"homework-purpose\">\n" +
            "                        <h4>作业内容</h4>\n" +
            "                        <hr>\n" +
            "                        <p><textarea class=\"input-style\" title=\"作业内容\" rows=\"3\" placeholder=\"作业内容\"></textarea></p>\n" +
            "                    </div>\n" +
            "                </div>\n" +
            "            </div>";
        document.getElementById('homework-container').appendChild(div);
        document.getElementsByClassName('homework-detail')[homeworkCounter].style.display = 'none';
    }
</script>
</asp:Content>

