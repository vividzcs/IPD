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
    private readonly CourseSelectionDal _courseSelectionDal = new CourseSelectionDal();

    public int CreateCourseSelectRecording(CourseSelection courseSelection)
    {
        return _courseSelectionDal.createCourseSelectRecording(courseSelection);
    }

    public IEnumerable<CourseSelection> GetRecordStudentByCourseId(int id)
    {
        return _courseSelectionDal.SelectRecordStudentByCourseId(id);
    }

}