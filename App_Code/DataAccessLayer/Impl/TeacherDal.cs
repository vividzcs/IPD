using System;
using System.Linq;
using DataAccessLayer.Interface;
using Models;
using System.Collections.Generic;
using Utils;

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
                var temp = _t.Banned;
                _t.Banned = !temp;
                context.SaveChanges();
                return _t.Banned == !temp ? 1 : 0;
            }
        }

        public int ModifyTeacher(Teacher teacher)
        {
            using(var context = new HaermsEntities())
            {
                var _t = context.Teacher.FirstOrDefault(t => t.TeacherId == teacher.TeacherId);
                _t.Name = teacher.Name;
                _t.DepartmentId = teacher.DepartmentId;
                _t.Introduction = teacher.Introduction;
                _t.JobNumber = teacher.JobNumber;
                context.SaveChanges();
                return _t.Name == teacher.Name ? 1 : 0;
            }
        }

        public void ResetTeacherPassword(int teacherId)
        {
            using(var context = new HaermsEntities())
            {
                var _t = context.Teacher.FirstOrDefault(t => t.TeacherId == teacherId);
                _t.Password = Md5Helper.Md5WithSalt("111111");
            }
        }

        public int InsertTeacher(Teacher teacher)
        {
            using (var context = new HaermsEntities())
            {
                context.Teacher.Add(teacher);
                context.SaveChanges();
                return context.Teacher.First(t =>
                           t.TeacherId == teacher.TeacherId) != null ? 1 : 0;
            }
        }
    }
}