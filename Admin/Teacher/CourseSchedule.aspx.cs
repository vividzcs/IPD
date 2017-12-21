using BusinessLogicLayer.Impl;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CourseSchedule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CourseId.Value = Request.QueryString["id"] ?? "0";

        
    }

    protected void StepOver(object sender, EventArgs e)
    {
        int id = int.Parse(CourseId.Value);

        Response.Redirect("UploadCourseware.aspx?id=" + id);
    }

    protected void NextStep(object sender, EventArgs e)
    {
        try
        {
            int id = int.Parse(CourseId.Value);
            CourseServiceImpl courseServiceImpl = new CourseServiceImpl();
            Course course = (Course)courseServiceImpl.GetById(id);
            course.CourseId = int.Parse(CourseId.Value);
            course.BeginDate = DateTime.Parse(BeginDate.Value);
            course.EndDate = DateTime.Parse(EndDate.Value);
            course.TheoryClassHour = int.Parse(TheoryClassHour.Value);
            course.ExperimentClassHour = int.Parse(ExperimentClassHour.Value);

            //之后再验证数据

            courseServiceImpl.Modify(course);

            Response.Redirect("UploadCourseware.aspx?id=" + id);
        }catch(Exception ex)
        {
            Label.Text = "填写有误";
        }
        
    }
}