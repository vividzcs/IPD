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
    public IEnumerable<CourseAttachment> SelectByCourse(Course course)
    {
        using (var context = new HaermsEntities())
        {
            var courseAttachments = context.CourseAttachment.Where(ca => ca.CourseId == course.CourseId);
            return courseAttachments.ToArray();
        }
    }
    public CourseAttachment SelectByAttachmentId(int attachmentId)
    {
        using (var context = new HaermsEntities())
        {
            var courseAttachments = context.CourseAttachment.Where(ca => ca.AttachmentId == attachmentId);
            return courseAttachments.ToArray().First();
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