using System;
using BusinessLogicLayer.Impl;

namespace Teacher
{
    public partial class TeacherDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["tid"])) return;
            //tid不为空，根据tid获取该老师还没结束的课程
            var courses = new CourseServiceImpl()
                .GetByTeacherNotEndYet(new Models.Teacher(){TeacherId = int.Parse(Request.QueryString["tid"]) });
            //绑定数据
            RepeaterCourseList.DataSource = courses;
            RepeaterCourseList.DataBind();
        }
    }
}