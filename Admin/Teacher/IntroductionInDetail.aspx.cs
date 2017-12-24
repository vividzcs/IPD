using BusinessLogicLayer.Impl;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils;

public partial class Admin_IntroductionInDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.LoginCheck(Session, Request, Response, Server);
        AuthHelper.TeacherOnlyPage(Session, Request, Response, Server);

        CourseId.Value = Request.QueryString["id"] ?? "0";
    }

    protected void StepOver(object sender, EventArgs e)
    {
        int id = int.Parse(CourseId.Value);

        Response.Redirect("CourseSchedule.aspx?id=" + id);

    }

    protected void NextStep(object sender, EventArgs e)
    {
        try
        {
            int id = int.Parse(CourseId.Value);
            CourseServiceImpl courseServiceImpl = new CourseServiceImpl();
            Course course = (Course)courseServiceImpl.GetById(id);
            course.Description = Description.Value.Replace("\n","<br/>");

            //之后再验证数据
            courseServiceImpl.Modify(course);

            Response.Redirect("CourseSchedule.aspx?id=" + id);
        }catch(Exception ex)
        {
            Label.Text = "填写错误";
        }
    }
}