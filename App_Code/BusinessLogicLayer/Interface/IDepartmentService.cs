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
    }
}