using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

/// <summary>
/// CourseHomeworkDal 的摘要说明
/// </summary>
public class CourseHomeworkDal : ICourseHomeworkDal
{
    public int InsertCourseHomework(CourseHomework courseHomework)
    {
        using (var context = new HaermsEntities())
        {
            CourseHomework c = context.CourseHomework.Add(courseHomework);
            context.SaveChanges();
            return c.CourseHomeworkId;
        }
    }
}