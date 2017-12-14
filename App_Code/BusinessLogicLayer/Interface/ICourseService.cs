using System.Collections.Generic;
using Models;

/**
 * 
 */
namespace BusinessLogicLayer.Interface
{
    public interface ICourseService : IBusinessLogicLayerBase {

        /**
     * @param whichTeacher 
     * @return
     */
        IEnumerable<Course> GetByTeacher(Teacher whichTeacher);

        /**
     * @param whichTeacher 
     * @return
     */
        IEnumerable<Course> GetByTeacherNotEndYet(Teacher whichTeacher);

        /**
     * @param student 
     * @return
     */
        IEnumerable<Course> Get(Student student);

        IEnumerable<Course> Get(Student student, string schoolYear, string semester);

        /**
     * @param whichCourse 
     * @param whichStudent 
     * @return
     */
        Course Get(Course whichCourse, Student whichStudent);

    }
}