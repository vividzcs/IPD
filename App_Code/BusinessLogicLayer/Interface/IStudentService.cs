using Models;

/**
 * 
 */
namespace BusinessLogicLayer.Interface
{
    public interface IStudentService : IBusinessLogicLayerBase {

        /**
     * @param student 
     * @return
     */
        Student Login(Student student);

        /**
     * @param student 
     * @return
     */
        int ModifyPassword(Student student);

    }
}