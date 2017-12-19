using System.Collections.Generic;
using BusinessLogicLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Impl;
using DataAccessLayer.Interface;
using Models;

namespace BusinessLogicLayer.Impl
{
    /// <inheritdoc />
    /// <summary>
    /// DepartmentServiceImpl 的摘要说明
    /// </summary>
    public class DepartmentServiceImpl : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal = new DepartmentDal();


        public IEnumerable<object> GetAll()
        {
            return _departmentDal.SelectAllDepartments();
        }

        public object GetById(int id)
        {
            return _departmentDal.SelectDepartmentById(id);
        }

        public object Modify(object modifyWhich)
        {
            throw new System.NotImplementedException();
        }

        public int Create(object createWhich)
        {
            throw new System.NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public int Delete(object deleteWhich)
        {
            throw new System.NotImplementedException();
        }

        public Department GetByChineseName(string chineseName)
        {
            throw new System.NotImplementedException();
        }

        public Department GetByEnglishName(string englishName)
        {
            throw new System.NotImplementedException();
        }
    }
}