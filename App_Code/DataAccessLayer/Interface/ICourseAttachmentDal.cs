using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLogicLayer.Impl
{
    /// <summary>
    /// ICourseAttachmentDal 的摘要说明
    /// </summary>
    public interface ICourseAttachmentDal
    {
        int InsertCourseAttachment(CourseAttachment courseAttachment);
        /// <summary>
        /// IAttachmentDal 的摘要说明
        /// </summary>
        /// <summary>
        /// 通过课程id查找课程课件
        /// </summary>
        /// <param name="course">封装了课程id的课程对象</param>
        /// <returns>课程课件的枚举器</returns>
        IEnumerable<CourseAttachment> SelectByCourse(Course course);

        /// <summary>
        /// ICourseAttachmentDal 的摘要说明
        /// </summary>
        /// <summary>
        /// 通过课件Id删除课件
        /// </summary>
        /// <param name="neededDeleteAttachmentId">需要删除的课件id</param>
        /// <returns>是否删除成功的bool类型</returns>
        bool DeleteByAttachemtId(int neededDeleteAttachmentId);

        /// <summary>
        /// ICourseAttachmentDal 的摘要说明
        /// </summary>
        /// <summary>
        /// 通过课件Id找到课件
        /// </summary>
        /// <param name="attachmentId">需要查找的课件id</param>
        /// <returns>一个课件/returns>
        CourseAttachment SelectByAttachmentId(int attachmentId);
    }
}
