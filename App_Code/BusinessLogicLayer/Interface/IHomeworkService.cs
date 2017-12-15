using System.Collections.Generic;
using Models;

/**
 * 
 */
namespace BusinessLogicLayer.Interface
{
    public interface IHomeworkService : IBusinessLogicLayerBase {

        /**
     * @param whichCourse 
     * @return
     */
        IEnumerable<CourseHomework> Get(Course whichCourse);

        /**
     * @param whichCourse 
     * @param whichStudent 
     * @param homework 
     * @return
     */
        int Submit(CourseHomework whichCourseHomework, Student whichStudent, Homework homework);

        Homework Get(Student student, CourseHomework sh);

    }
}