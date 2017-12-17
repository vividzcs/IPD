﻿using System;
using System.Linq;
using DataAccessLayer.Interface;
using Models;

namespace DataAccessLayer.Impl
{
    /// <inheritdoc />
    /// <summary>
    /// TeacherServiceImpl 的摘要说明
    /// </summary>
    public class TeacherDal : ITeacherDal
    {
        public Teacher[] SelectTeachersByDepartment(int departmentId)
        {
            using (var context = new HaermsEntities())
            {
                var queryable = context.Teacher.Where(t => t.DepartmentId == departmentId);
                return queryable.ToArray();
            }
        }

        public Teacher SelectById(int id)
        {
            using (var context = new HaermsEntities())
            {
                return context.Teacher.Find(id);
            }
        }

        public Teacher SelectByJobNumberAndPassword(Teacher teacher)
        {
            using (var context = new HaermsEntities())
            {
                var queryable = context.Teacher.Where(t => t.JobNumber == teacher.JobNumber && t.Password == teacher.Password);
                return queryable.FirstOrDefault();
            }
        }
    }
}