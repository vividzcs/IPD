using System.Collections.Generic;
using Models;

/**
 * 
 */
namespace BusinessLogicLayer.Interface
{
    public interface IExperimentService : IBusinessLogicLayerBase {

        /**
     * @param whichCourse 
     * @return
     */
        IEnumerable<CourseExperiment> Get(Course whichCourse);

        /**
     * @param whichCourse 
     * @param whichStudent 
     * @param exp 
     * @return
     */
        int Submit(Course whichCourse, Student whichStudent, Experiment exp);

    }
}