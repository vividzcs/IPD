<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="CourseList.aspx.cs" Inherits="Admin_CourseList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title></title>
    <link href="/Content/index.css" rel="stylesheet"/>
    <link href="/Content/teacher-detail.css" rel="stylesheet"/>
    <link href="/Content/courses-list.css" rel="stylesheet"/>
    <link href="../../Content/form-controls.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content">
        <div class="teacher-name">
            <h2>
                <%= TeacherName[0] %><a href="CreateCourse.aspx?teacher=<%= TeacherName[1] %>">
                    <button class="create-course">创建课程</button>
                </a>
            </h2>
            <hr/>
        </div>
        <div class="courses">
            <div class="courses-info">
                <div class="hd">开课列表</div>
                <div class="bd">
                    <% int i = 1;
                       foreach (var course in Course)
                       { %>
                        <div class="courses-list">
                            <div class="course-card" id="course-card-<%= i %>">
                                <a href="CoursePage.aspx?course=<%= course.CourseId %>">
                                    <span class="courses-name"><%= course.Name %></span>
                                </a>

                                <span class="start-time">开课时间: <%= course.BeginDate.GetValueOrDefault().ToString("D") %> -- <%= course.EndDate.GetValueOrDefault().ToString("D") %></span>
                                <div class="btn-form">
                                    <a href="CourseList.aspx?courseId=<%=course.CourseId %>" class="btn">复制课程</a>
                                    <a href="javascript:" onclick="window.open('ExcelImport.aspx?course=<%= course.CourseId %>', 'popup_window', 'width=600,height=200,left=100,top=100,resizable=yes');" class="btn">从Excel导入</a>
                                    <%--用a标签，href=javascript:,onclick为js弹出窗口的代码--%>
                                    <a href="ImportStudent.aspx?course=<%= course.CourseId %>" class="btn">导入学生名单</a>
                                </div>
                            </div>
                        </div>
                    <% }
                       i++; %>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
