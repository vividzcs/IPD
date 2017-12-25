using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// IAdminDal 的摘要说明
/// </summary>
public interface IAdminDal
{
    Admin SelectByJobNumberAndPassword(Admin admin);
    int UpdateAdminPassword(Admin admin);
}