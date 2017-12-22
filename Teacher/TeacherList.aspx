<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="TeacherList.aspx.cs" Inherits="TeacherList" %>
<%@ Import Namespace="Models" %>
<%@ PreviousPageType VirtualPath="~/Default.aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>教师列表 - HAERMS</title>
    <link rel="stylesheet" href="/Content/teacherList.css"/>
    <link href="/Content/managedepart.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content">
        <div class="container">
            <h2>师资队伍</h2>
            <asp:Repeater runat="server" DataSourceID="ObjectDataSourceTeacherListOfDepartment">
                <ItemTemplate>
                    <div class="block">
                        <div class="headPic">
                            <img src="<%#Eval("HeadImage") %>" alt="头像"/>
                        </div>
                        <div class="teacherInfo">
                            <h2><%#Eval("Name") %></h2>
                            <p class="block-with-text intro"><%#Eval("Introduction") %></p>
                        </div>
                        <p>
                            <% if (Session["user"] is Teacher)
                               { %>
                                <a class="btn">点击查看>></a>
                            <% }
                               else
                               { %>
                                <a class="btn" href="TeacherHome.aspx?tid=<%#Eval("TeacherId") %>">点击查看>></a>
                            <% } %>
                        </p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource runat="server" ID="ObjectDataSourceTeacherListOfDepartment" SelectMethod="GetTeachers" TypeName="BusinessLogicLayer.Impl.TeacherServiceImpl">
                <SelectParameters>
                    <asp:QueryStringParameter QueryStringField="did" DefaultValue="2" Name="departmentId" Type="Int32"></asp:QueryStringParameter>
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>