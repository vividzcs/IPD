using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

/// <summary>
/// ICourseAttachService 的摘要说明
/// </summary>
public interface ICourseAttachmentService : IBusinessLogicLayerBase
{
        IEnumerable<CourseAttachment> Get(Course course);
        /// <summary>
        /// 通过课程ｉｄ获取课件，也就是说获取某课程的所有课件
        /// </summary>
        /// <param name="courseId">那个课程的ｉｄ</param>
        /// <returns>ｉｄ对应的课程的所有课件</returns>
        IEnumerable<CourseAttachment> Get(int courseId);
}