using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

/// <summary>
/// CourseSelectionDal 的摘要说明
/// </summary>
public class CourseSelectionDal : ICourseSelectionDal
{
    public int createCourseSelectRecording(CourseSelection courseSelection)
    {
        using(var context = new HaermsEntities())
        {
            CourseSelection cs = context.CourseSelection.Add((CourseSelection)courseSelection);
            context.SaveChanges();
            return cs.CourseSelectionId;
        }
    }

    public IEnumerable<CourseSelection> SelectRecordStudentByCourseId(int id)
    {
        using (var context = new HaermsEntities())
        {
            var queryset = context.CourseSelection.Where(cs => cs.CourseId == id);
            return queryset.ToArray();
        }
    }
}
