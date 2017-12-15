using System.Collections.Generic;
using BusinessLogicLayer.Interface;
using DataAccessLayer.Interface;
using Models;

namespace BusinessLogicLayer.Impl
{
    /// <inheritdoc />
    /// <summary>
    /// AttachmentServiceImpl 是课件业务逻辑层的实现
    /// </summary>
    public class AttachmentServiceImpl : IAttachmentService
    {
        /// <summary>
        /// 课件数据访问层
        /// </summary>
        private readonly IAttachmentDal _attachmentDal = new AttachmentDal();

        /// <summary>
        /// 请勿调用此方法！！！获取所有的课件
        /// </summary>
        /// <returns>在任何情况下直接抛出异常NotImplementedException</returns>
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

        /// <summary>
        /// 通过课程（需要有ｉｄ属性填充）获取课件，也就是说获取某课程的所有课件
        /// </summary>
        /// <param name="course">哪个课程？</param>
        /// <returns>那个课程的所有课件</returns>
        public IEnumerable<CourseAttachment> Get(Course course)
        {
            return _attachmentDal.SelectByCourse(course);
        }

        /// <summary>
        /// 通过课程ｉｄ获取课件，也就是说获取某课程的所有课件
        /// </summary>
        /// <param name="courseId">那个课程的ｉｄ</param>
        /// <returns>ｉｄ对应的课程的所有课件</returns>
        public IEnumerable<CourseAttachment> Get(int courseId)
        {
            return _attachmentDal.SelectByCourse(new Course(){CourseId = courseId});
        }
    }
}