using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer.Interface;
using DataAccessLayer.Impl;
using DataAccessLayer.Interface;
using Models;

/// <summary>
/// StudentServiceImpl 的摘要说明
/// </summary>
public class StudentServiceImpl : IStudentService
{
    private IStudentDal _studentDal = new StudentDal();

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

    public Student Login(Student student)
    {
        return _studentDal.SelectStudentByStudentNumberAndPassword(student);
    }

    public Student ModifyPassword(Student student)
    {
        throw new NotImplementedException();
    }
}