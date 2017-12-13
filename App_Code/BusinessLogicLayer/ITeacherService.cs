using System.Collections.Generic;
using Models;

namespace BusinessLogicLayer
{
    /// <summary>
    /// ITeacherService 的摘要说明
    /// </summary>
    public interface ITeacherService
    {
        IEnumerable<Teacher> GetTeachers(int departmentId);

        Teacher[] GetTeachers(Department department);
    }
}