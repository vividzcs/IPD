﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils;

public partial class Admin_UploadCourseware : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.LoginCheck(Session, Request, Response, Server);
        AuthHelper.TeacherOnlyPage(Session, Request, Response, Server);

    }

    protected void StepOver(object sender, EventArgs e)
    {
        

        Response.Redirect("UploadExperiment.aspx?id=" + Request.QueryString["id"]);

    }

    protected void NextStep(object sender, EventArgs e)
    {
        Response.Redirect("UploadExperiment.aspx?id=" + Request.QueryString["id"]);
    }
}