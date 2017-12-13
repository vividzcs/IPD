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
        public Department[] GetAllDepartments()
        {
            return _departmentDal.GetAllDepartments();
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