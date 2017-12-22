<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="CourseAttachment.aspx.cs" Inherits="Admin_CourseAttachment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>课程附件 - HAERMS</title>
<<<<<<< HEAD:Admin/CourseAttachment.aspx
    <link href="../Content/index.css" rel="stylesheet"/>
    <link href="../Content/classes.css" rel="stylesheet"/>
    <link href="../Content/form-controls.css" rel="stylesheet"/>
    <style>
    .input-style {
        border: solid 1px #d4d4d4;
        border-radius: 5px;
        outline: 0;
        padding: 5px;
        transition: border-color .2s cubic-bezier(.645,.045,.355,1);
    }
    .input-style:hover {
        border: solid 1px #20a0ff;
    }
        </style>
=======
    <link href="../../Content/index.css" rel="stylesheet"/>
    <link href="../../Content/classes.css" rel="stylesheet"/>
    <link href="../../Content/form-controls.css" rel="stylesheet"/>
>>>>>>> origin:Admin/Teacher/CourseAttachment.aspx
    <style type="text/css">
        .auto-style1 {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
    <div class="">
        <nav class="sidebar">
            <div class="card">
                <img src="../../Images/course-main_image.png" class="image-item"/>
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
                <table class ="attachment-table clear" border="2" >
                    <tr>
                        <th class="auto-style1">章节</th>
                        <th class="auto-style1">课件名称</th>
                        <th class="auto-style1">发布日期</th>
                        <th class="auto-style1">操作</th>
                    </tr>
                    <% foreach (var atta in thisTeacherAttachment)
                        { %>
                    <tr>
                        <td>
                            <div class="content-cell">
                                <span><%="第"+atta.AttachmentId+"章"%></span>
                            </div>
                        </td>
                        <td>
                            <div class="content-cell">
                                <span><%=atta.Name%></span>
                            </div>
                        </td>
                        <td>
                            <div class="content-cell">
                                <span><%=atta.IssuedTime%></span>
                            </div>
                        </td>
                        <td>
                            <div class="content-cell">
                                <form id="deleteAttachment" method="post"  action="CourseAttachment.aspx">
                                    <input type="hidden" name="<%=atta.AttachmentId%>" size="20" value="<%=atta.AttachmentId%>" />
                                    <input type="submit" class="btn btn-danger" value="删除"> 
                                 <%--                                <a href="" id="<%=atta.AttachmentId%>"class ="btn btn-danger" >删除</a>
                                <Button ID="deleteAttachment"  class="btn btn-danger" Text="删除"   OnCommand="deleteAttachment_Command" />
                                <asp:Label ID="verfyUploadFile" runat="server" Text=""></asp:Label>--%>
                                </form>
                                    </div>
                        </td>
                    </tr>
                    <%} %>
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
    </form>
</asp:Content>