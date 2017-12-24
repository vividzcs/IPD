using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Impl;
using Models;
using Utils;

public partial class Admin_CourseList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.LoginCheck(Session, Request, Response, Server);
        AuthHelper.TeacherOnlyPage(Session, Request, Response, Server);

        
        var teacher = new Teacher();
        if (Session["user"] is Teacher t)
        {
            teacher = t;
        }
        else
        {
            Session.RemoveAll();
            Response.Redirect("/Login.aspx");
        }
        
        TeacherName[0] = teacher.Name;
        TeacherName[1] = teacher.TeacherId.ToString();

        Course = new CourseServiceImpl().GetByTeacher(teacher);

        if (Request.QueryString["courseId"] != null)
        {
            //���ƿγ�
            int CourseId = int.Parse(Request.QueryString["courseId"]);
            CourseServiceImpl courseServiceImpl = new CourseServiceImpl();
            Course course = (Course)courseServiceImpl.GetById(CourseId);

            int newId = courseServiceImpl.Create(course);
            Response.Redirect("EditCourse.aspx?id=" + newId);
        }

    }

  

    protected string[] TeacherName { get; } = new string[2];

    protected IEnumerable<Course> Course { get; private set; }
    

}
