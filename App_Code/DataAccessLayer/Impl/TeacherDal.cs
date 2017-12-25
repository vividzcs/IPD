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

        /**
         * when freeze teacher, 
         * we set the Banned = true
         * <returns>the banned we set equal true? true or fasle</returns>
             */
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

        /**
            edit teacher
            <returns>return the affected rows</returns>
             */
        public int ModifyTeacher(Teacher teacher)
        {
            using(var context = new HaermsEntities())
            {
                var _t = context.Teacher.FirstOrDefault(t => t.TeacherId == teacher.TeacherId);
                _t.Name = teacher.Name;
                _t.DepartmentId = teacher.DepartmentId;
                _t.Introduction = teacher.Introduction;
                _t.JobNumber = teacher.JobNumber;
                return context.SaveChanges();
            }
        }

        /**
         * reset teacher's password
         * <returns>the password of this man now equals "111111"?true or false</returns>
         */
        public int ResetTeacherPassword(int teacherId)
        {
            using(var context = new HaermsEntities())
            {
                var _t = context.Teacher.FirstOrDefault(t => t.TeacherId == teacherId);
                _t.Password = "111111";
                return _t.Password == "111111" ? 1 : 0;
            }
        }

        
         
         /**
          add a teacher
            <returns>return the affected rows</returns>
             */
             
        public int InsertTeacher(Teacher teacher)
        {
            using (var context = new HaermsEntities())
            {
                context.Teacher.Add(teacher);
                return context.SaveChanges();
            }
        }

        public bool IsBanned(Teacher teacher)
        {
            using (var context = new HaermsEntities())
            {
                var t = context.Teacher.Find(teacher.TeacherId);
                return t?.Banned ?? true;
            }
        }

        public int UpdateTeacherPassword(Teacher teacher)
        {
            using (var context = new HaermsEntities())
            {
                var q = context.Teacher.Find(teacher.TeacherId);
                if (q == null)
                {
                    return 0;
                }
                q.Password = teacher.Password;
                return context.SaveChanges();
            }
        }
    }
}