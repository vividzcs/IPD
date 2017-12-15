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

        /**
     * @param student 
     * @return
     */
        IEnumerable<Course> Get(Student student);

        /// <summary>
        /// 课程和班级直接挂钩，学生和班级直接挂钩，通过将学生转化为班级，查找课程
        /// </summary>
        /// <param name="student">哪个学生的课程？</param>
        /// <param name="schoolYear">学年</param>
        /// <param name="semester">学期</param>
        /// <returns></returns>
        IEnumerable<Course> Get(Student student, string schoolYear, string semester);

        /**
     * @param whichCourse 
     * @param whichStudent 
     * @return
     */
        Course Get(Course whichCourse, Student whichStudent);

    }
}