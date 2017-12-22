using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer.Interface;
using Models;

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

    public IEnumerable<Course> Select(Class cClass)
    {
        using (var context = new HaermsEntities())
        {
            var queryable = context.Course.Where(c => c.ClassId == cClass.ClassId);
            return queryable.ToList();
        }
    }

    //public IEnumerable<Course> Select(Class cClass)
    //{
    //    using (var context = new HaermsEntities())
    //    {
    //        var queryable = context.Course.Where(c => c.ClassId == cClass.ClassId);
    //        return queryable.ToList();
    //    }
    //}

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
            var c = context.Course.Where(t=>t.CourseId == course.CourseId).ToArray();
            var cl = c.First();
            cl.Description = course.Description == null ? null : course.Description;
            cl.BeginDate = course.BeginDate == null ? null : course.BeginDate;
            cl.EndDate = course.EndDate == null ? null : course.EndDate;
            cl.ExperimentClassHour = course.ExperimentClassHour == null ? null : course.ExperimentClassHour;
            cl.TheoryClassHour = course.TheoryClassHour == null ? null : course.TheoryClassHour;
            context.SaveChanges();
            return cl;
        }
    }
    
    //
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
