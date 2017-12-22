using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer.Interface
{
    /// <summary>
    /// IScoreDal 的摘要说明
    /// </summary>

    public interface IScoreDal
    {
        /// <summary>
        /// 通过courseＩｄ和StudentsID查找成绩
        /// </summary>
        /// <param name="id">classid</param>
        /// <returns>The entity found, or null.</returns>
        Score SelectScoreByCourseIdAndStudentId(int Courseid, int Studen);

    }
}