<<<<<<< HEAD
﻿using System;
=======
﻿using DataAccessLayer.Impl;
using DataAccessLayer.Interface;
using Models;
using System;
>>>>>>> 1fdb592b8d3a2e928b7a6053a81e1e82910454bc
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
<<<<<<< HEAD
/// CourseExperimentServiceImpl 的摘要说明
/// </summary>
/// 
namespace BusinessLogicLayer.Impl
{
    public class CourseExperimentServiceImpl : ICourseExperimentService
    {
        public CourseExperimentServiceImpl()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public int Create(object createWhich)
        {
            throw new NotImplementedException();
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
=======
/// CourseExperiment 的摘要说明
/// </summary>
public class CourseExperimentServiceImpl : ICourseExperimentService
{
    private readonly ICourseExperimentDal _courseExperiment = new CourseExperimentDal();

    public int Create(object courseExperiment)
    {
        return _courseExperiment.InsertCourseExperiment((CourseExperiment)courseExperiment);   
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
>>>>>>> 1fdb592b8d3a2e928b7a6053a81e1e82910454bc
    }
}