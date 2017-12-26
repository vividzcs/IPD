using System.Collections.Generic;
using Models;

namespace DataAccessLayer.Interface
{
    /// <summary>
    /// ICourseDal 的摘要说明
    /// </summary>
    public interface ICourseDal
    {
        /// <summary>
        /// 通过课程ｉｄ查找课程
        /// </summary>
        /// <param name="id">要查找的课程的ｉｄ</param>
        /// <returns>要查找的那个课程。The entity found, or null. </returns>
        Course SelectById(int id);

        /// <summary>
        /// 查找某班级某学年某学期的所有课程
        /// </summary>
        /// <param name="cClass">班级（ｉｄ需有效）</param>
        /// <param name="schoolYear">学年（格式：２０１７－２０１８）</param>
        /// <param name="semester">学期（格式：１或２或３）</param>
        /// <returns>这个班级本学年本学期的所有课程</returns>

        IEnumerable<Course> SelectAllByTeacher(Teacher whichTeacher);

        /// <summary>
        /// 查找某教师开设的还没结束的所有课程
        /// </summary>
        /// <param name="teacher">哪个老师？（ｉｄ需有效）</param>
        /// <returns></returns>
        IEnumerable<Course> SelectNotEnded(Teacher teacher);

        /// <summary>
        /// 添加一门课程
        /// </summary>
        /// <param name="Course">已经把课程包装成对象</param>
        /// <returns>返回创建的课程的ID</returns>
        int GetTeacherIdByCourseId(int courseId);

        /// <summary>
        /// 添加一门课程
        /// </summary>
        /// <param name="CourseID">当前老师所教课程Id</param>
        /// <returns>返回老师的Id</returns>
        int Create(object course);

        object Update(Course course);
    }
}
