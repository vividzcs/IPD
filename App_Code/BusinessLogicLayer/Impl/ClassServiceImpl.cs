using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer.Impl;
using DataAccessLayer.Interface;

/// <inheritdoc />
/// <summary>
/// ClassServiceImpl 的摘要说明
/// </summary>
public class ClassServiceImpl : IClassService
{
    private readonly IClassDal _classDal = new ClassDal();
    public IEnumerable<object> GetAll()
    {
        return _classDal.SelectClassAll();
    }

    /// <summary>
    /// 通过ｃｌａｓｓＩｄ查找班级
    /// </summary>
    /// <param name="id">classid</param>
    /// <returns>The entity found, or null.</returns>
    public object GetById(int id)
    {
        return _classDal.SelectClassById(id);
    }

    public object Modify(object modifyWhich)
    {
        throw new NotImplementedException();
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
}