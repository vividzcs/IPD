using Models;
using System.Collections;
using System.Collections.Generic;

namespace DataAccessLayer.Interface
{
    /// <summary>
    /// IClassDal 的摘要说明
    /// </summary>
    public interface IClassDal
    {
        /// <summary>
        /// 通过ｃｌａｓｓＩｄ查找班级
        /// </summary>
        /// <param name="id">classid</param>
        /// <returns>The entity found, or null.</returns>
        Class SelectClassById(int id);

        /// <summary>
        /// 查出所有的班级
        /// </summary>
        /// <returns>The entity found, or null.</returns>
        IEnumerable<Class> SelectClassAll();
    }
}