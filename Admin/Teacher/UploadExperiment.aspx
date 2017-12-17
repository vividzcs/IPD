﻿<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="UploadExperiment.aspx.cs" Inherits="Admin_UploadExperiment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>创建课程 - 上传实验 - HAERMS</title>
    <link href="../Content/index.css" rel="stylesheet"/>
    <link href="../Content/classes.css" rel="stylesheet"/>
    <link href="../Content/teacher-style.css" rel="stylesheet"/>
    <link href="../Content/form-controls.css" rel="stylesheet"/>
    <link href="../Content/progressbar.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="progressbar-container progressbar-margin-top">
        <ul class="progressbar">
            <li>基本信息</li>
            <li>详细介绍</li>
            <li>时间安排</li>
            <li>上传课件</li>
            <li class="active">上传实验</li>
            <li>上传作业</li>
        </ul>
    </div>

    <form class="main-container create-class-main-container">
        <div class="main-content card">
            <h2>课程实验</h2>
            <hr>
            <div class="table-top-form">
                <button class="btn btn-info" type="button" onclick="addExperiment()">添加实验</button>
            </div>
            <div class="experiments" id="experiment-container" onclick="expandOrCollapseExp(event)">
                <div class="an-experiment">
                    <div class="title-box" id="title-box-ex-0">
                        <img src="../../style/images/down_arrow.svg" id="img-ex-0">
                        <span class="experiment-name" id="experiment-name-ex-0">
                            <input title="实验名称" placeholder="实验名称" class="create-course-h4 input-style">
                        </span>
                        <span class="experiment-deadline" id="experiment-deadline-0">
                            截止时间：
                            <input title="作业截止时间" type="date" class="input-style">
                        </span>
                    </div>
                    <div class="experiment-detail">
                        <div class="experiment-purpose">
                            <h4>实验目的：</h4>
                            <hr>
                            <p>
                                <textarea title="实验目的" rows="5" class="input-style"></textarea>
                            </p>
                        </div>
                        <div class="experiment-steps">
                            <h4>实验步骤：</h4>
                            <hr>
                            <div class="experiment-step">
                                <p>
                                    <textarea title="步骤内容" rows="5" placeholder="步骤详细内容" class="input-style"></textarea>
                                </p>
                            </div>
                        </div>
                        <div class="experiment-references">
                            <h4>参考资料：</h4>
                            <hr>
                            <div class="experiment-reference">
                                <p>
                                    <textarea title="资料" rows="5" placeholder="资料名称, URL" class="input-style"></textarea>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="button-group">
            <button class="btn btn-warning">跳过</button>
            <button class="btn btn-success">完成，下一步</button>
        </div>
    </form>

    <script>
        (function init() {
            document.getElementsByClassName('experiment-detail')[0].style.display = 'none';
        })();

        function expandOrCollapseExp(event) {
            var experiment = document.getElementsByClassName('experiment-detail')[
                parseInt(event.target.id.substr(event.target.id.lastIndexOf('-') + 1,
                    event.target.id.length))];
            var flagEx = experiment.style.display === 'none';
            if (experiment !== undefined) {
                experiment.style.display = flagEx ? 'block' : 'none';
            }
            var img = document.getElementById('img-ex-' +
                parseInt(event.target.id.substr(event.target.id.lastIndexOf('-') + 1,
                    event.target.id.length)));
            if (img !== null) {
                img.src = flagEx ? '../../style/images/up_arrow.svg' : '../../style/images/down_arrow.svg';
            }
        }

        var experimentCounter = 0;

        function addExperiment() {
            experimentCounter++;
            var div = document.createElement("div");
            div.setAttribute("class", "an-experiment");
            div.innerHTML = "<div class=\"title-box\" id=\"title-box-ex-" +
                experimentCounter +
                "\">\n" +
                "                    <img src=\"../../style/images/down_arrow.svg\" id=\"img-ex-" +
                experimentCounter +
                "\">\n" +
                "                    <span class=\"experiment-name\" id=\"experiment-name-ex-" +
                experimentCounter +
                "\">\n" +
                "                        <input title=\"实验名称\" placeholder=\"实验名称\" class=\"create-course-h4 input-style\">\n" +
                "                    </span>\n" +
                "                    <span class=\"experiment-deadline\" id=\"experiment-deadline-" +
                experimentCounter +
                "\">\n" +
                "                        截止时间：\n" +
                "                        <input title=\"作业截止时间\" type=\"date\" class=\"input-style\">\n" +
                "                    </span>\n" +
                "                </div>\n" +
                "                <div class=\"experiment-detail\">\n" +
                "                    <div class=\"experiment-purpose\">\n" +
                "                        <h4>实验目的：</h4>\n" +
                "                        <hr>\n" +
                "                        <p><textarea title=\"实验目的\" rows=\"5\" class=\"input-style\"></textarea></p>\n" +
                "                    </div>\n" +
                "                    <div class=\"experiment-steps\">\n" +
                "                        <h4>实验步骤：</h4>\n" +
                "                        <hr>\n" +
                "                        <div class=\"experiment-step\">\n" +
                "                            <p><textarea title=\"步骤内容\" rows=\"5\" placeholder=\"步骤详细内容\" class=\"input-style\"></textarea></p>\n" +
                "                        </div>\n" +
                "                    </div>\n" +
                "                    <div class=\"experiment-references\">\n" +
                "                        <h4>参考资料：</h4>\n" +
                "                        <hr>\n" +
                "                        <div class=\"experiment-reference\">\n" +
                "                        <p><textarea title=\"资料\" rows=\"5\" placeholder=\"资料名称, URL\" class=\"input-style\"></textarea></p>\n" +
                "                    </div>\n" +
                "                    </div>\n" +
                "                </div>";
            document.getElementById("experiment-container").appendChild(div);
            document.getElementsByClassName('experiment-detail')[experimentCounter].style.display = 'none';
        }

    </script>
</asp:Content>