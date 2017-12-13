using System;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    /// <summary>
    /// IBusinessLogicLayer 的摘要说明
    /// </summary>
    public interface IBusinessLogicLayerBase
    {
        /// <summary>
        /// 此方法得到所有的xx
        /// </summary>
        /// <returns>所有的xx组成的数组</returns>
        IEnumerable<object> GetAll();

        object GetById(int id);

        object Modify(object modifyWhich);

        object Create(object createWhich);

        int Delete(int id);

        int Delete(object deleteWhich);
    }
}