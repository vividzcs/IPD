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
    }
}