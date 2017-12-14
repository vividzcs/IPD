using System;
using System.Diagnostics;
using BusinessLogicLayer.Impl;
using Models;

namespace Student
{
    public partial class StudentHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var session = Session["user"];
            if (session == null)
            {
                Response.Redirect("~/Login.aspx?pre="+Server.UrlEncode(Request.Url.AbsoluteUri));
                return;
            }
            var student = new Models.Student();
            if (session is Models.Student s)
            {
                student = s;
            }
            else
            {
                Response.Redirect("~/Login.aspx");
                return;
            }
            var departmentService = new DepartmentServiceImpl();
            var did = student.DepartmentId;
            var department = (Department) departmentService.GetById(did);

            SpanStudentNumber.InnerText = student.StudentNumber;
            SpanName.InnerText = student.Name;
            SpanDepartment.InnerText = department.ChinesaeName;

            var classService = new ClassServiceImpl();
            var cid = student.ClassId;
            var aClass = (Class) classService.GetById(cid);

            SpanClass.InnerText = aClass.Name;


            var courses = new CourseServiceImpl()
                .Get(student, SchoolYearSelector.Value, SemesterSelector.Value);
            RepeaterCourseAndScore.DataSource = courses;
            RepeaterCourseAndScore.DataBind();

        
        }

    }
}