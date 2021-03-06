﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Impl;
using BusinessLogicLayer.Interface;
using Models;
using Utils;

public partial class Admin_ManageDepartment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.LoginCheck(Session, Request, Response, Server);
        AuthHelper.AdminOnlyPage(Session, Request, Response, Server);

        if (!IsPostBack)
        {
            InitDepartmemtsData();
        }
    }

    /*
     * get and bind data with the gridview
     */
    private void InitDepartmemtsData()
    {
        var allDepartments = new DepartmentServiceImpl().GetAll();
        GridViewDepartments.DataSource = allDepartments;
        GridViewDepartments.DataBind();
    }

    /*
     * these code is the same as the teacher operators
     */
    protected void GridViewDepartments_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        IDepartmentService service = new DepartmentServiceImpl();
        if (e.CommandName == "EditRow")
        {
            int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            GridViewDepartments.EditIndex = rowIndex;
            InitDepartmemtsData();
        }
        else if (e.CommandName == "CancelUpdate")
        {
            GridViewDepartments.EditIndex = -1;
            InitDepartmemtsData();
        }
        else if (e.CommandName == "UpdateRow")
        {
            int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;

            int departmentId = Convert.ToInt32(e.CommandArgument);
            string chineseName = ((TextBox)GridViewDepartments.Rows[rowIndex].FindControl("TextBoxChineseName")).Text;
            string englishName = ((TextBox)GridViewDepartments.Rows[rowIndex].FindControl("TextBoxEnglishName")).Text;
            string intro = ((TextBox)GridViewDepartments.Rows[rowIndex].FindControl("TextBoxIntroduction")).Text;

            int succeed = service.ModifyDepartment(new Department()
            {
                ChinesaeName = chineseName,
                DepartmentId = departmentId,
                EnglishName = englishName,
                Introduction = intro
            });

            GridViewDepartments.EditIndex = -1;
            InitDepartmemtsData();

            Response.Write(succeed == 1
                    ? "<script>alert(\"修改成功！\");window.close();opener.location.reload();</script>"
                    : "<script>alert(\"修改失败请重试！\");</script>");
        }
        else if (e.CommandName == "InsertRow")
        {
            string chineseName = ((TextBox)GridViewDepartments.FooterRow.FindControl("TextBoxChineseName")).Text;
            string englishName = ((TextBox)GridViewDepartments.FooterRow.FindControl("TextBoxEnglishName")).Text;

            service.CreateDepartment(new Department()
            {
                ChinesaeName = chineseName,
                EnglishName = englishName
            });

            InitDepartmemtsData();
        }
    }
}