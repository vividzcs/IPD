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
            //需要登录才能看到
            var session = Session["user"];
            if (session == null)
            {
                //没有登录转到登录界面
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
                //登录的不是学生，转到登录界面
                Session.Remove("user");
                Response.Redirect("~/Login.aspx");
                return;
            }

            //用学生对象的院系id去获取该院系的对象
            var departmentService = new DepartmentServiceImpl();
            var did = student.DepartmentId;
            var department = (Department) departmentService.GetById(did);

            //赋值：学号
            SpanStudentNumber.InnerText = student.StudentNumber;
            //赋值：学生姓名
            SpanName.InnerText = student.Name;
            //赋值：院系中文名
            SpanDepartment.InnerText = department.ChinesaeName;

            //利用学生的班级id获取该班对象
            var classService = new ClassServiceImpl();
            var cid = student.ClassId;
            var aClass = (Class) classService.GetById(cid);

            //赋值：班级名称
            SpanClass.InnerText = aClass.Name;

            //特定学期，学年，该生的课程数据绑定
            var courses = new CourseServiceImpl()
                .Get(student, SchoolYearSelector.Value, SemesterSelector.Value);
            RepeaterCourseAndScore.DataSource = courses;
            RepeaterCourseAndScore.DataBind();

        
        }

    }
}