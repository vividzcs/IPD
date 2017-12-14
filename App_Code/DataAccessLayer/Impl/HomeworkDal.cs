using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Interface;
using Models;

namespace DataAccessLayer.Impl
{
    /// <summary>
    /// HomeworkDal 的摘要说明
    /// </summary>
    public class HomeworkDal : IHomeworkDal
    {
   

        public IEnumerable<CourseHomework> SelectByCourse(Course course)
        {
            using (var context = new HaermsEntities())
            {
                var queryable = context.CourseHomework.Where(ch => ch.CourseId == course.CourseId);
                return queryable.ToArray();
            }
        }
    }
}