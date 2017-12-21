<<<<<<< HEAD
﻿using System;
=======
﻿using Models;
using System;
>>>>>>> 1fdb592b8d3a2e928b7a6053a81e1e82910454bc
using System.Collections.Generic;
using System.Linq;
using System.Web;

<<<<<<< HEAD
/// <summary>
/// ICourseExperimentDal 的摘要说明
/// </summary>
public class ICourseExperimentDal
{
    public ICourseExperimentDal()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
=======
namespace DataAccessLayer.Interface
{
    /// <summary>
    /// ICourseExperimentDal 的摘要说明
    /// </summary>
    public interface ICourseExperimentDal
    {
        int InsertCourseExperiment(CourseExperiment courseExperiment);
>>>>>>> 1fdb592b8d3a2e928b7a6053a81e1e82910454bc
    }
}