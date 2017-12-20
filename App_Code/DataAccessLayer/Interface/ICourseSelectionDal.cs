using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

/// <summary>
/// ICourseSelectionDal 的摘要说明
/// </summary>
public interface ICourseSelectionDal
{
    /// <summary>
    /// 根据学生和课程信息添加一条选课记录
    /// </summary>
    /// <param name="whichteacher"></param>
    /// <param name="whichstudent"></param>
    /// <returns></returns>
    int createCourseSelectRecording(CourseSelection courseSelection);

    IEnumerable<CourseSelection> SelectRecordStudentByCourseId(int id);

}