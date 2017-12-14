using Models;

namespace DataAccessLayer.Interface
{
    /// <summary>
    /// IClassDal 的摘要说明
    /// </summary>
    public interface IClassDal
    {
        Class SelectClassById(int id);
    }
}