<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="Homework.aspx.cs" Inherits="Class.Homework" %>
<%@ Import Namespace="Models" %>
<%@ Import Namespace="BusinessLogicLayer.Impl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                    <asp:Repeater runat="server" ID="RepeaterCourseHomework">
                        <ItemTemplate>
                            <div class="an-homework">
                                <div class="title-box" id="title-box-<%# Container.ItemIndex%>">
                                    <img src="/Images/down_arrow.svg" id="img-<%# Container.ItemIndex%>">
                                    <span class="experiment-name" id="experiment-name-<%# Container.ItemIndex%>"><%#Eval("Name") %></span>
                                    <span class="experiment-deadline" id="experiment-deadline-<%# Container.ItemIndex%>">截止时间：<%#((DateTime) Eval("Deadline")).ToString("f") %></span>
                                    <!-- 提交作业 -->
                                    <span class="experiment-uploadhomework">
                                        <a href="javascript:;" class="experiment-homeworkfile btn">
                                            <input type="file" name="" id="">点击这里上传作业(To Be Programmed)
                                        </a>
                                        </a>
                                        <input type="submit" name="" value="提交作业(To Be Programmed)" class="btn experiment-upload">
                                    </span>
                                    <!-- 提交作业-->
                                </div>
                                <div class="homework-detail">
                                    <div class="experiment-purpose">
                                        <h4>作业内容</h4>
                                        <hr>
                                        <pre><%#Eval("Content") %></pre>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
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