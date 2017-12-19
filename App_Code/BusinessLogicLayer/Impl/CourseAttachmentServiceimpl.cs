using BusinessLogicLayer.Impl;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// CourseAttachmentServiceimpl 的摘要说明
/// </summary>
public class CourseAttachmentServiceimpl : IClassService
{
    private readonly ICourseAttachmentDal _courseAttachmentDal = new CourseAttachmentDal();

    public int Create(object courseAttachment)
    {
        return _courseAttachmentDal.InsertCourseAttachment((CourseAttachment)courseAttachment);
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