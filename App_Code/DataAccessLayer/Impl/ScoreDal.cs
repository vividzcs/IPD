using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using DataAccessLayer.Interface;

namespace DataAccessLayer.Impl
{
    /// <summary>
    /// ScoreDal 的摘要说明
    /// </summary>
    public class ScoreDal : IScoreDal
    {
        /// <inheritdoc />
        /// <summary>
        /// StudentDal 的摘要说明
        /// </summary>
        //通过学生id和课程Id找到当前学生某项课程的成绩
        public Score SelectScoreByCourseIdAndStudentId(int Courseid, int StudentId)
        {
            using (var context = new HaermsEntities())
            {
                var st = new Score { ScoreId = -1 };
                var q = context.Score.Where(s => s.CourseId == Courseid && s.StudentId == StudentId);
                try {
                    st = q.First();
                    return st;
                }
                catch (Exception ex) {

                    //如果出现没有成绩的情况就将其赋值为1
                    st = new Score { ScoreId = -1 };
                }
                finally {
                }
                return st;
            }
        }
    }
}