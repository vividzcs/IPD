using System.Linq;
using Models;

namespace DataAccessLayer.Impl
{
    /// <summary>
    /// DepartmentDal 的摘要说明
    /// </summary>
    public class DepartmentDal : IDepartmentDal
    {
 
        public Department[] GetAllDepartments()
        {
            using (var context = new HaermsEntities())
            {
                var departments = context.Department.ToArray();
                return departments;
            }

        }

        public Department SelectDepartmentById(int id)
        {
            using (var context = new HaermsEntities())
            {
                var department = context.Department.Find(id);
                return department;
            }
        }
    }
}