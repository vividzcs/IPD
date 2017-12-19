using System.Collections.Generic;
using BusinessLogicLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Impl;
using DataAccessLayer.Interface;
using Models;
using System;

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
            return _teacherDal.SelectAllTeacher();
        }

        public object GetById(int id)
        {
            return _teacherDal.SelectById(id);
        }

        public object Modify(object modifyWhich)
        {
            throw new System.NotImplementedException();
        }

        public int Create(object createWhich)
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
            return _teacherDal.SelectByJobNumberAndPassword(teacher);
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

        public int FreezeTeacher(int teacherId)
        {
          return _teacherDal.UpdateTeacherBanned(teacherId);
        }

        public int ResetTeacherPassword(Teacher teacher)
        {
            throw new NotImplementedException();
        }


        public int CreateTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public int ModifyTeacher(Teacher teacher)
        {
            return _teacherDal.ModifyTeacher(teacher);
        }

    }
}