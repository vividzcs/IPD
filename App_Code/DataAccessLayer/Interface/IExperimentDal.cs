using System.Collections.Generic;
using Models;

namespace DataAccessLayer.Interface
{
    /// <summary>
    /// IExperimentDal 的摘要说明
    /// </summary>
    public interface IExperimentDal
    {
        IEnumerable<CourseExperiment> SelectByCourse(Course course);
    }
}