using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer.Interface;
using Models;
using System.Collections;

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

        /* Name = CourseName.Value,
         Name = CourseName.Value,
            ShortIntroduction = ShortCourseIntro.Value,
            TeacherId = teacher.TeacherId,
            SchoolYear = SchoolYear.Text,
            Semester = Semester.Text,
            IntroImage  = Path,
            ClassI
         */
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
    
    //
    public IEnumerable<Course> SelectAllByTeacher(Teacher teacher)
    {
        using (var context = new HaermsEntities())
        {
            var queryable = context.Course.Where(c => c.TeacherId == teacher.TeacherId);
            return queryable.ToArray();
        }
    }
}
