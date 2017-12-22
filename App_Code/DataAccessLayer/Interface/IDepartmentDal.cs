using System.Collections.Generic;
using Models;

namespace DataAccessLayer.Interface
{
    /// <summary>
    /// IDepartmentDal 的摘要说明
    /// </summary>
    public interface IDepartmentDal
    {
        /// <summary>
        /// 查找所有的院系
        /// </summary>
        /// <returns>所有院系的枚举器</returns>
        IEnumerable<Department> SelectAllDepartments();

        /// <summary>
        /// 通过id获取院系
        /// </summary>
        /// <param name="id">那个院系的id</param>
        /// <returns>那个院系的对象The entity found, or null. </returns>
        Department SelectDepartmentById(int id);

        Department SelectDepartmentByName(string name);
        int UpdateDepartment(Department department);
        int insertDepartment(Department department);
    }
}