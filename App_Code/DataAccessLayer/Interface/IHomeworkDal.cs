using System.Collections.Generic;
using Models;

namespace DataAccessLayer.Interface
{
    /// <summary>
    /// IHomeworkDal 的摘要说明
    /// </summary>
    public interface IHomeworkDal
    {
        /// <summary>
        /// 按课程id查找课程作业
        /// </summary>
        /// <param name="course">封装了课程id的课程对象</param>
        /// <returns>课程作业对象的枚举器</returns>
        IEnumerable<CourseHomework> SelectByCourse(Course course);
    }
}