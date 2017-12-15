using Models;

/**
 * 
 */
namespace BusinessLogicLayer.Interface
{
    public interface IDepartmentService : IBusinessLogicLayerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chineseName"></param>
        /// <returns></returns>
        Department GetByChineseName(string chineseName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="englishName"></param>
        /// <returns></returns>
        Department GetByEnglishName(string englishName);
    }
}