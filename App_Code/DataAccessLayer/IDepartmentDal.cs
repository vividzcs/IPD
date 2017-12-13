using Models;

namespace DataAccessLayer
{
    /// <summary>
    /// IDepartmentDal 的摘要说明
    /// </summary>
    public interface IDepartmentDal
    {
        Department[] GetAllDepartments();
        Department SelectDepartmentById(int id);
    }
}