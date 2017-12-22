using DataAccessLayer.Interface;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// CourseHomeworkServiceImpl 的摘要说明
/// </summary>
public class CourseHomeworkServiceImpl : ICourseHomeworkService
{
    private readonly ICourseHomeworkDal _courseHomeworkDal = new CourseHomeworkDal();
    public int Create(object courseHomework)
    {
        return _courseHomeworkDal.InsertCourseHomework((CourseHomework)courseHomework);
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