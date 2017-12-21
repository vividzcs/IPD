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
    HaermsEntities pub = new HaermsEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
            if (!IsPostBack)
            {
                GetData();
            }

    }

    private void GetData()
    {
        var teacher = from t in pub.Teacher
                  join d in pub.Department on t.DepartmentId equals d.DepartmentId
                  select new { t.TeacherId, t.Name, DepartmentName = d.ChinesaeName, t.Introduction, t.JobNumber };
        GridViewTeacher.DataKeyNames = new string[] { "TeacherId" };
        GridViewTeacher.DataSource = teacher.ToList();
        GridViewTeacher.DataBind();
    }



    protected void GridViewTeacher_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewTeacher.EditIndex = e.NewEditIndex;
        GetData();
    }



    protected void GridViewTeacher_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewTeacher.EditIndex = -1;
        GetData();
    }



    protected void GridViewTeacher_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "freeze":
                
                    new TeacherServiceImpl().FreezeTeacher(Convert.ToInt32(e.CommandArgument));
                    //将此字段设置为解除冻结
                
                break;

            case "reset":
                    new TeacherServiceImpl().ResetTeacherPassword(Convert.ToInt32(e.CommandArgument));
                break;

            case "edit":
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewTeacher.EditIndex = rowIndex;
                GetData();
                break;

            
        }
    }
}