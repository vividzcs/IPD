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
        Course course = new Course()
        {
            CourseId = int.Parse(CourseId.Value),
            BeginDate = DateTime.Parse(BeginDate.Value),
            EndDate = DateTime.Parse(EndDate.Value),
            TheoryClassHour = int.Parse(TheoryClassHour.Value),
            ExperimentClassHour = int.Parse(ExperimentClassHour.Value)
        };

        //之后再验证数据
        int id = int.Parse(CourseId.Value);

        CourseServiceImpl courseServiceImpl = new CourseServiceImpl();
        courseServiceImpl.Modify(course);

        Response.Redirect("UploadCourseware.aspx?id=" + id);
    }
}