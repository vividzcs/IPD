using System.Collections.Generic;
using BusinessLogicLayer.Interface;
using DataAccessLayer.Interface;
using Models;

namespace BusinessLogicLayer.Impl
{
    /// <summary>
    /// CourseServiceImpl 的摘要说明
    /// </summary>
    public class CourseServiceImpl : ICourseService
    {
        private ICourseDal courseDal = new CourseDal();

        public IEnumerable<object> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public object GetById(int id)
        {
            return courseDal.SelectById(id);
        }

        public object Modify(object modifyWhich)
        {
            throw new System.NotImplementedException();
        }

        public object Create(object createWhich)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public IEnumerable<Course> Get(Student student)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Course> Get(Student student, string schoolYear, string semester)
        {
            return courseDal.Select(new Class() {ClassId = student.ClassId}, schoolYear, semester);
        }

        public Course Get(Course whichCourse, Student whichStudent)
        {
            throw new System.NotImplementedException();
        }
    }
}