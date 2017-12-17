using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

/// <summary>
/// AdminDal 的摘要说明
/// </summary>
public class AdminDal : IAdminDal
{
    public Admin SelectByJobNumberAndPassword(Admin admin)
    {
        using (var context = new HaermsEntities())
        {
            var iqueryable = context.Admin.Where(t => t.JobNumber == admin.JobNumber && t.Password == admin.Password);
            return iqueryable.FirstOrDefault();
        }
    }
}