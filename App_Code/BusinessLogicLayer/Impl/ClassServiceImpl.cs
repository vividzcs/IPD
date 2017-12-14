using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer.Impl;
using DataAccessLayer.Interface;

/// <summary>
/// ClassServiceImpl 的摘要说明
/// </summary>
public class ClassServiceImpl : IClassService
{
    private IClassDal classDal = new ClassDal();
    public IEnumerable<object> GetAll()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The entity found, or null.</returns>
    public object GetById(int id)
    {
        return classDal.SelectClassById(id);
    }

    public object Modify(object modifyWhich)
    {
        throw new NotImplementedException();
    }

    public object Create(object createWhich)
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
}