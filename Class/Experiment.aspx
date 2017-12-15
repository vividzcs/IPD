<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="Experiment.aspx.cs" Inherits="Class.Class_Experiment" %>
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
                <li class="list-class-item selected-class-item">
                    <a href="Experiment.aspx?cid=<%= cid %>">实验</a>
                </li>
                <li class="list-class-item">
                    <a href="Homework.aspx?cid=<%= cid %>">作业</a>
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
                                <%
                                    var exp = new ExperimentServiceImpl().Get((Student) Session["user"], courseExperiment);
                                    if (DateTime.Compare(courseExperiment.Deadline.GetValueOrDefault(), DateTime.Now) > 0)
                                    {
                                        if (exp != null)
                                        { %>
                                        <span class="more-info">实验报告已经提交</span>
                                    <% }
                                        else
                                        {
                                            Session["ThatCourseExperiment"] = courseExperiment;
                                    %>
                                        <!-- 提交实验报告 -->
                                        <form class="experiment-uploadhomework" runat="server">
                                            <asp:FileUpload runat="server" class="btn btn-info" ID="ExperimentUploader" accept="application/msword,application/vnd.openxmlformats-officedocument.wordprocessingml.document,application/msexcel,application/pdf,application/rtf,application/x-zip-compressed"/>
                                            <asp:Button runat="server" Text="点击上传" CssClass="btn btn-primary" OnClick="FileUpload"/>
                                        </form>
                                        <!-- 提交作业-->
                                <%
                                        }
                                    }
                                    else
                                    {
                                        if (exp == null)
                                        { %>
                                        <span class="more-info">你错过了时间</span>
                                    <% }
                                        else
                                        {
                                    %>
                                        <span class="more-info">分数：<%= exp.Mark %></span>
                                <%
                                        }
                                    }
                                %>


                            </div>
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
        </div>
    </div>
    <script>
        (function() {
            var allExpDet = document.getElementsByClassName('experiment-detail');
            for (var exp in allExpDet) {
                if (allExpDet.hasOwnProperty(exp)) {
                    allExpDet[exp].style.display = 'none';
                }
            }
        })();

        function expandOrCollapse(event) {
            var experiment = document.getElementsByClassName('experiment-detail')[
                parseInt(event.target.id.substr(event.target.id.lastIndexOf('-') + 1,
                    event.target.id.length))];
            var flagEx = experiment.style.display === 'none';

            experiment.style.display = flagEx ? 'block' : 'none';

            var img = document.getElementById('img-' +
                parseInt(event.target.id.substr(event.target.id.lastIndexOf('-') + 1,
                    event.target.id.length)));
            if (img !== null && img !== undefined) {
                img.src = flagEx ? '/Images/up_arrow.svg' : '/Images/down_arrow.svg';
            }
        }
    </script>
</asp:Content>