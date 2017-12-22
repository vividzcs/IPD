<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Student.StudentHome" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <% var student = (Models.Student) Session["user"];
       if (student == null)
       {
           Response.Redirect("~/Login.aspx?pre="+Server.UrlEncode(Request.Url.AbsoluteUri));
           return;
       } %>
    <title><%= student.Name %> - 学生首页 - HAERMS</title>
    <link href="/Content/StudentDetail.css" rel="stylesheet"/>
    <link href="/Content/form-controls.css" rel="stylesheet"/>
    <style type="text/css">
        .auto-style1 {
            width: 420px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="content">
        <div class="tool_box">
            <div class="search_box">
                &nbsp;
            </div>
        </div>
        <div class="main_box">
            <table class="stuIfo">
                <tr>
                    <th colspan="4">在校学习成绩</th>
                </tr>
                <tr>
                    <td>学号: <span runat="server" ID="SpanStudentNumber"></span></td>
                    <td class="auto-style1">姓名: <span runat="server" ID="SpanName"></span></td>
                    <td >
                        学院: <span runat="server" ID="SpanDepartment"></span>
                    </td>
                    <td>班级: <span runat="server" ID="SpanClass"></span></td>
                </tr>  
            </table>
            <div class="gradeData">
                <table class="dataList">
                    <tr>
                        <th>课程名称</th>
                        <th>成绩</th>
                        <th>开课学院</th>
                    </tr>
<%--                        <asp:Repeater runat="server" ID="RepeaterCourseAndScore"   >
                            <ItemTemplate>--%>
                        <%
                            foreach (var thiscourse in dep) { 
                                //var thisCourseTeacherId = new CourseServiceImpl().GetTeacherIdByCourseId(thiscourse.CourseId);
                                //  var thisTeacher = new TeacherServiceImpl().GetByTeacherId(thisCourseTeacherId);
                                //  var thisTeacherDep = new DepartmentServiceImpl().GetByDepId(thisTeacher.DepartmentId);
           
                                %>
                                <tr>
                                <td>
                                    <a href="/Class/Intro.aspx?cid=<%=thiscourse[0] %>"><%=thiscourse[1] %></a>
                                </td>
                                <td><%=thiscourse[2] %></td>
                                <td><%=thiscourse[3] %></td>
                                </tr>
                        <% } %>
<%--                            </ItemTemplate>
                        </asp:Repeater>--%>
                </table>
            </div>
        </div>

    </div>
</asp:Content>
