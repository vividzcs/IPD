﻿<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="Intro.aspx.cs" Inherits="Class.Intro" %>
<%@ Import Namespace="BusinessLogicLayer.Impl" %>
<%@ Import Namespace="Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%--    通过调用业务逻辑CourseServiceImpl的GetById方法取得该课程的对象，给title赋值--%>
    <% var cid = int.Parse(Request.QueryString["cid"]); %>
    <% var course = (Course) (new CourseServiceImpl().GetById(cid)); %>
    <title><%= course.Name %> - 课程首页 - HAERMS</title>
    <link href="../Content/index.css" rel="stylesheet"/>
    <link href="../Content/classes.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <% var cid = int.Parse(Request.QueryString["cid"]); %>
    <% var course = (Course) (new CourseServiceImpl().GetById(cid)); %>
    <% var teacherId = course.TeacherId;
       var teacher = (Teacher) (new TeacherServiceImpl().GetById(teacherId)); %>
    <div class="">
        <nav class="sidebar">
            <div class="card">
                <img src="<%= course.IntroImage %>" class="image-item" alt="课程图片"/>
            </div>
            <ul class="list-class card">
                <li class="list-class-item selected-class-item">
                    <a href="Intro.aspx?cid=<%= cid %>">简介</a>
                </li>
                <li class="list-class-item">
                    <a href="Attachment.aspx?cid=<%= cid %>">课件</a>
                </li>
                <li class="list-class-item">
                    <a href="Experiment.aspx?cid=<%= cid %>">实验</a>
                </li>
                <li class="list-class-item">
                    <a href="Homework.aspx?cid=<%= cid %>">作业</a>
                </li>
            </ul>
        </nav>
        <div class="main-container">
            <div class="main-content card">
                <h2><%= course.Name %></h2>
                <h5 class="teacher"><%= teacher.Name %></h5>
                <hr>
                <div class="paragraphs">
                    <p>
                        <%= course.ShortIntroduction %>
                    </p>
                </div>
            </div>
            <div class="main-content card">
                <h2>课程概述</h2>
                <hr>
                <div class="paragraphs">
                    <% var description = course.Description;
                       if (description == null)
                       {%>
                            <p>课程暂无概述</p>
                       <%}
                       else
                       {
                           var desSplit = description.Split(Environment.NewLine.ToCharArray());
                           foreach (var p in desSplit)
                           {
                               var pTrimed = p.Trim();
                    %>
                            <p><%= pTrimed %></p>
                    <% }
                       } %>
                </div>
            </div>
            <div class="main-content card">
                <h2>授课教师</h2>
                <hr>
                <img class="teacher-image" src="<%= teacher.HeadImage %>"/>
                <div class="teacher-info">
                    <span class=""><%= teacher.Introduction %></span>
                    <br>
                    <span class="teacher-position"><%= teacher.Title %></span>
                </div>
            </div>
            <div class="main-content card">
                <h2>课程时间</h2>
                <hr>
                <table class="class-hour-table" border="2">
                    <tr>
                        <td class="table-head">开课时间</td>
                        <td><%= course.BeginDate.GetValueOrDefault().ToString("D") %> - <%= course.EndDate.GetValueOrDefault().ToString("D") %></td>
                    </tr>
                    <tr>
                        <td class="table-head">课时安排</td>
                        <td>理论<%= course.TheoryClassHour %>课时 + 实验<%= course.ExperimentClassHour %>课时</td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>