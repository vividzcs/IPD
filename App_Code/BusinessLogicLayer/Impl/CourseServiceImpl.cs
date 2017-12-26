using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.Interface;
using DataAccessLayer.Impl;
using DataAccessLayer.Interface;
using Models;

namespace BusinessLogicLayer.Impl
{
    /// <inheritdoc />
    /// <summary>
    /// CourseServiceImpl 的摘要说明
    /// </summary>
    public class CourseServiceImpl : ICourseService
    {
        private readonly ICourseDal _courseDal = new CourseDal();

        public IEnumerable<object> GetAll()
        {
            throw new System.NotImplementedException();
        }
        public object GetById(int id)
        {
            return _courseDal.SelectById(id);
        }

        public object Modify(object course)
        {
            return _courseDal.Update((Course)course);
        }

        public int Create(object course)
        {
            return _courseDal.Create(course);
        }

        public int Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public int Delete(object deleteWhich)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Course> GetByTeacher(Teacher whichTeacher)
        {
            return _courseDal.SelectAllByTeacher(whichTeacher);
        }
        public int GetTeacherIdByCourseId(int courseId)
        {
            return _courseDal.GetTeacherIdByCourseId(courseId);
        }

        public IEnumerable<Course> GetByTeacherNotEndYet(Teacher whichTeacher)
        {
            return _courseDal.SelectNotEnded(whichTeacher);
        }

        public Course GetByCourseId(int id)
        {
            return _courseDal.SelectById(id);
        }

        public IEnumerable<Course> Get(Student student)
        {
            var courseSelections = new CourseSelectionServiceImpl().GetCoursesByStudentId(student);
            var courses = new List<Course>(15);
            //相等于使用foreach循环，把查出来的课程对象放进courses这个List里面
            courses.AddRange(courseSelections.Select(courseSelection => GetByCourseId(courseSelection.CourseId)));
            return courses;
        }

        public Course Get(Course whichCourse, Student whichStudent)
        {
            throw new System.NotImplementedException();
        }


    }
}
