using System.Collections.Generic;
using Models;

namespace DataAccessLayer.Interface
{
    /// <summary>
    /// IAttachmentDal 的摘要说明
    /// </summary>
    public interface IAttachmentDal
    {
        IEnumerable<CourseAttachment> SelectByCourse(Course course);
    }
}