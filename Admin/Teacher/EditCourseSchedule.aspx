<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="EditCourseSchedule.aspx.cs" Inherits="Admin_Teacher_EditCourseSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>编辑课程 - 时间安排 - HAERMS</title>
    <link href="../../Content/index.css" rel="stylesheet" />
    <link href="../../Content/classes.css" rel="stylesheet" />
    <link href="../../Content/teacher-style.css" rel="stylesheet" />
    <link href="../../Content/form-controls.css" rel="stylesheet" />
    <link href="../../Content/progressbar.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="progressbar-container progressbar-margin-top">
        <ul class="progressbar">
            <li>基本信息</li>
            <li>详细介绍</li>
            <li class="active">时间安排</li>
            <li>上传课件</li>
            <li>上传实验</li>
            <li>上传作业</li>
        </ul>
    </div>

    <form class="main-container create-class-main-container" runat="server">
        <div class="main-content card">
            <h2>课程时间</h2>
            <input id="CourseId" type="hidden" runat="server"/>
            <hr>
            <table class="class-hour-table" border="2">
                <tr>
                    <td class="table-head">开课时间</td>
                    <td>
                        <input id="BeginDate" title="开始时间" type="text" class="input-style" min="2017-09-01" max="2099-12-31" runat="server"/>
                        -
                        <input id="EndDate" title="结束时间" type="text" class="input-style" min="2017-09-01" max="2099-12-31" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td class="table-head">课时安排</td>
                    <td>
                        理论<input id="TheoryClassHour" title="理论课时" type="number" class="input-style" min="1" max="300" runat="server"/>课时
                        +
                        实验<input id="ExperimentClassHour" title="实验课时" type="number" class="input-style" min="1" max="300" runat="server"/>课时
                    </td>
                </tr>
            </table>
        </div>
        <div class="button-group">
            &nbsp;&nbsp;&nbsp;<asp:label runat="server" id="Label" style="color:red" ></asp:label><br/>
            <asp:button class="btn btn-warning" runat="server" text="跳过" OnClick ="StepOver" />
            <asp:button class="btn btn-success" runat="server" text="完成，下一步" OnClick="NextStep" />
        </div>
    </form>
</asp:Content>


