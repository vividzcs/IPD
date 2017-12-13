using System;
using System.Linq;
using DataAccessLayer.Interface;
using Models;

namespace DataAccessLayer.Impl
{
    /// <summary>
    /// StudentDal 的摘要说明
    /// </summary>
    public class StudentDal : IStudentDal
    {
       public Student SelectStudentByStudentNumberAndPassword(Student student)
        {
            using (var context = new HaermsEntities())
            {
                var queryable = context.Student.Where(s => s.StudentNumber == student.StudentNumber && s.Password == student.Password);
                return queryable.FirstOrDefault();
            }
        }
    }
}