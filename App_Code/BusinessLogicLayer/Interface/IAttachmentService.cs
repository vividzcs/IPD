using System.Collections.Generic;
using Models;

namespace BusinessLogicLayer.Interface
{
    /// <summary>
    /// IAttachmentService 的摘要说明
    /// </summary>
    public interface IAttachmentService : IBusinessLogicLayerBase
    {
        IEnumerable<CourseAttachment> Get(Course course);

        IEnumerable<CourseAttachment> Get(int courseId);
    }
}