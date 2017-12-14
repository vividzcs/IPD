<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="TeacherDetail.aspx.cs" Inherits="Teacher_TeacherDetail" %>
<%@ Import Namespace="BusinessLogicLayer.Impl" %>
<%@ Import Namespace="Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <% if (Request.QueryString["tid"] == null)
       {
           Response.Redirect("/Teacher/TeacherList.aspx");
           return;
       } %>
    <% var teacher = (Teacher) (new TeacherServiceImpl().GetById(int.Parse(Request.QueryString["tid"]))); %>
    <title><%= teacher.Name %> - 教师首页 - HAERMS</title>
    <link href="../Content/index.css" rel="stylesheet" />
    <link href="../Content/teacher-detail.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <% if (Request.QueryString["tid"] == null)
       {
           Response.Redirect("/Teacher/TeacherList.aspx");
           return;
       } %>
    <% var teacher = (Teacher) (new TeacherServiceImpl().GetById(int.Parse(Request.QueryString["tid"]))); %>
    <div class="content">
        <div class="content-show">
            <img src="<%= teacher.HeadImage %>" />
            <ul class="tea-info">
                <li>
                    <span class="tea-name"><%= teacher.Name %></span>
                    <span class="tea-job-title"><%= teacher.Title %></span>
                </li>
                <li>工号: <%= teacher.JobNumber %></li>
                <li>院系: to be programmed</li>
                <li>个人简介: <%= teacher.Introduction %></li>
            </ul>
        </div>
        <div class="courses-info">
            <div class="hd">开课列表</div>
            <div class="bd">
                <ul id="courses-list">
                    <li>
                        <a href="#">1. to be programmed</a>
                    </li>
                    <li>
                        <a href="#">2.  to be programmed</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>