using Models;

/**
 * 
 */
namespace BusinessLogicLayer.Interface
{
    public interface IAdminService
    {
        /**
     * @param admin 
     * @return
     */
        Admin Login(Admin admin);

        /// <summary>
        /// �޸Ĺ���Ա����
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        int ModifyPassword(Admin admin);
    }
}