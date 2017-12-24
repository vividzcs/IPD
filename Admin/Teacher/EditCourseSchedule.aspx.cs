using BusinessLogicLayer.Impl;
using Models;
using System;
using System.Web.UI.WebControls;
using Utils;

public partial class Admin_Teacher_EditCourseSchedule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.LoginCheck(Session, Request, Response, Server);
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                int CourseId = int.Parse(Request.QueryString["id"]);
                CourseServiceImpl courseServiceImpl = new CourseServiceImpl();
                Course course = (Course)courseServiceImpl.GetById(CourseId);
                //绑定数据
                BeginDate.Value = course.BeginDate.ToString().Replace("/","-").Remove(course.BeginDate.ToString().IndexOf(" "));
                EndDate.Value = course.EndDate.ToString().Replace("/", "-").Remove(course.EndDate.ToString().IndexOf(" "));
                TheoryClassHour.Value = course.TheoryClassHour.ToString();
                ExperimentClassHour.Value = course.ExperimentClassHour.ToString();
            }
        }
    }

    protected void StepOver(object sender, EventArgs e)
    {
        int id = int.Parse(Request.QueryString["id"]);

        Response.Redirect("EditCourseWare.aspx?id=" + id);
    }

    protected void NextStep(object sender, EventArgs e)
    {
        try
        {
            int id = int.Parse(Request.QueryString["id"]);
            CourseServiceImpl courseServiceImpl = new CourseServiceImpl();
            Course course = (Course)courseServiceImpl.GetById(id);
            course.BeginDate = DateTime.Parse(BeginDate.Value);
            course.EndDate = DateTime.Parse(EndDate.Value);
            course.TheoryClassHour = int.Parse(TheoryClassHour.Value);
            course.ExperimentClassHour = int.Parse(ExperimentClassHour.Value);

            //之后再验证数据

            courseServiceImpl.Modify(course);

            Response.Redirect("EditCourseWare.aspx?id=" + id);
        }
        catch (Exception ex)
        {
            Label.Text = "填写有误";
        }

    }
}