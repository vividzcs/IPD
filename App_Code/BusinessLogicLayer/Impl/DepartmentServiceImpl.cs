using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Impl;
using Models;

namespace BusinessLogicLayer.Impl
{
    /// <inheritdoc />
    /// <summary>
    /// DepartmentServiceImpl 的摘要说明
    /// </summary>
    public class DepartmentServiceImpl : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal = new DepartmentDal();
        public IEnumerable<Department> GetAllDepartments()
        {
            return _departmentDal.SelectAllDepartments();
        }

        public Department GetDepartment(int id)
        {
            return _departmentDal.SelectDepartmentById(id);
        }

        public Department GetDepartment(Department department)
        {
            throw new System.NotImplementedException();
        }
    }
}