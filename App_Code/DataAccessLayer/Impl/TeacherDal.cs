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
    }
}