using BusinessLogicLayer.Impl;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CreateCourse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var all = new ClassServiceImpl().GetAll();

            DropDownList1.DataSource = all;
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "ClassId";
            DropDownList1.DataBind();
    }
    
    protected void NextStep(object sender, EventArgs e)
    {
        Teacher teacher = (Teacher)Session["user"];
        Course course = new Course()
        {
            Name = CourseName.Value,
            ShortIntroduction = ShortCourseIntro.Value,
            TeacherId = teacher.TeacherId,
            ClassId = int.Parse(DropDownList1.SelectedValue)
        };
        //之后再验证数据

        CourseServiceImpl courseServiceImpl = new CourseServiceImpl();
        int id = courseServiceImpl.Create(course);

        Response.Redirect("IntroductionInDetail.aspx?id=" + id);

    }
}