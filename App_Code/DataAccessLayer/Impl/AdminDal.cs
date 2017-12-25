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

    public int UpdateAdminPassword(Admin admin)
    {
        using (var context = new HaermsEntities())
        {
            var q = context.Admin.Find(admin.AdminId);
            if (q == null)
            {
                return 0;
            }
            q.Password = admin.Password;
            return context.SaveChanges();
        }
    }
}