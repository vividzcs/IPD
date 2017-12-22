using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using BusinessLogicLayer.Impl;
using BusinessLogicLayer.Interface;
public partial class Admin_CourseAttachment : System.Web.UI.Page
{
    public IEnumerable<CourseAttachment> thisTeacherAttachment;
    protected void Page_Load(object sender, EventArgs e)
    {

        //需要登录才能看到
        var session = Session["user"];
        if (session == null)
        {
            //没有登录转到登录界面
            Response.Redirect("~/Login.aspx?pre=" + Server.UrlEncode(Request.Url.AbsoluteUri));

            return;
        }
        var teacher = new Models.Teacher();
        if (session is Models.Teacher t)
        {
            teacher = t;
        }
        else
        {
            //登录的不是老师，转到登录界面
            Session.Remove("user");
            Response.Redirect("~/login.aspx");
            return;
        }
        var courseAttachment = new AttachmentServiceImpl();
        var teacherCourse = new CourseServiceImpl();
        //获得当前老师教的课程
        var nowCourse = teacherCourse.GetByTeacher(teacher);
        var nowAttachment = courseAttachment.Get(nowCourse.First());
        thisTeacherAttachment = nowAttachment;
        //var nowAttachment_id =((CourseAttachment)thisTeacherAttachment).AttachmentId;
        try
        {
            var neededDeleteAttachmentId = int.Parse(Request.Form.Keys[2]);
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
        catch(Exception ex) {
            //没有提交表单不做处理
            //Console.Write("...");
        }

    }




}