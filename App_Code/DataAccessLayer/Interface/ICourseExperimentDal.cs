using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer.Interface
{
    /// <summary>
    /// ICourseExperimentDal 的摘要说明
    /// </summary>
    public interface ICourseExperimentDal
    {
        int InsertCourseExperiment(CourseExperiment courseExperiment);
    }
}