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

        public Experiment Select(int studentStudentId, int ceCourseExperimentId)
        {
            using (var context = new HaermsEntities())
            {
                var experiments = context.Experiment.Where(e =>
                    e.StudentId == studentStudentId && e.CourseExperimentId == ceCourseExperimentId);
                return experiments.FirstOrDefault();
            }
        }

        public int InsertExperiment(Experiment exp)
        {
            using (var context = new HaermsEntities())
            {
                context.Experiment.Add(exp);
                context.SaveChanges();
                return context.Experiment.First(h =>
                           h.CourseExperimentId == exp.CourseExperimentId && h.StudentId == exp.StudentId) != null ? 1 : 0;
            }
        }
    }
}