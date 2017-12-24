using BusinessLogicLayer.Impl;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils;

public partial class Admin_Teacher_EditIntroDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.AuthCheck(Session, Request, Response, Server);
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                int CourseId = int.Parse(Request.QueryString["id"]);
                CourseServiceImpl courseServiceImpl = new CourseServiceImpl();
                Course course = (Course)courseServiceImpl.GetById(CourseId);
                //绑定数据
                Description.Value = course.Description;
            }
        }
    }

    protected void StepOver(object sender, EventArgs e)
    {
        int id = int.Parse(Request.QueryString["id"]);

        Response.Redirect("EditCourseSchedule.aspx?id=" + id);

    }

    protected void NextStep(object sender, EventArgs e)
    {
        try
        {
            int id = int.Parse(Request.QueryString["id"]);
            CourseServiceImpl courseServiceImpl = new CourseServiceImpl();
            Course course = (Course)courseServiceImpl.GetById(id);
            course.Description = Description.Value.Replace("\n", "<br/>");

            //之后再验证数据
            courseServiceImpl.Modify(course);

            Response.Redirect("EditCourseSchedule.aspx?id=" + id);
        }
        catch (Exception ex)
        {
            Label.Text = "填写错误";
        }
    }
}