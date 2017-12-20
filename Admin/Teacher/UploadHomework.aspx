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

<form class="main-container create-class-main-container" runat="server">
    <div class="main-content card">
        <h2>课程作业</h2>
         <input id="CourseIds" type="hidden" value="<%= Request.QueryString["id"] ?? "0" %>">
        <hr>
        <div class="table-top-form">
            <button class="btn btn-info" type="button" onclick="addHomework()">添加作业</button>
        </div>
        <div class="homeworks" id="homework-container" onclick="expandOrCollapseHw(event)">
            <div class="an-homework">
                <div class="title-box" id="title-box-hw-0">
                    <img src="../../Images/down_arrow.svg" id="img-hw-0">
                    <span class="homework-name" id="homework-name-hw-0">
                        <input title="作业名称" placeholder="作业名称" class="create-course-h4 input-style" id="HomeWorkName0">
                    </span>
                    <span class="homework-deadline" id="homework-deadline-hw-0">
                        截止时间：
                        <input title="作业截止时间" type="datetime-local" class="input-style" id="HomeDeadline0">
                    </span>
                </div>
                <div class="homework-detail" style="display:block">
                    <div class="homework-purpose">
                        <h4>作业内容</h4>
                        <hr>
                        <p><textarea class="input-style" title="作业内容" rows="3" placeholder="作业内容" id="HomeWorkContent0"></textarea></p>
                    </div>
                    <button id="upHomework0" class="btn btn-primary" type="button" onclick="Upload(this)">上传</button>
                </div>
            </div>
        </div>
    </div>
    <div class="button-group">
        &nbsp;&nbsp;&nbsp;<span id="warning" style="display:none"></span>
            <asp:button class="btn btn-success" runat="server" text="完成" OnClick="NextStep" />
    </div>
</form>

<script>
    function expandOrCollapseHw(event) {
        var homework = document.getElementsByClassName('homework-detail')[
            parseInt(event.target.id.substr(event.target.id.lastIndexOf('-') + 1,
                event.target.id.length))];
        var flagHw ;
        if (homework !== undefined) {
            flagHw = homework.style.display === 'none';
            homework.style.display = flagHw ? 'block' : 'none';
        } else {
            return;
        }
        var img = document.getElementById('img-hw-' + parseInt(event.target.id.substr(event.target.id.lastIndexOf('-') + 1,
            event.target.id.length)));
        if (img !== null) {
            img.src = flagHw ? '../../Images/down_arrow.svg' : '../../Images/up_arrow.svg';
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
            "                        <input title=\"作业名称\" placeholder=\"作业名称\" class=\"create-course-h4 input-style\" id='HomeWorkName" + homeworkCounter+"'>\n" +
            "                    </span>\n" +
            "                    <span class=\"homework-deadline\" id=\"homework-deadline-hw-"+homeworkCounter+"\">\n" +
            "                        截止时间：\n" +
            "                        <input title=\"作业截止时间\" type=\"date\" class=\"input-style\" id='HomeDeadline" + homeworkCounter+"'>\n" +
            "                    </span>\n" + 
            "                </div>\n" +
            "                <div class=\"homework-detail\">\n" +
            "                    <div class=\"homework-purpose\">\n" +
            "                        <h4>作业内容</h4>\n" +
            "                        <hr>\n" +
            "                        <p><textarea class=\"input-style\" title=\"作业内容\" rows=\"3\" placeholder=\"作业内容\" id='HomeWorkContent" + homeworkCounter+"'></textarea></p>\n" +
            "                    </div>\n" +
            '<button id="upHomeWork' + homeworkCounter+'" class="btn btn-primary" type="button" onclick="Upload(this)">上传</button>' +
            "                </div>\n" +
            "            </div>";
        document.getElementById('homework-container').appendChild(div);
        document.getElementsByClassName('homework-detail')[homeworkCounter].style.display = 'block';
    }

    function getXMLHttpRequest() {
        if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
            return new XMLHttpRequest();
        }
        else {// code for IE6, IE5
            return new ActiveXObject("Microsoft.XMLHTTP");
        }
    }

    function Upload(obj) {
        var buttonId = obj.id;
        var CourseId = document.getElementById('CourseIds').value;
        var warn = document.getElementById('warning');
        //alert(CourseId)
        var num = parseInt(buttonId.substr(-1, 1));
        //开始组装数据 
        var HomeWorkName = document.getElementById('HomeWorkName' + num).value;
        var HomeDeadline = document.getElementById('HomeDeadline' + num).value;
        var HomeWorkContent = document.getElementById('HomeWorkContent' + num).value;

        if (HomeWorkName == "" || HomeDeadline == "" || HomeWorkContent == "") {
            warn.innerHTML = "请填写完整";
            warn.style.display = "block";
            warn.style.color = "red";
        }

        var fd = new FormData();

        fd.append("HomeWorkName", HomeWorkName);
        fd.append("HomeDeadline", HomeDeadline);
        fd.append("HomeWorkContent", HomeWorkContent);
        fd.append("CourseId", CourseId);
        var xhr = getXMLHttpRequest();
        xhr.open("post", "UploadHomeWorkHandler.ashx", true);
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4) {
                if (xhr.status == 200) {
                    var rs = eval('(' + xhr.responseText + ')');
                    if (rs.status == 1) {
                        warn.style.color = "green";
                        warn.style.display = "block";
                        warn.innerHTML = rs.msg;
                        obj.disabled = "disabled";
                        obj.style = "background-color:#eee;"

                    }
                    else {
                        warn.innerHTML = rs.msg;
                        warn.style.display = "block";
                        warn.style.color = "red";
                    }
                }
                else {
                    warn.innerHTML = "上传失败";
                    warn.style.color = "red";
                }
            }

        }
        xhr.send(fd);
    }
</script>
</asp:Content>

