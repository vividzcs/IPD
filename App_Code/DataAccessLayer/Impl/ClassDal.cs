﻿using System;
using DataAccessLayer.Interface;
using Models;

namespace DataAccessLayer.Impl
{
    /// <summary>
    /// ClassDal 的摘要说明
    /// </summary>
    public class ClassDal : IClassDal
    {
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