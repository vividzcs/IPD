using System.Collections.Generic;
using Models;

/**
 * 
 */
namespace BusinessLogicLayer.Interface
{
    public interface ICoursewareService : IBusinessLogicLayerBase {

        /**
     * @param whichCourse 
     * @return
     */
        IEnumerable<CourseAttachment> Get(Course whichCourse);

    }
}