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

    public IEnumerable<Course> Select(Class cClass, string schoolYear, string semester)
    {
        using (var context = new HaermsEntities())
        {
            var queryable = context.Course.Where(c => c.ClassId == cClass.ClassId && c.SchoolYear == schoolYear && c.Semester == semester);
            return queryable.ToList();
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
}