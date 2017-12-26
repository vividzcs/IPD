using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Interface;
using Models;

namespace DataAccessLayer.Impl
{
    /// <summary>
    /// CourseDal 的摘要说明
    /// </summary>
    public class CourseDal : ICourseDal
    {


        public Course SelectById(int id)
        {
            using (var context = new HaermsEntities())
            {
                return context.Course.Find(id);
            }
        }


        public IEnumerable<Course> SelectNotEnded(Teacher teacher)
        {
            using (var context = new HaermsEntities())
            {
                var queryable = context.Course.Where(c =>
                    c.TeacherId == teacher.TeacherId && DateTime.Compare(c.EndDate.Value, DateTime.Now) > 0);
                return queryable.ToArray();
            }
        }

        public int Create(object course)
        {
            using (var context = new HaermsEntities())
            {
                Course c = context.Course.Add((Course) course);
                context.SaveChanges();
                return c.CourseId;
            }
        }

        public object Update(Course course)
        {

        
            using (var context = new HaermsEntities())
            {
                var c = context.Course.Where(t=>t.CourseId == course.CourseId).ToArray().First();
                c.Name = course.Name;
                c.ShortIntroduction = course.ShortIntroduction;
                c.TeacherId = course.TeacherId;
                c.SchoolYear = course.SchoolYear;
                c.Semester = course.Semester;
                c.IntroImage = course.IntroImage;
                c.ClassId = course.ClassId;
                c.BeginDate = course.BeginDate;
                c.EndDate = course.EndDate;
                c.Description = course.Description;
                c.TheoryClassHour = course.TheoryClassHour;
                c.ExperimentClassHour = course.ExperimentClassHour;
                context.SaveChanges();
            
            
                return course;
            }
        }
    
    
        public IEnumerable<Course> SelectAllByTeacher(Teacher teacher)
        {
            using (var context = new HaermsEntities())
            {
                var queryable = context.Course.Where(c => c.TeacherId == teacher.TeacherId);
                return queryable.ToArray();
            }
        }
        public int GetTeacherIdByCourseId(int courseId)
        {
            using (var context = new HaermsEntities())
            {
                var queryable = (Course)context.Course.Where(c => c.CourseId == courseId).First();
                return queryable.TeacherId;
            }
        }
    }
}
