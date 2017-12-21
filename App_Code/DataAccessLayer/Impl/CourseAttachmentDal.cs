using BusinessLogicLayer.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

/// <summary>
/// CourseAttachmentDal 的摘要说明
/// </summary>
public class CourseAttachmentDal : ICourseAttachmentDal
{
    public int InsertCourseAttachment(CourseAttachment courseAttachment)
    {
        using (var context = new HaermsEntities())
        {
            var obj = context.CourseAttachment.Add(courseAttachment);
            context.SaveChanges();
            return obj.AttachmentId;
        }
    }
}