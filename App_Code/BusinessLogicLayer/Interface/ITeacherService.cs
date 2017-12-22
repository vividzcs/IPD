using System.Collections.Generic;
using Models;

/**
 * 
 */
namespace BusinessLogicLayer.Interface
{
    public interface ITeacherService : IBusinessLogicLayerBase
    {
        /**
     * @param whichDepartment 
     * @return
     */
        IEnumerable<Teacher> GetByDepartment(Department whichDepartment);




        /**
     * @param departmentId 
     * @return
     */
        IEnumerable<Teacher> GetByDepartment(int departmentId);

        /**
     * @param teacher 
     * @return
     */
        Teacher Login(Teacher teacher);

        /**
     * @param course 
     * @return
     */
        int CreateCourse(Course course);

        /**
     * @param course 
     * @param students Student[] 
     * @return
     */
        int AddStudentList(Course course, Student[] students);

        /**
     * @param course 
     * @return
     */
        int CopyFormerCourse(Course course);

        /**
     * @param student 
     * @param ch 
     * @return
     */
        Homework DownloadHomework(Student student, CourseHomework ch);

        /**
     * @param student 
     * @param ce 
     * @return
     */
        Experiment DownloadExperiment(Student student, CourseExperiment ce);

        /**
     * @param student 
     * @param courseExperiment 
     * @return
     */
        Experiment Evaluate(Student student, CourseExperiment courseExperiment);

        /**
     * @param teacher 
     * @return
     */
        int CreateTeacher(Teacher teacher);

        /**
     * @param teacher 
     * @return
     */
        int ModifyTeacher(Teacher teacher);


        /**
    * @param teacher 
    * @return
    */
        int FreezeTeacher(int teacherId);

        /**
     * @param teacher 
     * @return
     */
        int ResetTeacherPassword(int teacherId);
    }
}