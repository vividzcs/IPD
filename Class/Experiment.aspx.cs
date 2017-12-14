using System;
using BusinessLogicLayer.Impl;
using Models;

namespace Class
{
    public partial class Experiment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //需要登录和cid才能访问到的页面
            var session = Session["user"];
            var cidString = Request.QueryString["cid"];
            if (session == null || cidString.Length == 0)
            {
                Response.Redirect("~/Login.aspx?pre=" + Server.UrlEncode(Request.Url.AbsoluteUri));
                return;
            }

            var experiments = new ExperimentServiceImpl()
                .Get(new Course(){CourseId = int.Parse(cidString)});
            RepeaterCourseExperiments.DataSource = experiments;
            RepeaterCourseExperiments.DataBind();
        }
    }
}