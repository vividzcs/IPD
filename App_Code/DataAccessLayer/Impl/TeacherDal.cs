using System;
using System.Linq;
using DataAccessLayer.Interface;
using Models;
using System.Collections.Generic;

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

        public IEnumerable<Teacher> SelectAllTeacher()
        {
            using (var context = new HaermsEntities())
            {
                return context.Teacher.ToArray();
            }
        }

        public int UpdateTeacherBanned(int teacherId)
        {
            using(var context = new HaermsEntities())
            {
                var _t = context.Teacher.FirstOrDefault(t => t.TeacherId == teacherId);
                _t.Banned = true;
                context.SaveChanges();
                return _t.Banned == true ? 1 : 0;
            }
        }
    }
}