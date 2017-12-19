using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer.Interface;
using Models;

/// <summary>
/// AdminServiceImpl 的摘要说明
/// </summary>
public class AdminServiceImpl : IAdminService
{

    /// <summary>
    /// 请勿调用此方法！！！获取所有的管理员账户
    /// </summary>
    /// <returns>在任何情况下直接抛出异常NotImplementedException</returns>
    public IEnumerable<object> GetAll()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 请勿调用此方法！！！获取所有的管理员账户
    /// </summary>
    /// <returns>在任何情况下直接抛出异常NotImplementedException</returns>
    public object GetById(int id)
    {
        throw new NotImplementedException();
    }

    public object Modify(object modifyWhich)
    {
        throw new NotImplementedException();
    }

    public int Create(object createWhich)
    {
        throw new NotImplementedException();
    }

    public int Delete(int id)
    {
        throw new NotImplementedException();
    }

    public int Delete(object deleteWhich)
    {
        throw new NotImplementedException();
    }

    public Admin Login(Admin admin)
    {
        throw new NotImplementedException();
    }

    public int FreezeTeacher(Teacher teacher)
    {
        throw new NotImplementedException();
    }

    public int ResetTeacherPassword(Teacher teacher)
    {
        throw new NotImplementedException();
    }

    public int CreateDepartment(Department department)
    {
        throw new NotImplementedException();
    }

    public int ModifyDepartment(Department department)
    {
        throw new NotImplementedException();
    }

    public int DestoryDepartment(Department department)
    {
        throw new NotImplementedException();
    }

    public int CreateTeacher(Teacher teacher)
    {
        throw new NotImplementedException();
    }

    public int ModifyTeacher(Teacher teacher)
    {
        throw new NotImplementedException();
    }
}