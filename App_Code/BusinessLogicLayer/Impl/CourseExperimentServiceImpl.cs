using System;
using DataAccessLayer.Impl;
using DataAccessLayer.Interface;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer.Interface;

public class CourseExperimentServiceImpl : ICourseExperimentService
{
    private readonly ICourseExperimentDal _courseExperiment = new CourseExperimentDal();

    public int Create(object courseExperiment)
    {
        return _courseExperiment.InsertCourseExperiment((CourseExperiment) courseExperiment);
    }

    public int Delete(int id)
    {
        throw new NotImplementedException();
    }

    public int Delete(object deleteWhich)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<object> GetAll()
    {
        throw new NotImplementedException();
    }

    public object GetById(int id)
    {
        throw new NotImplementedException();
    }

    public object Modify(object modifyWhich)
    {
        throw new NotImplementedException();
    }
}