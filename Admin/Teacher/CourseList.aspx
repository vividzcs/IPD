<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="CourseList.aspx.cs" Inherits="Admin_CourseList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title></title>
    <link href="../Content/index.css" rel="stylesheet" />
    <link href="../Content/teacher-detail.css" rel="stylesheet" />
    <link href="../Content/courses-list.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content">
		<div class="teacher-name">
			<h2>何路<a href="#"><button class="create-course">创建课程</button></a></h2>
			<hr/>
		</div>
		<div class="courses">
			<div class="courses-info">
				<div class="hd">开课列表</div>
				<div class="bd">
					<div class="courses-list">
						<div class="course-card" id="course-card-0">
							<a  href="#"><span class="courses-name">软件工程</span></a>
							<span class="start-time">开课时间: 2017/9/1 -- 2017/12/31</span>
							<span class ="copy-courses">
								<a href="javascript:;"><button class="copy-courses-btn" type="button">复制课程</button></a>
							</span>
							<span class ="import-students">
								<a href="#"><button class="import-students-btn" type="button">导入学生名单</button></a>
							</span>
						</div>
						<div class="course-card" id="course-card-1">
							<a  href="#"><span class="courses-name">计算机网络</span></a>
							<span class="start-time">开课时间: 2017/9/1 -- 2017/12/31</span>
							<span class ="copy-courses">
								<a href="#"><button class="copy-courses-btn" type="button">复制课程</button></a>
							</span>
							<span class ="import-students">
								<a href="#"><button class="import-students-btn" type="button">导入学生名单</button></a>
							</span>
						</div>
						<div class="course-card" id="course-card-2">
							<a  href="#"><span class="courses-name">互联网程序设计</span></a>
							<span class="start-time">开课时间: 2017/9/1 -- 2017/12/31</span>
							<span class ="copy-courses">
								<a href="javascript:;"><button class="copy-courses-btn" type="button">复制课程</button></a>
							</span>
							<span class ="import-students">
								<a href="javascript:;"><button class="import-students-btn" type="button">导入学生名单</button></a>
							</span>
						</div>
						<div class="course-card" id="course-card-2">
							<a  href="#"><span class="courses-name">软件测试</span></a>
							<span class="start-time">开课时间: 2017/9/1 -- 2017/12/31</span>
							<span class ="copy-courses">
								<a href="#"><button class="copy-courses-btn" type="button">复制课程</button></a>
							</span>
							<span class ="import-students">
								<a href="#"><button class="import-students-btn" type="button">导入学生名单</button></a>
							</span>
						</div>
						<div class="course-card" id="course-card-2">
							<a  href="#"><span class="courses-name">高级网络管理</span></a>
							<span class="start-time">开课时间: 2017/9/1 -- 2017/12/31</span>
							<span class ="copy-courses">
								<a href="#"><button class="copy-courses-btn" type="button">复制课程</button></a>
							</span>
							<span class ="import-students">
								<a href="#"><button class="import-students-btn" type="button">导入学生名单</button></a>
							</span>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</asp:Content>

