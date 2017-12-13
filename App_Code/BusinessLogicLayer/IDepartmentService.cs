using Models;

namespace BusinessLogicLayer
{
    /// <summary>
    /// IDepartmentService 是一个用来定义院系类的业务逻辑的接口
    /// </summary>
    public interface IDepartmentService
    {
        /// <summary>
        /// 此方法得到所有的院系
        /// </summary>
        /// <returns>所有的院系组成的数组</returns>
        Department[] GetAllDepartments();

        Department GetDepartment(int id);
        Department GetDepartment(Department department);
        
    }
}