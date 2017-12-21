using Models;

namespace DataAccessLayer.Interface
{
    /// <summary>
    /// IStudentSal 的摘要说明
    /// </summary>
    public interface IStudentDal
    {
        /// <summary>
        /// 学生登录调用的方法
        /// </summary>
        /// <param name="student">学生对象</param>
        /// <returns>登录上的学生对象，没登录上就返回空</returns>
        Student SelectStudentByStudentNumberAndPassword(Student student);

        /// <summary>
        /// 修改学生密码的方法
        /// </summary>
        /// <param name="student">学生对象</param>
        /// <returns>1成功 0失败</returns>
        int UpdateStudent(Student student);
        
        Student SelectStudentByStudentNumber(Student student);
    }
}
