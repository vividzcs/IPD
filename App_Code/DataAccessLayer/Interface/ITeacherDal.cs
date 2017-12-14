using Models;

namespace DataAccessLayer.Interface
{
    /// <summary>
    /// ITeacherDal 的摘要说明
    /// </summary>
    public interface ITeacherDal
    {
        Teacher[] SelectTeachersByDepartment(int did);

        Teacher SelectById(int id);
    }
}