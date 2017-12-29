using BusinessLogicLayer.Impl;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// CourseAttachmentServiceimpl 的摘要说明
/// </summary>
public class CourseAttachmentServiceimpl : ICourseAttachmentService
{
    private readonly ICourseAttachmentDal _courseAttachmentDal = new CourseAttachmentDal();
    /// <summary>
    /// 创建一个课件并插入到数据库中
    /// </summary>
    /// <param name="courseAttachment">课件类</param>
    /// <returns>创建后返回该课件的id</returns>
    public int Create(object courseAttachment)
    {
        return _courseAttachmentDal.InsertCourseAttachment((CourseAttachment)courseAttachment);
    }
    /// <summary>
    /// 通过获取的课件Id删除课件
    /// </summary>
    /// <param name="neededDeleteAttachmentId">哪个课件Id</param>
    /// <returns>删除是否成功</returns>
    public bool DeleteByAttachemtId(int neededDeleteAttachmentId)
    {
        return _courseAttachmentDal.DeleteByAttachemtId(neededDeleteAttachmentId);
    }

    /// <summary>
    /// 通过课程（需要有ｉｄ属性填充）获取课件，也就是说获取某课程的所有课件
    /// </summary>
    /// <param name="course">哪个课程？</param>
    /// <returns>那个课程的所有课件</returns>
    public IEnumerable<CourseAttachment> Get(Course course)
    {
        return _courseAttachmentDal.SelectByCourse(course);
    }

    /// <summary>
    /// 通过课程ｉｄ获取课件，也就是说获取某课程的所有课件
    /// </summary>
    /// <param name="courseId">那个课程的ｉｄ</param>
    /// <returns>ｉｄ对应的课程的所有课件</returns>
    public IEnumerable<CourseAttachment> Get(int courseId)
    {
        return _courseAttachmentDal.SelectByCourse(new Course() { CourseId = courseId });
    }
    /// <summary>
    /// 通过课件id获取课件，也就是说获取某课程的所有课件
    /// </summary>
    /// <param name="attachmentId">哪个课件的ｉｄ</param>
    /// <returns>课件</returns>
    public CourseAttachment GetByAttachmentId(int attachmentId)
    {
        return _courseAttachmentDal.SelectByAttachmentId(attachmentId);
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