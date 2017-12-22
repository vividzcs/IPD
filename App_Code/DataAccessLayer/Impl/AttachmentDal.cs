using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer.Interface;
using Models;

/// <summary>
/// AttachmentDal 的摘要说明
/// </summary>
public class AttachmentDal : IAttachmentDal
{
    

    public IEnumerable<CourseAttachment> SelectByCourse(Course course)
    {
        using (var context = new HaermsEntities())
        {
            var courseAttachments = context.CourseAttachment.Where(ca => ca.CourseId == course.CourseId);
            return courseAttachments.ToArray();
        }
    }

    public bool DeleteByAttachemtId(int neededDeleteAttachmentId)
    {
        using (var context = new HaermsEntities())
        {
            var courseAttachment = context.CourseAttachment.Where(ca => ca.AttachmentId == neededDeleteAttachmentId);
            context.CourseAttachment.Remove((CourseAttachment)courseAttachment.First());
            if (context.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}