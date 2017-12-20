using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace DataAccessLayer.Impl
{
    /// <summary>
    /// CourseExperimentDal 的摘要说明
    /// </summary>
    public class CourseExperimentDal : ICourseExperimentDal
    {
        public int InsertCourseExperiment(CourseExperiment courseExperiment)
        {
            using (var context = new HaermsEntities())
            {
                CourseExperiment c = context.CourseExperiment.Add(courseExperiment);
                context.SaveChanges();
                return c.CourseExperimentId;
            }
        }
    }
}
