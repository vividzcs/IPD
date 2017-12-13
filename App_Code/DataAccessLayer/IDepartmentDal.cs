using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    /// <summary>
    /// IDepartmentDal 的摘要说明
    /// </summary>
    public interface IDepartmentDal
    {
        IEnumerable<Department> SelectAllDepartments();
        Department SelectDepartmentById(int id);
    }
}