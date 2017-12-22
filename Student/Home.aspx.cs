using System;
using System.Diagnostics;
using BusinessLogicLayer.Impl;
using Models;
using System.Web.UI;
using System.Collections.Generic;
using System.Collections;

namespace Student
{
    public partial class StudentHome : System.Web.UI.Page
    {

        public List<string[]> dep = new List<string[]>();
        public IEnumerable<Course> thisStudentCourse;
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
            //利用课程号查老师获得老师所属院系
            //赋值：班级名称
            SpanClass.InnerText = aClass.Name;

            //该生的课程数据绑定
            var courses = new CourseServiceImpl().Get(student);
            thisStudentCourse = courses;
            foreach (var course in courses) {
                var thisCourseTeacherId = new CourseServiceImpl().GetTeacherIdByCourseId(course.CourseId);
                var thisTeacher = new TeacherServiceImpl().GetByTeacherId(thisCourseTeacherId);
                var thisTeacherDep = new DepartmentServiceImpl().GetByDepId(thisTeacher.DepartmentId);
                //得到当前学生的某个课程的成绩
                var thisStudentScore = new ScoreServiceImpl().GetByCourseIdAndStudentId(course.CourseId,student.StudentId);
                String[] str1 = { course.CourseId.ToString(),course.Name ,thisStudentScore.Mark.ToString(),thisTeacherDep.ChinesaeName };
                dep.Add(str1);
                

            }
            //RepeaterCourseAndScore.DataSource = new { courses, dep};
            //RepeaterCourseAndScore.DataBind();

        
        }      
    }
}