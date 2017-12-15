using System.Collections.Generic;
using Models;

/**
 * 
 */
namespace BusinessLogicLayer.Interface
{
    public interface IExperimentService : IBusinessLogicLayerBase {

        /// <summary>
        /// ͨ���γ�id��ȡ�γ�ʵ�����
        /// </summary>
        /// <param name="whichCourse"></param>
        /// <returns></returns>
        IEnumerable<CourseExperiment> Get(Course whichCourse);

        int Submit(Course whichCourse, Student whichStudent, Experiment exp);

    }
}