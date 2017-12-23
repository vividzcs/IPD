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
    }

    protected string[] TeacherName { get; } = new string[2];

    protected IEnumerable<Course> Course { get; private set; }
}
