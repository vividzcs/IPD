﻿using System;
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
}