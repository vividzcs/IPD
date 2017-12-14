using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Interface;
using Models;

namespace DataAccessLayer.Impl
{
    /// <summary>
    /// ExperimentDal 的摘要说明
    /// </summary>
    public class ExperimentDal : IExperimentDal
    {
    

        public IEnumerable<CourseExperiment> SelectByCourse(Course course)
        {
            using (var context = new HaermsEntities())
            {
                var queryable = context.CourseExperiment.Where(ce => ce.CourseId == course.CourseId);
                return queryable.ToArray();
            }
        }
    }
}