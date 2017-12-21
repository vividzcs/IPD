﻿using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Interface;
using Models;

namespace DataAccessLayer.Impl
{
    /// <inheritdoc />
    /// <summary>
    /// DepartmentDal 的摘要说明
    /// </summary>
    public class DepartmentDal : IDepartmentDal
    {
 
        public IEnumerable<Department> SelectAllDepartments()
        {
            using (var context = new HaermsEntities())
            {
                var departments = context.Department.ToArray();
                return departments;
            }

        }

        public Department SelectDepartmentById(int id)
        {
            using (var context = new HaermsEntities())
            {
                var department = context.Department.Find(id);
                return department;
            }
        }

        public Department SelectDepartmentByName(string name)
        {
            using (var context = new HaermsEntities())
            {
                var _t = context.Department.FirstOrDefault(t => t.ChinesaeName == name);
                return _t;
            }
        }

        public int UpdateDepartment(Department department)
        {
            using (var context = new HaermsEntities())
            {
                var firstOrDefault = context.Department.FirstOrDefault(d => d.DepartmentId == department.DepartmentId);
                if (firstOrDefault == null) return 0;
                else
                {
                    firstOrDefault.EnglishName = department.EnglishName;
                    firstOrDefault.ChinesaeName = department.ChinesaeName;
                    firstOrDefault.Introduction = department.Introduction;
                    return context.SaveChanges();
                }
                

            }
        }
    }
}