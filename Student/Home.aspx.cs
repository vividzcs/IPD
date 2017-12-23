using System;
using System.Diagnostics;
using BusinessLogicLayer.Impl;
using Models;
using System.Web.UI;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Utils;

namespace Student
{
    public partial class StudentHome : System.Web.UI.Page
    {
        protected readonly List<string[]> dep = new List<string[]>();
        private IEnumerable<Course> _thisStudentCourse;

        protected void Page_Load(object sender, EventArgs e)
        {
            //需要登录才能看到
            AuthHelper.LoginCheck(Session, Request, Response, Server);

            Models.Student student;
            if (Session["user"] is Models.Student s)
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
            var studentCourse = courses as Course[] ?? courses.ToArray();
            _thisStudentCourse = studentCourse;
            foreach (var course in studentCourse)
            {
                var thisCourseTeacherId = new CourseServiceImpl().GetTeacherIdByCourseId(course.CourseId);
                var thisTeacher = new TeacherServiceImpl().GetByTeacherId(thisCourseTeacherId);
                var thisTeacherDep = new DepartmentServiceImpl().GetByDepId(thisTeacher.DepartmentId);
                //得到当前学生的某个课程的成绩
                var thisStudentScore =
                    new ScoreServiceImpl().GetByCourseIdAndStudentId(course.CourseId, student.StudentId);
                string[] str1 =
                {
                    course.CourseId.ToString(), course.Name, thisStudentScore.Mark.ToString(),
                    thisTeacherDep.ChinesaeName
                };
                dep.Add(str1);
            }
        }
    }
}