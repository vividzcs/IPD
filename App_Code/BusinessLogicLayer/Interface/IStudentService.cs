using Models;

/**
 * 
 */
namespace BusinessLogicLayer.Interface
{
    public interface IStudentService : IBusinessLogicLayerBase {


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="student">要登录的学生对象</param>
        /// <returns>全副武装（数据填满）的学生对象</returns>
        Student Login(Student student);

        /// <summary>
        /// 修改学生密码
        /// </summary>
        /// <param name="student">要修改的学生，改后的密码已经填充好</param>
        /// <returns>1成功 0失败</returns>
        int ModifyPassword(Student student);

    }
}