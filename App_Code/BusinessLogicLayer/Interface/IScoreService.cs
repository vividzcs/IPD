using System.Collections.Generic;
using Models;
using DataAccessLayer.Impl;

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
        /// <summary>
        /// 获得当前学生某项课程成绩
        /// </summary>
        /// <param name="CourseId">课程Id</param>
        /// /// <param name="StudentId">学生Id</param>
        /// <returns>Scored</returns>
        Score GetByCourseIdAndStudentId(int CourseId, int StudentId);
        /**
     * @param whichStudent 
     * @return
     */
        IEnumerable<Score> Get(Student whichStudent);

    }
}