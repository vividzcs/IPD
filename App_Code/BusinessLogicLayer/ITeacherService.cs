using Models;

namespace BusinessLogicLayer
{
    /// <summary>
    /// ITeacherService 的摘要说明
    /// </summary>
    public interface ITeacherService
    {
        Teacher[] GetTeachers(int departmentId);

        Teacher[] GetTeachers(Department department);
    }
}