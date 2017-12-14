using System;
using System.Diagnostics;
using System.Linq;
using BusinessLogicLayer.Impl;
using Models;

namespace Class
{
    public partial class Homework : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //需要登录和cid才能访问到的页面
            var session = Session["user"];
            var cidString = Request.QueryString["cid"];
            if (session == null || cidString.Length == 0)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            var homeworks = new HomeworkServiceImpl()
                .Get(new Course() { CourseId = int.Parse(cidString) });
            RepeaterCourseHomework.DataSource = homeworks;
            RepeaterCourseHomework.DataBind();

        }
    }
}