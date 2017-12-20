using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Impl;
using Models;

public partial class Admin_CourseList : System.Web.UI.Page
{

    private string[] teacherName = new string[2];
    private IEnumerable<Course> course;
    protected void Page_Load(object sender, EventArgs e)
    {
        var nowloginuser = Session["user"];
        if (nowloginuser == null)
        {
            Response.Redirect("../../Login.aspx");
        }
        if((string)Session["userType"] != "teacher")
        {
            Response.Redirect("../../Default.aspx");
        }
        teacherName[0] = ((Teacher)nowloginuser).Name;
        teacherName[1] = ((Teacher)nowloginuser).TeacherId.ToString();

        course = new CourseServiceImpl().GetByTeacher((Teacher)nowloginuser);
    }

    public string[] TeacherName
    {
        get
        {
            return teacherName;
        }
    }

    public IEnumerable<Course> Course
    {
        get
        {
            return course;
        }
    }
}
