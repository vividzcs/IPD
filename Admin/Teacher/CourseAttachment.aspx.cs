using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.Impl;
using Models;
using Utils;

namespace Admin.Teacher
{
    public partial class Admin_CourseAttachment : System.Web.UI.Page
    {
        public IEnumerable<CourseAttachment> thisTeacherAttachment;
        protected void Page_Load(object sender, EventArgs e)
        {

            //需要登录才能看到
            AuthHelper.LoginCheck(Session, Request, Response, Server);
            AuthHelper.TeacherOnlyPage(Session, Request, Response, Server);

            var teacher = new Models.Teacher();
            string cidString = "";
            if (Session["user"] is Models.Teacher t)
            {
                teacher = t;
                //需要登录和cid(courseId)才能访问到的页面
                cidString = Request.QueryString["course"];
                if (string.IsNullOrEmpty(cidString))
                {
                    Response.Redirect("/Default.aspx");
                }
            }
            else
            {
                //登录的不是老师，转到登录界面
                Session.Remove("user");
                Response.Redirect("~/Login.aspx?pre=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }


            var courseAttachment = new AttachmentServiceImpl();
            var teacherCourse = new CourseServiceImpl();
            //获得当前老师教的课程
            var nowCourse = new CourseServiceImpl().GetByCourseId(int.Parse(cidString));
            var nowAttachment = courseAttachment.Get(nowCourse);
            thisTeacherAttachment = nowAttachment;
            //var nowAttachment_id =((CourseAttachment)thisTeacherAttachment).AttachmentId;
            try
            {
                var neededDeleteAttachmentId = int.Parse(Request.Form.Keys[1]);
                if (new AttachmentServiceImpl().DeleteByAttachemtId(neededDeleteAttachmentId))
                {
                    //删除成功
                    Response.Write("<script language='javascript'>alert('删除成功！');</script>");
                }
                else
                {
                    //删除失败
                    Response.Write("<script language='javascript'>alert('删除失败！');</script>");
                }
            }
            catch (Exception)
            {
                //没有提交表单不做处理
                //Console.Write("...");
            }

        }




    }
}