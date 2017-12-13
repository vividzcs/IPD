using Models;

namespace DataAccessLayer
{
    /// <summary>
    /// ITeacherDal 的摘要说明
    /// </summary>
    public interface ITeacherDal
    {
        Teacher[] SelectTeachersByDepartment(int did);
    }
}