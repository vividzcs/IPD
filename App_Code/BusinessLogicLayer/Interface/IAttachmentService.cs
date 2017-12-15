using System.Collections.Generic;
using Models;

namespace BusinessLogicLayer.Interface
{
    /// <summary>
    /// IAttachmentService 的摘要说明
    /// </summary>
    public interface IAttachmentService : IBusinessLogicLayerBase
    {
        /// <summary>
        /// 通过课程（需要有ｉｄ属性填充）获取课件，也就是说获取某课程的所有课件
        /// </summary>
        /// <param name="course">哪个课程？</param>
        /// <returns>那个课程的所有课件</returns>
        IEnumerable<CourseAttachment> Get(Course course);

        /// <summary>
        /// 通过课程ｉｄ获取课件，也就是说获取某课程的所有课件
        /// </summary>
        /// <param name="courseId">那个课程的ｉｄ</param>
        /// <returns>ｉｄ对应的课程的所有课件</returns>
        IEnumerable<CourseAttachment> Get(int courseId);
    }
}