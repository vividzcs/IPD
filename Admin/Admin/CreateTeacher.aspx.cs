using BusinessLogicLayer.Impl;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils;

public partial class Admin_CreateTeacher : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.AuthCheck(Session, Request, Response, Server);

    }

    /*
     * create teacher
     */
    protected void ButtonCreateTeacher_Click(object sender, EventArgs e)
    {
        new TeacherServiceImpl().CreateTeacher(new Teacher()
        {
            Name = TextBoxName.Text,
            Password = Md5Helper.Md5WithSalt("111111"),
            JobNumber = TextBoxJobNumber.Text,
            DepartmentId = Convert.ToInt32(DropDownListDepartment.Text),
            Banned = false,
            Introduction = TextAreaIntroduction.InnerText
        });

        Response.Redirect("ManageTeacher.aspx");
    }


}