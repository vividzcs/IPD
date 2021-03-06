﻿using System;
using System.Linq;
using DataAccessLayer.Interface;
using Models;

namespace DataAccessLayer.Impl
{
    /// <inheritdoc />
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

        public int UpdateStudent(Student student)
        {
            using (var context = new HaermsEntities())
            {
                var q = context.Student.Find(student.StudentId);
                if (q == null)
                {
                    return 0;
                }
                q.Password = student.Password;
                return context.SaveChanges();
            }
        }
        
        public Student SelectStudentByStudentNumber(Student student)
        {
            using (var context = new HaermsEntities())
            {
                var queryable = context.Student.Where(s => s.StudentNumber == student.StudentNumber);
                return queryable.FirstOrDefault();
            }
        }
    }
}
