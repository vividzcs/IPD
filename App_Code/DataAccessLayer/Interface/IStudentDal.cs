using Models;

namespace DataAccessLayer.Interface
{
    /// <summary>
    /// IStudentSal 的摘要说明
    /// </summary>
    public interface IStudentDal
    {
        Student SelectStudentByStudentNumberAndPassword(Student student);
    }
}