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

       


        

    }
}