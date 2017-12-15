using Models;

namespace DataAccessLayer.Interface
{
    /// <summary>
    /// ITeacherDal 的摘要说明
    /// </summary>
    public interface ITeacherDal
    {
        /// <summary>
        /// 通过院系id查找老师们
        /// </summary>
        /// <param name="did">那个院系的id</param>
        /// <returns>老师的数组</returns>
        Teacher[] SelectTeachersByDepartment(int did);

        /// <summary>
        /// 查找特定id的老师对象
        /// </summary>
        /// <param name="id">要查找的老师的id</param>
        /// <returns>那个老师The entity found, or null. </returns>
        Teacher SelectById(int id);
    }
}