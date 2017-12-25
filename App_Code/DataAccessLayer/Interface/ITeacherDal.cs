using Models;
using System.Collections.Generic;

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

        /// <summary>
        /// 根据JobNumber和Password查找的老师对象
        /// </summary>
        /// <param name="teacher">Controller传过来的老师对象</param>
        /// <returns>那个老师The entity found, or null. </returns>
        Teacher SelectByJobNumberAndPassword(Teacher teacher);


        IEnumerable<Teacher> SelectAllTeacher();


        int UpdateTeacherBanned(int teacherId);


        int ModifyTeacher(Teacher teacher);

        int ResetTeacherPassword(int teacherId);

        int InsertTeacher(Teacher teacher);

        /// <summary>
        /// 如果老师已经被禁了，就不能登录
        /// </summary>
        /// <param name="teacher">老师对象，要包含id</param>
        /// <returns>如果没找到该老师就返回true，否则该返回啥就返回啥</returns>
        bool IsBanned(Teacher teacher);

        int UpdateTeacherPassword(Teacher teacher);
    }
}