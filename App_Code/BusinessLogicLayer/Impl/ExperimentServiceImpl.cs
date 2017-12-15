using System.Collections.Generic;
using BusinessLogicLayer.Interface;
using DataAccessLayer.Impl;
using DataAccessLayer.Interface;
using Models;

namespace BusinessLogicLayer.Impl
{
    /// <summary>
    /// ExperimentServiceImpl 的摘要说明
    /// </summary>
    public class ExperimentServiceImpl : IExperimentService
    {
        private readonly IExperimentDal _experimentDal = new ExperimentDal();
        public IEnumerable<object> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public object GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public object Modify(object modifyWhich)
        {
            throw new System.NotImplementedException();
        }

        public object Create(object createWhich)
        {
            throw new System.NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public int Delete(object deleteWhich)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CourseExperiment> Get(Course whichCourse)
        {
            return _experimentDal.SelectByCourse(whichCourse);
        }

        public int Submit(CourseExperiment courseExperiment, Student whichStudent, Experiment exp)
        {
            exp.CourseExperimentId = courseExperiment.CourseExperimentId;
            exp.StudentId = whichStudent.StudentId;
            return _experimentDal.InsertExperiment(exp);
        }

        public Experiment Get(Student student, CourseExperiment ce)
        {
            return _experimentDal.Select(student.StudentId, ce.CourseExperimentId);
        }
    }
}