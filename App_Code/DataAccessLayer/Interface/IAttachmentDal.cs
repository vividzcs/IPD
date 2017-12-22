using System.Collections.Generic;
using Models;

namespace DataAccessLayer.Interface
{
    /// <summary>
    /// IAttachmentDal 的摘要说明
    /// </summary>
    public interface IAttachmentDal
    {
        /// <summary>
        /// 通过课程id查找课程课件
        /// </summary>
        /// <param name="course">封装了课程id的课程对象</param>
        /// <returns>课程课件的枚举器</returns>
        IEnumerable<CourseAttachment> SelectByCourse(Course course);
        bool DeleteByAttachemtId(int neededDeleteAttachmentId);
    }
}