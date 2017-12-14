using System.Collections.Generic;
using BusinessLogicLayer.Interface;
using DataAccessLayer.Interface;
using Models;

namespace BusinessLogicLayer.Impl
{
    /// <summary>
    /// AttachmentServiceImpl 的摘要说明
    /// </summary>
    public class AttachmentServiceImpl : IAttachmentService
    {
        private readonly IAttachmentDal _attachmentDal = new AttachmentDal();


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

        public IEnumerable<CourseAttachment> Get(Course course)
        {
            return _attachmentDal.SelectByCourse(course);
        }

        public IEnumerable<CourseAttachment> Get(int courseId)
        {
            return _attachmentDal.SelectByCourse(new Course(){CourseId = courseId});
        }
    }
}