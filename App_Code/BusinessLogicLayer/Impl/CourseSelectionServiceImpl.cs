using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer.Impl;
using DataAccessLayer.Impl;
using DataAccessLayer.Interface;
using Models;
/// <summary>
/// CourseSelectionService 的摘要说明
/// </summary>
public class CourseSelectionServiceImpl : ICourseSelectionService
{
    private readonly ICourseSelectionDal _courseSelectionDal = new CourseSelectionDal();

    public int CreateCourseSelectRecording(CourseSelection courseSelection)
    {
        return _courseSelectionDal.createCourseSelectRecording(courseSelection);
    }

    public IEnumerable<CourseSelection> GetRecordStudentByCourseId(int id)
    {
        return _courseSelectionDal.SelectRecordStudentByCourseId(id);
    }

    public IEnumerable<CourseSelection> GetCoursesByStudentId(Student student)
    {
        return _courseSelectionDal.SelectByStudentId(student.StudentId);
    }

    public bool VerifyStudentCourseSelection(Student s, Course c)
    {
        //true 如果源序列中不包含任何元素，则否则为 false
        return _courseSelectionDal.SelectByStudentIdAndCourseId(s, c).Any();
    }
}