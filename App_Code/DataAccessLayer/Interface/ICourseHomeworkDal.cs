using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer.Interface
{
    /// <summary>
    /// ICourseHomeworkDal 的摘要说明
    /// </summary>
    public interface ICourseHomeworkDal
    {
        int InsertCourseHomework(CourseHomework courseHomework);
    }
}
