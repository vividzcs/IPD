<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="CourseHomework.aspx.cs" Inherits="Admin.Teacher.Admin_CourseHomework" %>
<%@ Import Namespace="BusinessLogicLayer.Impl" %>
<%@ Import Namespace="Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <%--       通过调用业务逻辑CourseServiceImpl的GetById方法取得该课程的对象，给title赋值--%>
    <% var cid = int.Parse(Request.QueryString["course"]); %>

    <% var course = (Course) (new CourseServiceImpl().GetById(cid)); %>
    <title><%= course.Name %> - 课程作业 - HAERMS</title>
    <link href="../../Content/index.css" rel="stylesheet"/>
    <link href="../../Content/classes.css" rel="stylesheet"/>
    <link href="../../Content/form-controls.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--     通过调用业务逻辑CourseServiceImpl的GetById方法取得该课程的对象，给title赋值--%>
    <% var cid = int.Parse(Request.QueryString["course"]); %>
    <% var course = (Course) (new CourseServiceImpl().GetById(cid)); %>
    <div class="">
        <nav class="sidebar">
            <div class="card">
                <img src="<%= course.IntroImage %>" class="image-item" alt="课程图片"/>
            </div>
            <ul class="list-class card">
                <li class="list-class-item">
                    <a href="CoursePage.aspx?course=<%= cid %>">简介</a>
                </li>
                <li class="list-class-item">
                    <a href="CourseAttachment.aspx?course=<%= cid %>">课件</a>
                </li>
                <li class="list-class-item">
                    <a href="CourseExperiment.aspx?course=<%= cid %>">实验</a>
                </li>
                <li class="list-class-item selected-class-item">
                    <a href="CourseHomework.aspx?course=<%= cid %>">作业</a>
                </li>
            </ul>
        </nav>
        <div class="main-container">
            <div class="main-content card">
                <h2>课程作业列表</h2>
                <hr>
                <div class="experiments" onclick="expandOrCollapse(event)">
                    <% var homeworks = new HomeworkServiceImpl()
                           .Get(new Course() {CourseId = cid});
                       var i = 0; %>
                    <% foreach (var homework in homeworks)
                       { %>
                        <div class="an-homework">
                            <div class="title-box" id="title-box-<%= i %>">
                                <img src="/Images/down_arrow.svg" id="img-<%= i %>">
                                <span class="experiment-name" id="experiment-name-<%= i %>"><%= homework.Name %></span>
                                <span class="experiment-deadline" id="experiment-deadline-<%= i %>">截止时间：<%= homework.Deadline.ToString("f") %></span>
                                <!-- 下载作业 -->
                                <div class="homework-operation" id="btn-0">
                                    <a class="btn btn-info">打包下载</a>
                                    <a class="btn btn-info" href="ManageCourseHwEx.aspx?pt=ho&id=<%= homework.CourseHomeworkId %>">单独查看</a>
                                </div>
                                <!-- 下载作业-->
                            </div>
                            <div class="homework-detail">
                                <div class="experiment-purpose">
                                    <h4>作业内容</h4>
                                    <hr>
                                    <pre><%= homework.Content %></pre>
                                </div>
                            </div>
                        </div>
                    <% i++;
                       } %>
                </div>
            </div>
        </div>

    </div>

    <script>
        (function() {
            var allHomework = document.getElementsByClassName('homework-detail');
            for (var homeworkIndex in allHomework) {
                if (allHomework.hasOwnProperty(homeworkIndex)) {
                    allHomework[homeworkIndex].style.display = 'none';
                }
            }
        })();

        function expandOrCollapse(event) {
            var homework = document.getElementsByClassName('homework-detail')[
                parseInt(event.target.id.substr(event.target.id.lastIndexOf('-') + 1,
                    event.target.id.length))];
            var flagHw = homework.style.display === 'none';

                homework.style.display = flagHw ? 'block' : 'none';

            var img = document.getElementById('img-' +
                parseInt(event.target.id.substr(event.target.id.lastIndexOf('-') + 1,
                    event.target.id.length)));
            if (img !== null && img !== undefined) {
                img.src = flagHw ? '../../Images/up_arrow.svg' : '../../Images/down_arrow.svg';
            }
        }
    </script>
</asp:Content>