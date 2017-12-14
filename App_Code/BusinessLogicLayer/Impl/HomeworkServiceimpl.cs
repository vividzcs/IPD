using System.Collections.Generic;
using BusinessLogicLayer.Interface;
using DataAccessLayer.Impl;
using DataAccessLayer.Interface;
using Models;

namespace BusinessLogicLayer.Impl
{
    /// <summary>
    /// HomeworkServiceimpl 的摘要说明
    /// </summary>
    public class HomeworkServiceImpl : IHomeworkService
    {
        private readonly IHomeworkDal _homeworkDal = new HomeworkDal();
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

        public IEnumerable<CourseHomework> Get(Course whichCourse)
        {
            return _homeworkDal.SelectByCourse(whichCourse);
        }

        public int Submit(Course whichCourse, Student whichStudent, Homework homework)
        {
            throw new System.NotImplementedException();
        }
    }
}