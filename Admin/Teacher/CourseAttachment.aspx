<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="CourseAttachment.aspx.cs" Inherits="Admin.Teacher.Admin_CourseAttachment" %>
<%@ Import Namespace="Models" %>
<%@ Import Namespace="BusinessLogicLayer.Impl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>课程附件 - HAERMS</title>

    <style>
        .input-style {
            border: solid 1px #d4d4d4;
            border-radius: 5px;
            outline: 0;
            padding: 5px;
            transition: border-color .2s cubic-bezier(.645, .045, .355, 1);
        }

        .input-style:hover { border: solid 1px #20a0ff; }
    </style>

    <link href="../../Content/index.css" rel="stylesheet"/>
    <link href="../../Content/classes.css" rel="stylesheet"/>
    <link href="../../Content/form-controls.css" rel="stylesheet"/>

    <style type="text/css">
        .auto-style1 { height: 24px; }
    </style>
  <script type="text/javascript">
      function verfy(attachmentId) {
          var reallydelete = confirm("确认删除？")
          if (reallydelete == true) {
              document.getElementById(attachmentId).name = attachmentId + "neededdeleted";
              return true;
          }
          else {
              return false;
          }
      }
  </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form runat="server">
        <% var cid = int.Parse(Request.QueryString["course"]); %>
        <% var course = (Course) (new CourseServiceImpl().GetById(cid)); %>
        <nav class="sidebar">
            <div class="card">
                <img src="<%= course.IntroImage %>" class="image-item" alt="课程图片"/>
            </div>
            <ul class="list-class card">
                <li class="list-class-item">
                    <a href="CoursePage.aspx?course=<%= cid %>">简介</a>
                </li>
                <li class="list-class-item selected-class-item">
                    <a href="CourseAttachment.aspx?course=<%= cid %>">课件</a>
                </li>
                <li class="list-class-item">
                    <a href="CourseExperiment.aspx?course=<%= cid %>">实验</a>
                </li>
                <li class="list-class-item">
                    <a href="CourseHomework.aspx?course=<%= cid %>">作业</a>
                </li>
            </ul>
        </nav>
        <div class="main-container">
            <div class="main-content card">
                <table class="attachment-table clear" border="2">
                    <tr>
                        <th class="auto-style1">课件名称</th>
                        <th class="auto-style1">发布日期</th>
                        <th class="auto-style1">操作</th>
                    </tr>
                    <% foreach (var atta in thisTeacherAttachment)
                       { %>

                        <tr>
                            <td>
                                <div class="content-cell">
                                    <span><%= atta.Name %></span>
                                </div>
                            </td>
                            <td>
                                <div class="content-cell">
                                    <span><%= atta.IssuedTime %></span>
                                </div>
                            </td>
                            <td>
                                <div class="content-cell">
                                        <input type="hidden" id="<%= atta.AttachmentId %>" name="<%= atta.AttachmentId %>" size="20" value="<%= atta.AttachmentId %>"/>
                                        <input type="submit" class="btn btn-danger" value="删除" onclick="return verfy(<%= atta.AttachmentId %>)">
                                        <%--                                <a href="" id="<%=atta.AttachmentId%>"class ="btn btn-danger" >删除</a>
                                <Button ID="deleteAttachment"  class="btn btn-danger" Text="删除"   OnCommand="deleteAttachment_Command" />
                                <asp:Label ID="verfyUploadFile" runat="server" Text=""></asp:Label>--%>
                                </div>
                            </td>
                        </tr>

                    <% } %>
                    <tr>
                        <td colspan="3" align="right">                
                            <a href="javascript:;" class="experiment-homeworkfile btn">
                            <asp:FileUpload ID="FileUploadCourseAttachment" runat="server"/>点击这里上传课件</a>
                            <asp:Button ID="UploadCourseAttachment" runat="server" Text="上传" class="btn experiment-upload" OnCommand="UploadCourseAttachment_Command"/>
                        </td> 
                    </tr>
                </table>
            </div>
        </div>
</form>

</asp:Content>