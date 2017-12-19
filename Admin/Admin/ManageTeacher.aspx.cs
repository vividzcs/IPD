using BusinessLogicLayer.Impl;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManageTeacher : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
           
        
    }


    protected void GridViewTeacher_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewTeacher.EditIndex = e.NewEditIndex;
        DataBind();
    }

    protected void GridViewTeacher_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var teacher = new Teacher()
        {
            Name = e.NewValues[0].ToString(),
            DepartmentId = new DepartmentServiceImpl().GetByChineseName(e.NewValues[1].ToString()).DepartmentId,
            Introduction = e.NewValues[2].ToString(),
            JobNumber = e.NewValues[3].ToString()
        };
        new TeacherServiceImpl().ModifyTeacher(teacher);
        GridViewTeacher.EditIndex = -1;
        DataBind();
    }


    protected void GridViewTeacher_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewTeacher.EditIndex = -1;
        DataBind();
    }
}