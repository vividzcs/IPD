using System.Collections.Generic;
using Models;

namespace DataAccessLayer.Interface
{
    /// <summary>
    /// IExperimentDal 的摘要说明
    /// </summary>
    public interface IExperimentDal
    {
        /// <summary>
        /// 按课程id查找课程实验
        /// </summary>
        /// <param name="course">封装了课程id的课程对象</param>
        /// <returns>课程实验对象的枚举器</returns>
        IEnumerable<CourseExperiment> SelectByCourse(Course course);

        Experiment Select(int studentStudentId, int ceCourseExperimentId);
        int InsertExperiment(Experiment exp);
        CourseExperiment SelectByCourseExperimentId(int id);

        /// <summary>
        /// 通过老师布置的实验ID获取交的作业集合
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<Experiment> SelectExpermentByCourseExpermentId(int id);
    }
}
