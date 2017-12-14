<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="Attachment.aspx.cs" Inherits="Class.Attachment" %>
<%@ Import Namespace="Models" %>
<%@ Import Namespace="BusinessLogicLayer.Impl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <% var cid = int.Parse(Request.QueryString["cid"]); %>
    <% var course = (Course) (new CourseServiceImpl().GetById(cid)); %>
    <title><%= course.Name %> - 实验 - HAERMS</title>
    <link href="../Content/index.css" rel="stylesheet" />
    <link href="../Content/classes.css" rel="stylesheet" />
    <link href="../Content/form-controls.css" rel="stylesheet" />
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
        <li class="list-class-item selected-class-item">
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
<div class="table-filter-group">
    <button class="float-left btn btn-primary filter-button" onclick="">批量下载(To Be Programmed)</button>
    <div class="input-group float-left filter-div">
        <label for="filter-context">过滤条件</label>
        <input type="text" id="filter-context">
    </div>
    <button onclick="" class="float-left btn btn-primary filter-button">搜索(To Be Programmed)</button>
</div>
<table class="attachment-table clear" border="2">
<tr>
    <th class="">
        <div class="cell">
            <label for="" class="el_switch" id="el_switch">
                <span class="switch_core" id="switch_core">
                    <span class="switch_button" id="switch_button">
                        <input type="checkbox" name="" id="checkbox-input">
                    </span>
                </span>
            </label>
        </div>
    </th>
    <th>课件名称</th>
    <th>发布日期</th>
    <th>操作</th>
</tr>
<tr>
    <td>
        <div class="content-cell">
            <span>1</span>
        </div>
    </td>
    <td>
        <div class="content-cell">
            <span>尊重.ppt(To Be Programmed)</span>
        </div>
    </td>
    <td>
        <div class="content-cell">
            <span>2017年11月14日(To Be Programmed)</span>
        </div>
    </td>
    <td>
        <div class="content-cell">
            <button class="btn btn-success">下载(To Be Programmed)</button>
        </div>
    </td>
</tr>
</table>
</div>
</div>
</div>
<script>
    var i = 0;
    var label = document.getElementById('el_switch');

    function change() {
        var flag = i % 2 === 0;
        document.getElementById('switch_button').style.transform =
            flag ? 'translate(2px, 2px)' : 'translate(26px, 2px)';
        document.getElementById('switch_core').style.backgroundColor = flag ? '#bfcbd9' : '#20a0ff';
        i++;
    }

    label.addEventListener('click', change, false);

</script>
</asp:Content>