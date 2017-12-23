using BusinessLogicLayer.Impl;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils;

public partial class Admin_CreateDepartment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.LoginCheck(Session, Request, Response, Server);
        AuthHelper.AdminOnlyPage(Session, Request, Response, Server);
    }

    /*
     create department
         */
    protected void ButtonCreateDepartment_Click(object sender, EventArgs e)
    {
        new DepartmentServiceImpl().CreateDepartment(new Department
        {
            ChinesaeName = TextBoxName.Text,
            EnglishName = TextBoxEnglishName.Text,
            Introduction = TextAreaIntroduction.InnerText,
        });

        Response.Redirect("ManageDepartment.aspx");
    }

}