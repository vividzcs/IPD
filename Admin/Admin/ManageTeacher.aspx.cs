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

    protected void GridViewTeacher_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewTeacher.PageIndex = e.NewPageIndex;
        GetData();
    }

    /*
     * get and bind the data to gridviewteacher
     */
    private void GetData()
    {
        var teacher = from t in pub.Teacher
                  join d in pub.Department on t.DepartmentId equals d.DepartmentId
                  select new { t.TeacherId, t.Name, DepartmentName = d.ChinesaeName, t.Introduction, t.JobNumber };
        GridViewTeacher.DataKeyNames = new string[] { "TeacherId" };
        GridViewTeacher.DataSource = teacher.ToList();
        GridViewTeacher.DataBind();
    }
    
    /*
     * the event of clicking edit
     */
    protected void GridViewTeacher_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewTeacher.EditIndex = e.NewEditIndex;
        GetData();
    }

    /*
     * the event of clicking canceledit
     */
    protected void GridViewTeacher_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewTeacher.EditIndex = -1;
        GetData();
    }

     
    /*
     * the click event of "freeze" "reset" "edit" "update" "cancel update" and "cancelupdit"
     */
    protected void GridViewTeacher_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "freeze":

                new TeacherServiceImpl().FreezeTeacher(Convert.ToInt32(e.CommandArgument));
                break;

            case "reset":
                    new TeacherServiceImpl().ResetTeacherPassword(Convert.ToInt32(e.CommandArgument));
                break;

            case "edit":
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                
                GridViewTeacher.EditIndex = rowIndex;
                GetData();

                break;

            case "UpdateRow":
                int rowIndex_update = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;

                int teacherId = Convert.ToInt32(e.CommandArgument);
                string name = ((TextBox)GridViewTeacher.Rows[rowIndex_update].FindControl("TextBoxName")).Text;
                int departmentId = Convert.ToInt32(((DropDownList)GridViewTeacher.Rows[rowIndex_update].FindControl("dropdownListDepartment")).SelectedValue);
                string introduction = ((TextBox)GridViewTeacher.Rows[rowIndex_update].FindControl("TextBoxIntroduction")).Text;
                string jobNumber = ((TextBox)GridViewTeacher.Rows[rowIndex_update].FindControl("TextBoxJobNumber")).Text;

                new TeacherServiceImpl().ModifyTeacher(new Teacher()
                {
                    TeacherId = teacherId,
                    Name = name,
                    DepartmentId = departmentId,
                    Introduction = introduction,
                    JobNumber = jobNumber,
                });
             

                GridViewTeacher.EditIndex = -1;
                GetData();
                break;

            case "CancelUpdate":
                GridViewTeacher.EditIndex = -1;
                GetData();
                break;
        }
    }

    /*when enter the edit mode,
     * set the defaut department selectvalue equals the value
     * which it correctly is.
         */
    protected void GridViewTeacher_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow &&
            (e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
        {
            DropDownList ddl = (DropDownList)e.Row.Cells[1].FindControl("DropDownListDepartment");
            ddl.DataSource = pub.Department.ToList();
            ddl.DataTextField = "ChinesaeName";
            ddl.DataValueField = "DepartmentId";
            ddl.DataBind();
            string o = e.Row.DataItem.ToString();
            o = o.Replace('}', ' ');
            string[] param = o.Split(new char[] { ',' });
            string[] res = param[2].Split(new char[] { '=' });
            ddl.SelectedValue = res[1].Trim();
            ddl.SelectedIndexChanged += Ddl_SelectedIndexChanged;
            Session["selectValue"] = null;
        }
    }

    /*
     * add the envent of the chanege of selectedValue in dropdowntList
     */
    private void Ddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["selectValue"] = ((DropDownList)sender).SelectedValue;

    }
}