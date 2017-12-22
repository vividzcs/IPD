<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="CourseList.aspx.cs" Inherits="Admin_CourseList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title></title>
    <link href="/Content/index.css" rel="stylesheet" />
    <link href="/Content/teacher-detail.css" rel="stylesheet" />
    <link href="/Content/courses-list.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content">
		<div class="teacher-name">
			<h2><%= TeacherName[0] %><a href="CreateCourse.aspx?teacher=<%= TeacherName[1] %>"><button class="create-course">创建课程</button></a></h2>
			<hr/>
		</div>
		<div class="courses">
			<div class="courses-info">
				<div class="hd">开课列表</div>
				<div class="bd">
                    <%int i = 1;  foreach (var course in Course)
                        { %>
					<div class="courses-list">
						<div class="course-card" id="course-card-<%= i %>">
							<a  href="CoursePage.aspx?course=<%=course.CourseId %>"><span class="courses-name"><%= course.Name %></span></a>
							<span class="start-time">开课时间: <%= course.BeginDate %> -- <%= course.EndDate %></span>
							<span class ="copy-courses">
								<a href="javascript:;"><button class="copy-courses-btn" type="button">复制课程</button></a>
							</span>
							<span class ="import-students">
								<a href="ImportStudent.aspx?course=<%=course.CourseId %>"><button class="import-students-btn" type="button">导入学生名单</button></a>
							</span>
						</div>
					</div>
                    <%} i++;%>
				</div>
			</div>
		</div>
	</div>
</asp:Content>

