using System;
using BusinessLogicLayer.Impl;

namespace Teacher
{
    public partial class TeacherDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["tid"]))
            {
                var courses = new CourseServiceImpl()
                    .GetByTeacherNotEndYet(new Models.Teacher(){TeacherId = int.Parse(Request.QueryString["tid"]) });
                RepeaterCourseList.DataSource = courses;
                RepeaterCourseList.DataBind();
            }
        
        }
    }
}