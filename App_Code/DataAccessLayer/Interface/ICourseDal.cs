using System.Collections.Generic;
using Models;

namespace DataAccessLayer.Interface
{
    /// <summary>
    /// ICourseDal 的摘要说明
    /// </summary>
    public interface ICourseDal
    {
        Course SelectById(int id);

        IEnumerable<Course> Select(Class cClass);

        IEnumerable<Course> Select(Class cClass, string schoolYear, string semester);

        IEnumerable<Course> SelectNotEnded(Teacher teacher);
    }
}