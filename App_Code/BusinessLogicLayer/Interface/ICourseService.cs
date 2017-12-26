using System.Collections.Generic;
using Models;

/**
 * 
 */
namespace BusinessLogicLayer.Interface
{
    /// <inheritdoc />
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


        /// <summary>
        /// 这个Get方法作用是查询这个学生被选择的课程，也就是不是通过所在班级映射的
        /// 而是因为老师倒入了该学生，他才能看见这门课
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        IEnumerable<Course> Get(Student student);

        /**
     * @param whichCourse 
     * @param whichStudent 
     * @return
     */
        Course Get(Course whichCourse, Student whichStudent);

    }

   
}