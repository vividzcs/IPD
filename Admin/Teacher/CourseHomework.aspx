<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="CourseHomework.aspx.cs" Inherits="Admin_CourseHomework" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>课程作业 - HAERMS</title>
    <link href="../Content/index.css" rel="stylesheet"/>
    <link href="../Content/classes.css" rel="stylesheet"/>
    <link href="../Content/form-controls.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="">
    <nav class="sidebar">
        <div class="card">
            <img src="../../style/images/course-main_image.png" class="image-item"/>
        </div>
        <ul class="list-class card">
            <li class="list-class-item">
                <a href="#">简介</a>
            </li>
            <li class="list-class-item">
                <a href="#">课件</a>
            </li>
            <li class="list-class-item">
                <a href="#">实验</a>
            </li>
            <li class="list-class-item selected-class-item">
                <a href="#">作业</a>
            </li>
        </ul>
    </nav>
    <div class="main-container">
        <div class="main-content card">
            <h2>课程作业列表</h2>
            <hr>
            <div class="experiments" onclick="expandOrCollapse(event)">
                <div class="an-homework">
                    <div class="title-box" id="title-box-0">
                        <img src="../../style/images/down_arrow.svg" id="img-0">
                        <span class="experiment-name" id="experiment-name-0">作业一：用JavaScript编写面向对象风格的画板</span>
                        <span class="experiment-deadline" id="experiment-deadline-0">截止时间：2017年12月21日</span>
                        <!-- 下载作业 -->
                        <div class="homework-operation" id="btn-0">
                            <button type="button" class="btn btn-info">打包下载</button>
                            <button type="button" class="btn btn-info"><a href="#">单独查看</a></button>
                        </div>
                        <!-- 下载作业-->
                    </div>
                    <div class="homework-detail">
                        <div class="experiment-purpose">
                            <h4>作业内容</h4>
                            <hr>
                            <p>p21第五题</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>


<script>
    (function init() {
        var allHomework = document.getElementsByClassName('homework-detail');
        for (var homeworkIndex in allHomework) {
            allHomework[homeworkIndex].style.display = 'none';
        }
    })();

    function expandOrCollapse(event) {
        var homework = document.getElementsByClassName('homework-detail')[
            parseInt(event.target.id.substr(event.target.id.lastIndexOf('-') + 1,
                event.target.id.length))];
        var flagHw = homework.style.display === 'none';
        if (homework !== undefined) {
            homework.style.display = flagHw ? 'block' : 'none';
        }
        var img = document.getElementById('img-' + parseInt(event.target.id.substr(event.target.id.lastIndexOf('-') + 1,
            event.target.id.length)));
        if (img !== null) {
            img.src = flagHw ? '../../style/images/up_arrow.svg' : '../../style/images/down_arrow.svg';
        }
    }
</script>
</asp:Content>

