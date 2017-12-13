using System.Collections.Generic;
using BusinessLogicLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Impl;
using DataAccessLayer.Interface;
using Models;

namespace BusinessLogicLayer.Impl
{
    /// <summary>
    /// TeacherServiceImpl 的摘要说明
    /// </summary>
    public class TeacherServiceImpl : ITeacherService
    {
        private readonly ITeacherDal _teacherDal = new TeacherDal();
        public IEnumerable<Teacher> GetTeachers(int departmentId)
        {
            return _teacherDal.SelectTeachersByDepartment(departmentId);
        }

        public Teacher[] GetTeachers(Department department)
        {
            return _teacherDal.SelectTeachersByDepartment(department.DepartmentId);
        }

        public IEnumerable<object> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public object GetById(int id)
        {
            throw new System.NotImplementedException();
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

        public IEnumerable<Teacher> GetByDepartment(Department whichDepartment)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Teacher> GetByDepartment(int departmentId)
        {
            throw new System.NotImplementedException();
        }

        public Teacher Login(Teacher teacher)
        {
            throw new System.NotImplementedException();
        }

        public int CreateCourse(Course course)
        {
            throw new System.NotImplementedException();
        }

        public int AddStudentList(Course course, Student[] students)
        {
            throw new System.NotImplementedException();
        }

        public int CopyFormerCourse(Course course)
        {
            throw new System.NotImplementedException();
        }

        public Homework DownloadHomework(Student student, CourseHomework ch)
        {
            throw new System.NotImplementedException();
        }

        public Experiment DownloadExperiment(Student student, CourseExperiment ce)
        {
            throw new System.NotImplementedException();
        }

        public Experiment Evaluate(Student student, CourseExperiment courseExperiment)
        {
            throw new System.NotImplementedException();
        }
    }
}