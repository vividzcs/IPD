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
    }
}