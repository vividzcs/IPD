using System.Collections.Generic;
using Models;

/**
 * 
 */
namespace BusinessLogicLayer.Interface
{
    public interface IExperimentService : IBusinessLogicLayerBase {

        /// <summary>
        /// ͨ���γ�id��ȡ�γ�ʵ�����
        /// </summary>
        /// <param name="whichCourse"></param>
        /// <returns></returns>
        IEnumerable<CourseExperiment> Get(Course whichCourse);

        int Submit(Course whichCourse, Student whichStudent, Experiment exp);

        /// <summary>
        /// ��ѧ����id���Ϳγ�ʵ�飨id������ȡ�ô�ʵ�鱨�����
        /// </summary>
        /// <param name="student">ѧ��</param>
        /// <param name="ce">�γ�ʵ��</param>
        /// <returns>ʵ�鱨�����</returns>
        Experiment Get(Student student, CourseExperiment ce);

    }
}