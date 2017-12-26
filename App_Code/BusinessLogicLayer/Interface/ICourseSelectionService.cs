using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

/// <summary>
/// ICourseSelectionService 的摘要说明
/// </summary>
public interface ICourseSelectionService
{
    int CreateCourseSelectRecording(CourseSelection courseSelection);

    IEnumerable<CourseSelection> GetRecordStudentByCourseId(int id);

    /// <summary>
    /// 通过学生id来获取该生于课程的对应关系
    /// </summary>
    /// <param name="student">包含ID的学生对象</param>
    /// <returns>对应关系枚举器</returns>
    IEnumerable<CourseSelection> GetCoursesByStudentId(Student student);

    /// <summary>
    /// 验证该生是否选择了该课程
    /// </summary>
    /// <param name="s"></param>
    /// <param name="c"></param>
    /// <returns>选择了返回true，否则false</returns>
    bool VerifyStudentCourseSelection(Student s, Course c);
}