using Models;

/**
 * 
 */
namespace BusinessLogicLayer.Interface
{
    /// <inheritdoc />
    public interface IAdminService : IBusinessLogicLayerBase {

        /**
     * @param admin 
     * @return
     */
        Admin Login(Admin admin);

        /**
     * @param teacher 
     * @return
     */
        int FreezeTeacher(Teacher teacher);

        /**
     * @param teacher 
     * @return
     */
        int ResetTeacherPassword(Teacher teacher);

        /**
     * @param department 
     * @return
     */
        int CreateDepartment(Department department);

        /**
     * @param department 
     * @return
     */
        int ModifyDepartment(Department department);

        /**
     * @param department Department 
     * @return
     */
        int DestoryDepartment(Department department);

        /**
     * @param teacher 
     * @return
     */
        int CreateTeacher(Teacher teacher);

        /**
     * @param teacher 
     * @return
     */
        int ModifyTeacher(Teacher teacher);

    }
}