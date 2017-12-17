<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="CourseAttachment.aspx.cs" Inherits="Admin_CourseAttachment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>课程附件 - HAERMS</title>
    <link href="../Content/index.css" rel="stylesheet"/>
    <link href="../Content/classes.css" rel="stylesheet"/>
    <link href="../Content/form-controls.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="">
        <nav class="sidebar">
            <div class="card">
                <img src="../../style/images/course-main_image.png" class="image-item"/>
            </div>
            <ul class="list-class card">
                <li class="list-class-item">
                    <a href="#">简介</a>
                </li>
                <li class="list-class-item selected-class-item">
                    <a href="#">课件</a>
                </li>
                <li class="list-class-item">
                    <a href="#">实验</a>
                </li>
                <li class="list-class-item">
                    <a href="#">作业</a>
                </li>
            </ul>
        </nav>
        <div class="main-container">
            <div class="main-content card">
                <table class="attachment-table clear" border="2">
                    <tr>
                        <th>章节</th>
                        <th>课件名称</th>
                        <th>发布日期</th>
                        <th>操作</th>
                    </tr>
                    <tr>
                        <td>
                            <div class="content-cell">
                                <span>第一章</span>
                            </div>
                        </td>
                        <td>
                            <div class="content-cell">
                                <span>尊重.ppt</span>
                            </div>
                        </td>
                        <td>
                            <div class="content-cell">
                                <span>2017年11月14日</span>
                            </div>
                        </td>
                        <td>
                            <div class="content-cell">
                                <button class="btn btn-danger">删除</button>
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
//        document.getElementById('checkbox-input').value = flag ? 'off' : 'on';
            document.getElementById('switch_core').style.backgroundColor = flag ? '#bfcbd9' : '#20a0ff';
            i++
        }

        label.addEventListener('click', change, false);

    </script>
</asp:Content>