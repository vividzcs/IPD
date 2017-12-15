﻿using System.Collections.Generic;
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
        /// 通过班级（ｉｄ）查找课程
        /// </summary>
        /// <param name="cClass">要查找的那个班级（ｉｄ有效）</param>
        /// <returns>该班级的所有课程</returns>
        IEnumerable<Course> Select(Class cClass);

        /// <summary>
        /// 查找某班级某学年某学期的所有课程
        /// </summary>
        /// <param name="cClass">班级（ｉｄ需有效）</param>
        /// <param name="schoolYear">学年（格式：２０１７－２０１８）</param>
        /// <param name="semester">学期（格式：１或２或３）</param>
        /// <returns>这个班级本学年本学期的所有课程</returns>
        IEnumerable<Course> Select(Class cClass, string schoolYear, string semester);

        /// <summary>
        /// 查找某教师开设的还没结束的所有课程
        /// </summary>
        /// <param name="teacher">哪个老师？（ｉｄ需有效）</param>
        /// <returns></returns>
        IEnumerable<Course> SelectNotEnded(Teacher teacher);
    }
}