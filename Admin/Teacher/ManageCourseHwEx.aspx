<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="ManageCourseHwEx.aspx.cs" Inherits="Admin.Teacher.Admin_ManageCourseHwEx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>管理作业实验 - HAERMS</title>
    <link href="../../Content/index.css" rel="stylesheet" />
    <link href="../../Content/classes.css" rel="stylesheet" />
    <link href="../../Content/form-controls.css" rel="stylesheet" />
    <link href="../../Content/manageCourseHwEx.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--是作业还是实验根据PreviousPage决定-->
<!--an-experiment和an-homework内容去TeacherCourseExperiment和TeacherCourseHomework里面抄-->
<div class="main-content">
    <div class="sidebar">
        <% if (PageType == "ex")
           {%>
        <h2>实验详情</h2>
        <hr>
        <div class="an-experiment">
            <div class="title-box" id="title-box-0">
                <span class="experiment-name" id="experiment-name-0"><%= ExInfo["name"] %></span>
                <span class="experiment-deadline" id="experiment-deadline-0">截止时间：<%= ExInfo["deadline"] %></span>
            </div>
            <div class="experiment-purpose">
                <h4>实验目的：</h4>
                <hr>
                <%= ExInfo["purpose"] %>
            </div>
            <div class="experiment-steps">
                <h4>实验步骤：</h4>
                <hr>
                <%= ExInfo["steps"] %>
            </div>
            <div class="experiment-references">
                <h4>参考资料：</h4>
                <hr>
                <%= ExInfo["references"] %>
            </div>
        </div>
         <%}
            else
            { %>
            <h2>作业详情</h2>
            <hr>
            <div class="an-experiment">
                <div class="title-box" id="title-box-0">
                    <span class="experiment-name" id="experiment-name-0"><%= HoInfo["name"] %></span>
                    <span class="experiment-deadline" id="experiment-deadline-0">截止时间：<%= HoInfo["deadline"] %></span>
                </div>
                <div class="experiment-purpose">
                    <h4>作业内容：</h4>
                    <hr>
                    <%= HoInfo["purpose"] %>
                </div>
            </div>
         <% } %>
    </div>

    <form class="student-list-container card" runat="server">
        <h2>学生列表</h2>
        <table class="attachment-table" border="2">
            <tr>
                <th>学号</th>
                <th>姓名</th>
                <th>文件</th>
                <th>评分</th>
                <th>操作</th>
            </tr>
            <% if (PageType == "ex")
               {
                foreach (var ex in ExList)
                {%>
            <tr>
                <td class="content-cell">
                    <span><%= ex.stunum %></span>
                </td>
                <td class="content-cell name">
                    <span><%= ex.stuname %></span>
                </td>
                <td class="content-cell">
                    <span><% if (ex.filename == null){%>未提交<%}else {%> <%= ex.filename %><%} %></span>
                </td>
                <td class="content-cell">
                    <div class="experiment-operation">
                        <% if (ex.filename == null){%><%}else {%> <input name="input-mark" title="评分" class="input-style" type="number" max="100" min="0" id="<%= ex.exid %>" placeholder="分数" value="<%= ex.mark %>"/><%} %>
                    </div>
                </td>
                <td class="content-cell">
                    <div class="experiment-operation">
                        <% if (ex.filename != null)
                            {%>
                        <a href="<%=ex.path %>" class="btn btn-success" download="<%=ex.filename %>">下载</a>
                        <a href="DeletePage.aspx?ex=<%=ex.exid %>" class="btn btn-danger">删除</a><%} %>
                    </div>
                </td>
            </tr>
            <%}} %>
            <% else{
            foreach(var ho in HoList) {%>
                <tr>
                <td class="content-cell">
                    <span><%= ho.stunum %></span>
                </td>
                <td class="content-cell name">
                <span><%= ho.stuname %></span>
                </td>
                <td class="content-cell">
                    <span><% if (ho.filename == null){%>未提交<%}else {%> <%= ho.filename %><%} %></span>
                </td>
                <td class="content-cell">
                    <div class="experiment-operation">
                        <% if (ho.filename == null){%>未提交<%}else {%> <input name="input-mark" title="评分" class="input-style" type="number" max="100" min="0" placeholder="分数" value="<%= ho.mark %>"/><%} %>
                    </div>
                </td>
                <td class="content-cell">
                    <div class="experiment-operation">
                        <% if (ho.filename != null)
                            {%>
                        <a href="<%=ho.path %>" class="btn btn-success" download="<%=ho.filename %>">下载</a>
                        <a href="DeletePage.aspx?ho=<%=ho.hoid %>" class="btn btn-danger">删除</a><%} %>
                    </div>
                </td>
            </tr>
                
            <% }} %>
        </table>
        <div class="below-table">
            <asp:button class="btn btn-primary" runat="server" type="submit" Text="提交成绩" OnClick="updatemark_Click"></asp:button>
        </div>
        <asp:ObjectDataSource>

        </asp:ObjectDataSource>
    </form>
</div>
</asp:Content>

