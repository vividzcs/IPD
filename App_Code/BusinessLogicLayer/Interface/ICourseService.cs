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
        /// ���Get���������ǲ�ѯ���ѧ����ѡ��Ŀγ̣�Ҳ���ǲ���ͨ�����ڰ༶ӳ���
        /// ������Ϊ��ʦ�����˸�ѧ���������ܿ������ſ�
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