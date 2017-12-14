<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Student.StudentHome" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <% Models.Student student = (Models.Student) Session["user"];
       if (student == null)
       {
           Server.Transfer("/Login.aspx");
           return;
       } %>
    <title><%= student.Name %> - 学生首页 - HAERMS</title>
    <link href="/Content/StudentDetail.css" rel="stylesheet"/>
    <link href="/Content/form-controls.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="content">
        <div class="tool_box">
            <div class="search_box">
                学年&nbsp;
                <select name="schoolYear" id="SchoolYearSelector" runat="server" class="input-style">
                    <option value="2015-2016">2015-2016</option>
                    <option value="2016-2017">2016-2017</option>
                    <option value="2017-2018" selected="selected">2017-2018</option>
                    <option value="2018-2019">2018-2019</option>
                </select>&nbsp;&nbsp;
                学期&nbsp;
                <select name="schoolTerm" id="SemesterSelector" runat="server" class="input-style">
                    <option value="1" selected="selected">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                </select>&nbsp;&nbsp;
            </div>
            <div class="search_box">
                <input class="s_btn" type="button" value="学期成绩">
                <input class="s_btn" type="button" value="学年成绩">
                <input class="s_btn" type="button" value="历年成绩">
            </div>
        </div>
        <div class="main_box">
            <table class="stuIfo">
                <tr>
                    <th colspan="4">在校学习成绩</th>
                </tr>
                <tr>
                    <td>学号: <span runat="server" ID="SpanStudentNumber"></span></td>
                    <td>姓名: <span runat="server" ID="SpanName"></span></td>
                    <td colspan="2">
                        学院: <span runat="server" ID="SpanDepartment"></span>
                    </td>
                </tr>
                <tr>
                    <td>班级: <span runat="server" ID="SpanClass"></span></td>
                </tr>
                <tr>
                    <td colspan="4" height="4"></td>
                </tr>
            </table>
            <div class="gradeData">
                <table class="dataList">
                    <tr>
                        <th>学年</th>
                        <th>学期</th>
                        <th>课程名称</th>
                        <th>成绩</th>
                        <th>开课学院</th>
                    </tr>
                    <tr>
                        <asp:Repeater runat="server" ID="RepeaterCourseAndScore">
                            <ItemTemplate>
                                <td><%#Eval("SchoolYear") %></td>
                                <td><%#Eval("Semester") %></td>
                                <td>
                                    <a href="/Class/Intro.aspx?cid=<%#Eval("CourseId").ToString() %>"><%#Eval("Name") %></a>
                                </td>
                                <td>to be programmed</td>
                                <td>to be programmed</td>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tr>
                </table>
            </div>
        </div>

    </div>
</asp:Content>