<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="Homework.aspx.cs" Inherits="Class.Class_Homework" %>
<%@ Import Namespace="Models" %>
<%@ Import Namespace="BusinessLogicLayer.Impl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%--    通过调用业务逻辑CourseServiceImpl的GetById方法取得该课程的对象，给title赋值--%>
    <% var cid = int.Parse(Request.QueryString["cid"]); %>
    <% var course = (Course) (new CourseServiceImpl().GetById(cid)); %>
    <title><%= course.Name %> - 实验 - HAERMS</title>
    <link href="../Content/index.css" rel="stylesheet"/>
    <link href="../Content/classes.css" rel="stylesheet"/>
    <link href="../Content/form-controls.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <% var cid = int.Parse(Request.QueryString["cid"]); %>
    <% var course = (Course) (new CourseServiceImpl().GetById(cid)); %>

    <div class="">
        <nav class="sidebar">
            <div class="card">
                <img src="<%= course.IntroImage %>" class="image-item"/>
            </div>
            <ul class="list-class card">
                <li class="list-class-item">
                    <a href="Intro.aspx?cid=<%= cid %>">简介</a>
                </li>
                <li class="list-class-item">
                    <a href="Attachment.aspx?cid=<%= cid %>">课件</a>
                </li>
                <li class="list-class-item">
                    <a href="Experiment.aspx?cid=<%= cid %>">实验</a>
                </li>
                <li class="list-class-item selected-class-item">
                    <a href="Homework.aspx?cid=<%= cid %>">作业</a>
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
                                <%
                                    var homew = new HomeworkServiceImpl().Get((Student) Session["user"], homework);
                                    if (DateTime.Compare(homework.Deadline, DateTime.Now) > 0)
                                    {
                                        if (homew != null)
                                        { %>
                                        <span class="more-info">作业已经提交</span>
                                    <% }
                                        else
                                        {
                                            Session["ThatCourseHomework"] = homework;
                                    %>
                                        <!-- 提交作业 -->
                                        <form class="experiment-uploadhomework" runat="server">
                                            <asp:FileUpload runat="server" class="btn btn-info" ID="FileUploader" accept="application/msword,application/vnd.openxmlformats-officedocument.wordprocessingml.document,application/msexcel,application/pdf,application/rtf,application/x-zip-compressed"/>
                                            <asp:Button runat="server" Text="点击上传" CssClass="btn btn-primary" OnClick="FileUpload"/>
                                        </form>
                                        <!-- 提交作业-->
                                <%
                                        }
                                    }
                                    else
                                    {
                                        if (homew == null)
                                        {
                                %>
                                        <span class="more-info">你错过了时间</span>
                                    <%
                                        }
                                        else
                                        {
                                    %>
                                        <span class="more-info">分数：<%= homew.Mark %></span>
                                <%
                                        }
                                    }
                                %>
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
                img.src = flagHw ? '/Images/up_arrow.svg' : '/Images/down_arrow.svg';
            }
        }
    </script>
</asp:Content>