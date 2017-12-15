using System.Collections.Generic;
using Models;

/**
 * 
 */
namespace BusinessLogicLayer.Interface
{
    public interface IExperimentService : IBusinessLogicLayerBase {

        /// <summary>
        /// 通过课程id获取课程实验情况
        /// </summary>
        /// <param name="whichCourse"></param>
        /// <returns></returns>
        IEnumerable<CourseExperiment> Get(Course whichCourse);

        int Submit(Course whichCourse, Student whichStudent, Experiment exp);

        /// <summary>
        /// 由学生（id）和课程实验（id）来获取该次实验报告对象
        /// </summary>
        /// <param name="student">学生</param>
        /// <param name="ce">课程实验</param>
        /// <returns>实验报告对象</returns>
        Experiment Get(Student student, CourseExperiment ce);

    }
}