<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="Attachment.aspx.cs" Inherits="Class.Attachment" %>
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

                <h2>课件列表</h2>
                <hr/>
                <table class="attachment-table clear" border="2">
                    <tr>
                        <th>序号</th>
                        <th>课件名称</th>
                        <th>发布日期</th>
                        <th>操作</th>
                    </tr>
                    <asp:Repeater runat="server" DataSourceID="ObjectDataSourceAttachments">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <div class="content-cell">
                                        <span><%# Container.ItemIndex + 1 %></span>
                                    </div>
                                </td>
                                <td>
                                    <div class="content-cell">
                                        <span><%#Eval("Name") %></span>
                                    </div>
                                </td>
                                <td>
                                    <div class="content-cell">
                                        <span><%#Eval("IssuedTime") %></span>
                                    </div>
                                </td>
                                <td>
                                    <div class="content-cell">
                                        <a href="<%#Eval("Path") %>" class="btn btn-success" download="<%#Eval("Name") %>">下载</a>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:ObjectDataSource runat="server" ID="ObjectDataSourceAttachments" SelectMethod="Get" TypeName="CourseAttachmentServiceimpl">
                        <SelectParameters>
                            <asp:QueryStringParameter QueryStringField="cid" Name="courseId" Type="Int32"></asp:QueryStringParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </table>
            </div>
        </div>
    </div>
    <script>
    </script>
</asp:Content>