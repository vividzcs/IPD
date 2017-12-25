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
        /// 修改管理员密码
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        int ModifyPassword(Admin admin);
    }
}