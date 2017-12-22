using System.Collections.Generic;
using Models;

/**
 *
 */
namespace BusinessLogicLayer.Interface
{
    public interface IExperimentService : IBusinessLogicLayerBase {

        /// <summary>
        /// ͨ通过课程id获取课程实验情况
        /// </summary>
        /// <param name="whichCourse"></param>
        /// <returns></returns>
        IEnumerable<CourseExperiment> Get(Course whichCourse);

        int Submit(CourseExperiment courseExperiment, Student whichStudent, Experiment exp);

        /// <summary>
        /// 通过课程id获取课程实验情况
        /// </summary>
        /// <param name="student">学生</param>
        /// <param name="ce">课程实验</param>
        /// <returns>实验报告对象</returns>
        Experiment Get(Student student, CourseExperiment ce);

        CourseExperiment GetCourseExperimentById(int id);

        IEnumerable<Experiment> GetExpermentByCourseExperimentId(int id);

    }
}
