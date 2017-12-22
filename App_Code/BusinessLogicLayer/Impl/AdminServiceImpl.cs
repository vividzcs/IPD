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
    private readonly IAdminDal _adminDal = new AdminDal();

    public Admin Login(Admin admin)
    {
        return _adminDal.SelectByJobNumberAndPassword(admin);
    }
}