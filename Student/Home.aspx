<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="StudentHome" %>
<%@ Import Namespace="Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <% Student student = (Student) Session["user"];
       if (student == null)
       {
           Response.Redirect("~/Login.aspx");
           return;
       } %>
    <title><%= student.Name %> - 学生首页 - HAERMS</title>
    <link href="/Content/StudentDetail.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content">
        <div class="tool_box">
            <div class="search_box">
                学年&nbsp;
                <select name="schoolYear" id="">
                    <option value="2016-2017">2016-2017</option>
                    <option value="2015-2016">2015-2016</option>
                    <option value="2014-2015">2014-2015</option>
                    <option value="2013-2014">2013-2014</option>
                </select>&nbsp;&nbsp;
                学期&nbsp;
                <select name="schoolTerm" id="">
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                </select>&nbsp;&nbsp;
                课程性质&nbsp;
                <select name="ClassProperty" id="">
                    <option value="1">必修</option>
                    <option value="2">选修</option>
                    <option value="3">限选</option>
                    <option value="4">辅修</option>
                </select>
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
                    <td>学号: 2015111111</td>
                    <td>姓名: 王力宏</td>
                    <td colspan="2">学院: 软件学院</td>
                </tr>
                <tr>
                    <td colspan="2">专业: 软件工程</td>
                    <td>专业方向: </td>
                    <td>行政班: 软件工程201502</td>
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
                        <th>课程代码</th>
                        <th>课程名称</th>
                        <th>课程性质</th>
                        <th>课程归属</th>
                        <th>学分</th>
                        <th>绩点</th>
                        <th>成绩</th>
                        <th>辅修标记</th>
                        <th>补考成绩</th>
                        <th>重修成绩</th>
                        <th>开课学院</th>
                        <th>备注</th>
                        <th>重修标记</th>
                    </tr>
                    <tr>
                        <td>item1</td>
                        <td>item2</td>
                        <td>item3</td>
                        <td>item4</td>
                        <td>item5</td>
                        <td>item6</td>
                        <td>item7</td>
                        <td>item8</td>
                        <td>item9</td>
                        <td>item10</td>
                        <td>item11</td>
                        <td>item12</td>
                        <td>item13</td>
                        <td>item14</td>
                        <td>item15</td>
                    </tr>
                    <tr>
                        <td>item1</td>
                        <td>item2</td>
                        <td>item3</td>
                        <td>item4</td>
                        <td>item5</td>
                        <td>item6</td>
                        <td>item7</td>
                        <td>item8</td>
                        <td>item9</td>
                        <td>item10</td>
                        <td>item11</td>
                        <td>item12</td>
                        <td>item13</td>
                        <td>item14</td>
                        <td>item15</td>
                    </tr>
                    <tr>
                        <td>item1</td>
                        <td>item2</td>
                        <td>item3</td>
                        <td>item4</td>
                        <td>item5</td>
                        <td>item6</td>
                        <td>item7</td>
                        <td>item8</td>
                        <td>item9</td>
                        <td>item10</td>
                        <td>item11</td>
                        <td>item12</td>
                        <td>item13</td>
                        <td>item14</td>
                        <td>item15</td>
                    </tr>
                    <tr>
                        <td>item1</td>
                        <td>item2</td>
                        <td>item3</td>
                        <td>item4</td>
                        <td>item5</td>
                        <td>item6</td>
                        <td>item7</td>
                        <td>item8</td>
                        <td>item9</td>
                        <td>item10</td>
                        <td>item11</td>
                        <td>item12</td>
                        <td>item13</td>
                        <td>item14</td>
                        <td>item15</td>
                    </tr>
                    <tr>
                        <td>item1</td>
                        <td>item2</td>
                        <td>item3</td>
                        <td>item4</td>
                        <td>item5</td>
                        <td>item6</td>
                        <td>item7</td>
                        <td>item8</td>
                        <td>item9</td>
                        <td>item10</td>
                        <td>item11</td>
                        <td>item12</td>
                        <td>item13</td>
                        <td>item14</td>
                        <td>item15</td>
                    </tr>
                    <tr>
                        <td>item1</td>
                        <td>item2</td>
                        <td>item3</td>
                        <td>item4</td>
                        <td>item5</td>
                        <td>item6</td>
                        <td>item7</td>
                        <td>item8</td>
                        <td>item9</td>
                        <td>item10</td>
                        <td>item11</td>
                        <td>item12</td>
                        <td>item13</td>
                        <td>item14</td>
                        <td>item15</td>
                    </tr>
                    <tr>
                        <td>item1</td>
                        <td>item2</td>
                        <td>item3</td>
                        <td>item4</td>
                        <td>item5</td>
                        <td>item6</td>
                        <td>item7</td>
                        <td>item8</td>
                        <td>item9</td>
                        <td>item10</td>
                        <td>item11</td>
                        <td>item12</td>
                        <td>item13</td>
                        <td>item14</td>
                        <td>item15</td>
                    </tr>
                </table>
            </div>
        </div>

    </div>
</asp:Content>