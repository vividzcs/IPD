using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;
using Models;

/// <summary>
/// DepartmentDal 的摘要说明
/// </summary>
public class DepartmentDal : IDepartmentDal
{
 
    public Department[] GetAllDepartments()
    {
        using (var context = new HaermsEntities())
        {
            var departments = context.Department.ToArray();
            return departments;
        }

    }
}