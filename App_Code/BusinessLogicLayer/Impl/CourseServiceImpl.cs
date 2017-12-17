using System.Collections.Generic;
using BusinessLogicLayer.Interface;
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
            throw new System.NotImplementedException();
        }

        public IEnumerable<Course> GetByTeacherNotEndYet(Teacher whichTeacher)
        {
            return _courseDal.SelectNotEnded(whichTeacher);
        }

        public IEnumerable<Course> Get(Student student)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Course> Get(Student student, string schoolYear, string semester)
        {
            return _courseDal.Select(new Class() {ClassId = student.ClassId}, schoolYear, semester);
        }

        public Course Get(Course whichCourse, Student whichStudent)
        {
            throw new System.NotImplementedException();
        }
    }
}