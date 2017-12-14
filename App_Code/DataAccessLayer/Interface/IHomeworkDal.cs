using System.Collections.Generic;
using Models;

namespace DataAccessLayer.Interface
{
    /// <summary>
    /// IHomeworkDal 的摘要说明
    /// </summary>
    public interface IHomeworkDal
    {
        IEnumerable<CourseHomework> SelectByCourse(Course course);
    }
}