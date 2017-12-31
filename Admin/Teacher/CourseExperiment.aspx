<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="CourseExperiment.aspx.cs" Inherits="Admin.Teacher.Admin_CourseExperiment" %>
<%@ Import Namespace="BusinessLogicLayer.Impl" %>
<%@ Import Namespace="Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%--    通过调用业务逻辑CourseServiceImpl的GetById方法取得该课程的对象，给title赋值--%>
    <% var cid = int.Parse(Request.QueryString["course"]); %>
    <% var course = (Course) (new CourseServiceImpl().GetById(cid)); %>
    <title><%= course.Name %> - 课程实验 - HAERMS</title>
    <link href="/Content/index.css" rel="stylesheet"/>
    <link href="/Content/classes.css" rel="stylesheet"/>
    <link href="/Content/form-controls.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%-- 通过调用业务逻辑CourseServiceImpl的GetById方法取得该课程的对象，给title赋值--%>
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
                <li class="list-class-item selected-class-item">
                    <a href="CourseExperiment.aspx?course=<%= cid %>">实验</a>
                </li>
                <li class="list-class-item">
                    <a href="CourseHomework.aspx?course=<%= cid %>">作业</a>
                </li>
            </ul>
        </nav>
        <div class="main-container">
            <div class="main-content card">
                <h2>课程实验列表</h2>
                <hr>
                <div class="experiments" onclick="expandOrCollapse(event)">
                    <% var experiments = new ExperimentServiceImpl()
                           .Get(new Course() {CourseId = cid});
                       var i = 0; %>
                    <% foreach (var courseExperiment in experiments)
                       { %>
                    <div class="an-experiment">
                        <div class="title-box" id="title-box-<%= i %>">
                            <img src="/Images/down_arrow.svg" id="img-<%= i %>">
                            <span class="experiment-name" id="experiment-name-<%= i %>"><%= courseExperiment.Name %></span>
                            <span class="experiment-deadline" id="experiment-deadline-<%= i %>">截止时间：<%= courseExperiment.Deadline.GetValueOrDefault().ToString("f") %></span>
                            <!-- 下载报告 -->
                            <div class="experiment-operation" id="btn-<%= i %>">
                                <a class="btn btn-info" href="BatchDownload.aspx?pt=ex&id=<%= courseExperiment.CourseExperimentId %>">打包下载</a>
                                <a class="btn btn-info" href="ManageCourseHwEx.aspx?pt=ex&id=<%= courseExperiment.CourseExperimentId %>">单独查看</a>
                            </div>
                            <!-- 下载报告-->
                            <div class="experiment-detail">
                                <div class="experiment-purpose">
                                    <h4>实验目的：</h4>
                                    <hr>
                                    <pre><%= courseExperiment.Purpose %></pre>
                                </div>
                                <div class="experiment-steps">
                                    <h4>实验步骤：</h4>
                                    <hr>
                                    <pre><%= courseExperiment.Steps %></pre>
                                </div>
                                <div class="experiment-references">
                                    <h4>参考资料：</h4>
                                    <hr>
                                    <pre><%= courseExperiment.References %></pre>
                                </div>
                            </div>
                        </div>
                        <% i++;
                       } %>

                    </div>
                    </div>
                <div class="float-right">
                    <a href="EditExperiment.aspx?id=<%= cid %>" class="btn btn-large btn-primary" target="_blank">发布新实验</a>
                </div>
                
            </div>
        </div>
    </div>

    <script>
        (function init() {
            var allExpDet = document.getElementsByClassName('experiment-detail');
            for (var exp in allExpDet) {
                allExpDet[exp].style.display = 'none'
            }
        })();

        function expandOrCollapse(event) {
            var experiment = document.getElementsByClassName('experiment-detail')[
                parseInt(event.target.id.substr(event.target.id.lastIndexOf('-') + 1,
                    event.target.id.length))];
            var flagEx = experiment.style.display === 'none';
            if (experiment !== undefined) {
                experiment.style.display = flagEx ? 'block' : 'none';
            }
            var img = document.getElementById('img-' +
                parseInt(event.target.id.substr(event.target.id.lastIndexOf('-') + 1,
                    event.target.id.length)));
            if (img !== null) {
                img.src = flagEx ? '../../Images/up_arrow.svg' : '../../Images/down_arrow.svg';
            }
        }
    </script>
</asp:Content>