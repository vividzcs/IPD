using System.Collections.Generic;
using Models;

/**
 * 
 */
namespace BusinessLogicLayer.Interface
{
    public interface IExperimentService : IBusinessLogicLayerBase {

        /// <summary>
        /// 通过课程id获取课程实验情况
        /// </summary>
        /// <param name="whichCourse"></param>
        /// <returns></returns>
        IEnumerable<CourseExperiment> Get(Course whichCourse);

        int Submit(Course whichCourse, Student whichStudent, Experiment exp);

    }
}