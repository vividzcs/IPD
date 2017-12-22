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
        /// ��õ�ǰѧ��ĳ��γ̳ɼ�
        /// </summary>
        /// <param name="CourseId">�γ�Id</param>
        /// /// <param name="StudentId">ѧ��Id</param>
        /// <returns>Scored</returns>
        Score GetByCourseIdAndStudentId(int CourseId, int StudentId);
        /**
     * @param whichStudent 
     * @return
     */
        IEnumerable<Score> Get(Student whichStudent);

    }
}