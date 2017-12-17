using System;
using DataAccessLayer.Interface;
using Models;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace DataAccessLayer.Impl
{
    /// <summary>
    /// ClassDal 的摘要说明
    /// </summary>
    public class ClassDal : IClassDal
    {
        public IEnumerable<Class> SelectClassAll()
        {
            using (var context = new HaermsEntities())
            {
                return context.Class.AsParallel().ToArray();
            }
        }


        /// <summary>
        /// 通过ｃｌａｓｓＩｄ查找班级
        /// </summary>
        /// <param name="id">classid</param>
        /// <returns>The entity found, or null.</returns>
        public Class SelectClassById(int id)
        {
            using (var context = new HaermsEntities())
            {
                return context.Class.Find(id);
            }
        }
    }
}