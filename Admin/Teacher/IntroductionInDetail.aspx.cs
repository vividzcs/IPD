using BusinessLogicLayer.Impl;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_IntroductionInDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CourseId.Value = Request.QueryString["id"] ?? "0";
    }

    protected void StepOver(object sender, EventArgs e)
    {
        int id = int.Parse(CourseId.Value);

        Response.Redirect("CourseSchedule.aspx?id=" + id);

    }

    protected void NextStep(object sender, EventArgs e)
    {
        Course course = new Course()
        {
            CourseId = int.Parse(CourseId.Value),
            Description = Description.Value
        };
        //之后再验证数据
        int id = int.Parse(CourseId.Value);

        CourseServiceImpl courseServiceImpl = new CourseServiceImpl();
        courseServiceImpl.Modify(course); 

        Response.Redirect("CourseSchedule.aspx?id=" + id);
    }
}