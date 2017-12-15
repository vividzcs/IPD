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
        /// �γ̺Ͱ༶ֱ�ӹҹ���ѧ���Ͱ༶ֱ�ӹҹ���ͨ����ѧ��ת��Ϊ�༶�����ҿγ�
        /// </summary>
        /// <param name="student">�ĸ�ѧ���Ŀγ̣�</param>
        /// <param name="schoolYear">ѧ��</param>
        /// <param name="semester">ѧ��</param>
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