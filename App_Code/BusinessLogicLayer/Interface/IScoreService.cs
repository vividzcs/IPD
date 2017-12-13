using System.Collections.Generic;
using Models;

/**
 * 
 */
namespace BusinessLogicLayer.Interface
{
    public interface IScoreService : IBusinessLogicLayerBase {

        /**
     * @param whichStudent 
     * @param whichCourse 
     * @return
     */
        Score Get(Student whichStudent, Course whichCourse);

        /**
     * @param whichStudent 
     * @return
     */
        IEnumerable<Score> Get(Student whichStudent);

    }
}