using System;
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

        public Homework SelectByStudentAndCourseHomework(Student student, CourseHomework sh)
        {
            using (var context = new HaermsEntities())
            {
                var queryable = context.Homework.Where(h =>
                    h.CourseHomeworkId == sh.CourseHomeworkId && h.StudentId == student.StudentId);
                return queryable.FirstOrDefault();
            }
        }

        public int InsertHomework(Homework homework)
        {
            using (var context = new HaermsEntities())
            {
                context.Homework.Add(homework);
                context.SaveChanges();
                return context.Homework.First(h =>
                           h.CourseHomeworkId == homework.CourseHomeworkId && h.StudentId == homework.StudentId) != null ? 1 : 0;
            }
        }
        
        public CourseHomework SelectByCourseHomeworkId(int id)
        {
            using (var context = new HaermsEntities())
            {
                return context.CourseHomework.Find(id);
            }
        }

        public IEnumerable<Homework> SelectHomeworkByCourseHomeworkId(int id)
        {
            using (var context = new HaermsEntities())
            {
                var querySet = context.Homework.Where(h => h.CourseHomeworkId == id);
                return querySet.ToArray();
            }
        }
    }
}
