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
    }
}
