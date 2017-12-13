using Models;

/**
 * 
 */
namespace BusinessLogicLayer.Interface
{
    public interface IDepartmentService : IBusinessLogicLayerBase {

        /**
     * @param chineseName 
     * @return
     */
        Department GetByChineseName(string chineseName);

        /**
     * @param englishName 
     * @return
     */
        Department GetByEnglishName(string englishName);

    }
}