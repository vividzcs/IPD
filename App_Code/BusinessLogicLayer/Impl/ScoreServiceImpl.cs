using BusinessLogicLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer;
using Models;
using DataAccessLayer.Interface;
using DataAccessLayer.Impl;

namespace BusinessLogicLayer.Impl
{
    /// <summary>
    /// ScoreServiceImpl 的摘要说明
    /// </summary>
    public class ScoreServiceImpl : IScoreService
    {
        private IScoreDal _IScoreDal = new ScoreDal();
        public ScoreServiceImpl()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        int IBusinessLogicLayerBase.Create(object createWhich)
        {
            throw new NotImplementedException();
        }

        int IBusinessLogicLayerBase.Delete(int id)
        {
            throw new NotImplementedException();
        }

        int IBusinessLogicLayerBase.Delete(object deleteWhich)
        {
            throw new NotImplementedException();
        }

        Score IScoreService.Get(Student whichStudent, Course whichCourse)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Score> IScoreService.Get(Student whichStudent)
        {
            throw new NotImplementedException();
        }

        IEnumerable<object> IBusinessLogicLayerBase.GetAll()
        {
            throw new NotImplementedException();
        }

        object IBusinessLogicLayerBase.GetById(int id)
        {
            throw new NotImplementedException();
        }

        object IBusinessLogicLayerBase.Modify(object modifyWhich)
        {
            throw new NotImplementedException();
        }
        public Score GetByCourseIdAndStudentId(int CourseId, int StudentId)
        {
            return _IScoreDal.SelectScoreByCourseIdAndStudentId(CourseId, StudentId);
        }
    }
}