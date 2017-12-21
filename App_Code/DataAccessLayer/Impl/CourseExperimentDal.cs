<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// CourseExperimentDal 的摘要说明
/// </summary>
public class CourseExperimentDal : ICourseExperimentDal
{
    public CourseExperimentDal()
    { 
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
}
=======
﻿using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace DataAccessLayer.Impl
{
    /// <summary>
    /// CourseExperimentDal 的摘要说明
    /// </summary>
    public class CourseExperimentDal : ICourseExperimentDal
    {
        public int InsertCourseExperiment(CourseExperiment courseExperiment)
        {
            using (var context = new HaermsEntities())
            {
                CourseExperiment c = context.CourseExperiment.Add(courseExperiment);
                context.SaveChanges();
                return c.CourseExperimentId;
            }
        }
    }
}
>>>>>>> 1fdb592b8d3a2e928b7a6053a81e1e82910454bc
